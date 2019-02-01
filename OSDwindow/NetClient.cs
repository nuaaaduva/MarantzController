using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MrSmarty.CodeProject
{
    [DefaultEvent("TextReceived")]
    public class NetClient :Component
    {
        object lockobj = new object();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TcpClient TcpClient { get; private set; }


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Encoding ClientEncoding { get; set; } = Encoding.UTF8;

        public NetClient()
        {
            TcpClient = new TcpClient();
        }

        public static NetClient Instance;

        //static NetClient()
        //{
        //    Instance = new NetClient();
        //}

        public static NetClient CreateInstance()
        {
            Instance = new NetClient();
            return Instance;
        }

        public enum NetStatus
        {
            UnStart,
            Connecting,
            Connected,
            DisConnected,
            LoseConnected,
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetStatus Status { get; private set; } = NetStatus.UnStart;

        public class DataReceivedEventArgs : EventArgs
        {
            public byte[] Data { get; set; }

            public static implicit operator byte[] (DataReceivedEventArgs data)
            {
                return data.Data;
            }

            public static implicit operator DataReceivedEventArgs(byte[] data)
            {
                return new DataReceivedEventArgs { Data = data };
            }
        }

        public delegate void DataReceivedEventHandler(object sender, byte[] data);

        public delegate void TextReceivedEventHandler(object sender, string text);

        public class TextReceivedEventArgs : EventArgs
        {
            public string Text { get; set; }

            public static implicit operator string(TextReceivedEventArgs text)
            {
                return text.Text;
            }

            public static implicit operator TextReceivedEventArgs(string text)
            {
                return new TextReceivedEventArgs { Text = text };
            }
        }
        /// <summary>
        /// 有数据到达时触发
        /// </summary>
        public event DataReceivedEventHandler DataReceived;
        /// <summary>
        /// 有文本到达时触发
        /// </summary>
        
        public event TextReceivedEventHandler TextReceived;
        /// <summary>
        /// 连接成功时触发
        /// </summary>
        public event EventHandler Connected;

        public event EventHandler LoseConnected;

        public event EventHandler DisConnected;

        /// <summary>
        /// 连接到指定地址，异步方法
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="timeout"></param>
        public void ConnectSync(string host, int port,int timeout = 1000)
        {
            TcpClient.BeginConnect(host, port, new AsyncCallback(HandleTcpClientConnected), null);
            Status = NetStatus.Connecting;
            hostname = host;
            remoteport = port;
            new Thread(() =>
            {
                Thread.Sleep(timeout);
                if (Status != NetStatus.Connected)
                {
                    TcpClient.Close();
                    TcpClient = new TcpClient();
                    Status = NetStatus.DisConnected;
                }
            }).Start();
        }


        /// <summary>
        /// 连接到指定地址
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        public bool Connect(string host, int port,int timeout = 1000)
        {
            try
            {
                if (Status == NetStatus.Connected || Status == NetStatus.Connecting)
                {
                    DisConnect();
                }
                ConnectSync(host, port, timeout);
                while (Status == NetStatus.Connecting) { }
                return Status == NetStatus.Connected;
            }
            catch
            {
                return false;
            }
        }

        string hostname = "";
        int remoteport = 0;

        //[DefaultValue("")]
        //public string RemoteHostName
        //{
        //    get => hostname; set
        //    {
        //        if (hostname != value)
        //        {
        //            hostname = value;
        //            this.ReConnect();
        //        }
        //    }
        //}

        //[DefaultValue(0)]
        //public int RemotePort
        //{
        //    get => remoteport;
        //    set
        //    {
        //        if(remoteport != value)
        //        {
        //            remoteport = value;
        //            this.ReConnect();
        //        }
        //    }
        //}

        //public bool IsConnect { get; private set; }

        /// <summary>
        /// sockets 连接回调
        /// </summary>
        /// <param name="asyncResult"></param>
        private void HandleTcpClientConnected(IAsyncResult asyncResult)
        {
            try
            {
                TcpClient.EndConnect(asyncResult);
                Status = NetStatus.Connected;
                Connected?.Invoke(this, new EventArgs());
                byte[] readBuffer = new byte[this.TcpClient.ReceiveBufferSize];
                TcpClient.GetStream().BeginRead(readBuffer, 0, readBuffer.Length, new AsyncCallback(HandleTcpClientReceived), readBuffer);
            }
            catch
            {

            }
            
        }

        /// <summary>
        /// 数据接收回调函数
        /// </summary>
        /// <param name="asyncResult"></param>
        private void HandleTcpClientReceived(IAsyncResult asyncResult)
        {
            if (TcpClient.Connected)
            {
                int numberOfReadBytes = 0;
                try
                {
                    numberOfReadBytes = TcpClient.GetStream().EndRead(asyncResult);
                }
                catch
                {
                    numberOfReadBytes = 0;
                }

                if (numberOfReadBytes == 0)
                {
                    Status = NetStatus.LoseConnected;
                    TcpClient.Close();
                    TcpClient = new TcpClient();
                    LoseConnected?.Invoke(this, new EventArgs());
                    return;
                }
                byte[] recvBuffer = new byte[numberOfReadBytes];
                Buffer.BlockCopy((byte[])asyncResult.AsyncState, 0, recvBuffer, 0, numberOfReadBytes);
                if (isWait)
                {
                    lock(objLock)
                    {
                        bytesForWait = recvBuffer;
                    }
                }
                else
                {
                    DataReceived?.Invoke(this, recvBuffer);
                    string text = this.ClientEncoding.GetString(recvBuffer);
                    TextReceived?.Invoke(this, text);
                }
                byte[] readBuffer = new byte[this.TcpClient.ReceiveBufferSize];
                TcpClient.GetStream().BeginRead(readBuffer, 0, readBuffer.Length, new AsyncCallback(HandleTcpClientReceived), readBuffer);
                //lock (lockobj)
                //{
                //    System.IO.File.AppendAllText(Application.StartupPath + "\\log.txt", string.Format("{0:DD-mm-ss}<=={1}\r\n", DateTime.Now, Encoding.Default.GetString(recvBuffer)));
                //}
            }
        }

        byte[] bytesForWait;
        object objLock = new object();
        bool isWait = false;

        /// <summary>
        /// 取消连接
        /// </summary>
        public void DisConnect()
        {
            if (Status == NetStatus.Connected)
            {
                TcpClient.Client.Disconnect(false);
            }
            TcpClient.Close();
            TcpClient = new TcpClient();
            Status = NetStatus.DisConnected;
            DisConnected?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// 发送字节数组
        /// </summary>
        /// <param name="dataSent"></param>
        public void Send(byte[] dataSent)
        {
            if (dataSent == null || dataSent.Length == 0) throw new ArgumentNullException("dataSent");
            TcpClient.GetStream().BeginWrite(dataSent, 0, dataSent.Length, new AsyncCallback(HandleDataSent), null);
            //lock (lockobj)
            //{
            //    System.IO.File.AppendAllText(Application.StartupPath + "\\log.txt", string.Format("{0:DD-mm-ss}==>{1}\r\n", DateTime.Now, Encoding.Default.GetString(dataSent)));
            //}
        }

        /// <summary>
        /// 发送文本
        /// </summary>
        /// <param name="txtSent"></param>
        public void Send(string txtSent)
        {
            Send(ClientEncoding.GetBytes(txtSent));
        }
        /// <summary>
        /// 发送并等待回复
        /// </summary>
        /// <param name="txtSent"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public string SendAndWait(string txtSent, int timeout)
        {
            return this.ClientEncoding.GetString(SendAndWait(ClientEncoding.GetBytes(txtSent),timeout));
        }

        /// <summary>
        /// 发送并等待回复
        /// </summary>
        /// <param name="dataSent"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public byte[] SendAndWait(byte[] dataSent, int timeout)
        {
            lock(objLock)
            {
                bytesForWait = null;
                isWait = true;
            }
            Stopwatch watch = new Stopwatch();
            Send(dataSent);
            watch.Start();
            while(watch.ElapsedMilliseconds < timeout)
            {
                byte[] result = null;
                lock(objLock)
                {
                    result = bytesForWait;
                }
                if(result != null)
                {
                    return result;
                }
                Thread.Sleep(50);
            }
            lock(objLock)
            {
                return bytesForWait;
            }

        }
        /// <summary>
        /// 发送完成回调函数
        /// </summary>
        /// <param name="asyncResult"></param>
        private void HandleDataSent(IAsyncResult asyncResult)
        {
            TcpClient.GetStream().EndWrite(asyncResult);
        }
    }
}
