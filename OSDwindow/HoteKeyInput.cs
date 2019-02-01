using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MrSmarty.CodeProject
{
    public partial class HoteKeyInput : TextBox
    {
        public HoteKeyInput()
        {
            InitializeComponent();
            base.BackColor = Color.White;
            ShortcutsEnabled = false;
        }

        private HotKey _value;
        bool SetMode = false;
        public HotKey Value { get => _value;
            set
            {
                if(value != _value)
                {
                    _value = value;
                    SetMode = false;
                    this.Text = value == null ? "请设置快捷键" : _value.ToString();
                }
            }
        }

        public event EventHandler ValueSet;
        public event EventHandler ValueCancle;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!base.DesignMode && SetMode)
            {
                MyKeys mousekey = (MyKeys)((int)e.Button / 0x100000);
                Keys modifiter = Control.ModifierKeys;
                HotkeyModifiers modifiers = 0;
                if ((modifiter & Keys.Alt) == Keys.Alt) modifiers |= HotkeyModifiers.Alt;
                if ((modifiter & Keys.Control) == Keys.Control) modifiers |= HotkeyModifiers.Control;
                if ((modifiter & Keys.Shift) == Keys.Shift) modifiers |= HotkeyModifiers.Shift;
                this.Value = new HotKey
                {
                    KeyCode = mousekey,
                    Modifiers = modifiers
                };
                ValueSet?.Invoke(this, new EventArgs());
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (!base.DesignMode && SetMode)
            {
                MyKeys mousekey = e.Delta > 0 ? MyKeys.WheelUp : MyKeys.WheelDown;
                Keys modifiter = Control.ModifierKeys;
                HotkeyModifiers modifiers = 0;
                if ((modifiter & Keys.Alt) == Keys.Alt) modifiers |= HotkeyModifiers.Alt;
                if ((modifiter & Keys.Control) == Keys.Control) modifiers |= HotkeyModifiers.Control;
                if ((modifiter & Keys.Shift) == Keys.Shift) modifiers |= HotkeyModifiers.Shift;
                this.Value = new HotKey
                {
                    KeyCode = mousekey,
                    Modifiers = modifiers
                };
                ValueSet?.Invoke(this, new EventArgs());
            }
            base.OnMouseDown(e);
        }

        Keys lastKey = Keys.None;
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!base.DesignMode)
            {
                if (e.Modifiers == Keys.None)
                {
                    if (e.KeyCode == Keys.Escape)
                    {
                        this.Value = null;
                        ValueSet?.Invoke(this, new EventArgs());
                    }
                    return;
                }
                else if(e.KeyCode != lastKey)
                {
                    SetMode = true;
                    System.Diagnostics.Debug.Print("KeyDown:" + e.KeyCode.ToString());
                    if (e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.ShiftKey && e.KeyCode != Keys.Menu)
                    {
                        HotkeyModifiers modifiers = 0;
                        if (e.Alt) modifiers |= HotkeyModifiers.Alt;
                        if (e.Control) modifiers |= HotkeyModifiers.Control;
                        if (e.Shift) modifiers |= HotkeyModifiers.Shift;
                        this.Value = new HotKey
                        {
                            KeyCode = (MyKeys)e.KeyCode,
                            Modifiers = modifiers
                        };
                        ValueSet?.Invoke(this, new EventArgs());
                    }
                    else
                    {
                        StringBuilder builder = new StringBuilder();
                        if (e.Control) builder.Append("Ctrl + ");
                        if (e.Alt) builder.Append("Alt + ");
                        if (e.Shift) builder.Append("Shift + ");
                        this.Text = builder.ToString();
                    }
                }
                lastKey = e.KeyCode;
                e.Handled = true;
            }
            
            base.OnKeyDown(e);
            
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if(!base.DesignMode)
            {
                //ValueCancle?.Invoke(this, new EventArgs());
                this.Text = Value == null ? "请设置快捷键" : Value.ToString();
            }
            base.OnLostFocus(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if(!base.DesignMode)
            {
                if(Control.ModifierKeys == Keys.None)
                {
                    SetMode = false;
                    this.Text = Value == null ? "请设置快捷键" : Value.ToString();
                }
                else if(SetMode)
                {
                    StringBuilder builder = new StringBuilder();
                    if (e.Control) builder.Append("Ctrl + ");
                    if (e.Alt) builder.Append("Alt + ");
                    if (e.Shift) builder.Append("Shift + ");
                    this.Text = builder.ToString();
                }
                lastKey = Keys.None;
            }
            base.OnKeyUp(e);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if (SetMode) return true;
            else return base.IsInputKey(keyData);
        }
    }
}
