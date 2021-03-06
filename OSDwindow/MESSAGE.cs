﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MrSmarty.CodeProject
{
    public enum MESSAGE
    {
        WM_ACTIVATE = 0x6,
        WM_ACTIVATEAPP = 0x1C,
        WM_ASKCBFORMATNAME = 0x30C,
        WM_CANCELJOURNAL = 0x4B,
        WM_CANCELMODE = 0x1F,
        WM_CHANGECBCHAIN = 0x30D,
        WM_CHAR = 0x102,
        WM_CHARTOITEM = 0x2F,
        WM_CHILDACTIVATE = 0x22,
        WM_CLEAR = 0x303,
        WM_CLOSE = 0x10,
        WM_COMMAND = 0x111,
        WM_COMMNOTIFY = 0x44,
        WM_COMPACTING = 0x41,
        WM_COMPAREITEM = 0x39,
        WM_COPY = 0x301,
        WM_COPYDATA = 0x4A,
        WM_CREATE = 0x1,
        WM_CTLCOLORBTN = 0x135,
        WM_CTLCOLORDLG = 0x136,
        WM_CTLCOLOREDIT = 0x133,
        WM_CTLCOLORLISTBOX = 0x134,
        WM_CTLCOLORMSGBOX = 0x132,
        WM_CTLCOLORSCROLLBAR = 0x137,
        WM_CTLCOLORSTATIC = 0x138,
        WM_CUT = 0x300,
        WM_DDE_ACK = (WM_DDE_FIRST + 4),
        WM_DDE_ADVISE = (WM_DDE_FIRST + 2),
        WM_DDE_DATA = (WM_DDE_FIRST + 5),
        WM_DDE_EXECUTE = (WM_DDE_FIRST + 8),
        WM_DDE_FIRST = 0x3E0,
        WM_DDE_INITIATE = (WM_DDE_FIRST),
        WM_DDE_LAST = (WM_DDE_FIRST + 8),
        WM_DDE_POKE = (WM_DDE_FIRST + 7),
        WM_DDE_REQUEST = (WM_DDE_FIRST + 6),
        WM_DDE_TERMINATE = (WM_DDE_FIRST + 1),
        WM_DDE_UNADVISE = (WM_DDE_FIRST + 3),
        WM_DEADCHAR = 0x103,
        WM_DELETEITEM = 0x2D,
        WM_DESTROY = 0x2,
        WM_DESTROYCLIPBOARD = 0x307,
        WM_DEVMODECHANGE = 0x1B,
        WM_DRAWCLIPBOARD = 0x308,
        WM_DRAWITEM = 0x2B,
        WM_DROPFILES = 0x233,
        WM_ENABLE = 0xA,
        WM_ENDSESSION = 0x16,
        WM_ENTERIDLE = 0x121,
        WM_ENTERMENULOOP = 0x211,
        WM_ERASEBKGND = 0x14,
        WM_EXITMENULOOP = 0x212,
        WM_FONTCHANGE = 0x1D,
        WM_GETDLGCODE = 0x87,
        WM_GETFONT = 0x31,
        WM_GETHOTKEY = 0x33,
        WM_GETMINMAXINFO = 0x24,
        WM_GETTEXT = 0xD,
        WM_GETTEXTLENGTH = 0xE,
        WM_HOTKEY = 0x312,
        WM_HSCROLL = 0x114,
        WM_HSCROLLCLIPBOARD = 0x30E,
        WM_ICONERASEBKGND = 0x27,
        WM_INITDIALOG = 0x110,
        WM_INITMENU = 0x116,
        WM_INITMENUPOPUP = 0x117,
        WM_KEYDOWN = 0x100,
        WM_KEYFIRST = 0x100,
        WM_KEYLAST = 0x108,
        WM_KEYUP = 0x101,
        WM_KILLFOCUS = 0x8,
        WM_LBUTTONDBLCLK = 0x203,
        WM_LBUTTONDOWN = 0x201,
        WM_LBUTTONUP = 0x202,
        WM_MBUTTONDBLCLK = 0x209,
        WM_MBUTTONDOWN = 0x207,
        WM_MBUTTONUP = 0x208,
        WM_MDIACTIVATE = 0x222,
        WM_MDICASCADE = 0x227,
        WM_MDICREATE = 0x220,
        WM_MDIDESTROY = 0x221,
        WM_MDIGETACTIVE = 0x229,
        WM_MDIICONARRANGE = 0x228,
        WM_MDIMAXIMIZE = 0x225,
        WM_MDINEXT = 0x224,
        WM_MDIREFRESHMENU = 0x234,
        WM_MDIRESTORE = 0x223,
        WM_MDISETMENU = 0x230,
        WM_MDITILE = 0x226,
        WM_MEASUREITEM = 0x2C,
        WM_MENUCHAR = 0x120,
        WM_MENUSELECT = 0x11F,
        WM_MOUSEACTIVATE = 0x21,
        WM_MOUSEFIRST = 0x200,
        WM_MOUSELAST = 0x209,
        WM_MOUSEMOVE = 0x200,
        WM_MOVE = 0x3,
        WM_NCACTIVATE = 0x86,
        WM_NCCALCSIZE = 0x83,
        WM_NCCREATE = 0x81,
        WM_NCDESTROY = 0x82,
        WM_NCHITTEST = 0x84,
        WM_NCLBUTTONDBLCLK = 0xA3,
        WM_NCLBUTTONDOWN = 0xA1,
        WM_NCLBUTTONUP = 0xA2,
        WM_NCMBUTTONDBLCLK = 0xA9,
        WM_NCMBUTTONDOWN = 0xA7,
        WM_NCMBUTTONUP = 0xA8,
        WM_NCMOUSEMOVE = 0xA0,
        WM_NCPAINT = 0x85,
        WM_NCRBUTTONDBLCLK = 0xA6,
        WM_NCRBUTTONDOWN = 0xA4,
        WM_NCRBUTTONUP = 0xA5,
        WM_NEXTDLGCTL = 0x28,
        WM_NULL = 0x0,
        WM_OTHERWINDOWCREATED = 0x42,
        WM_OTHERWINDOWDESTROYED = 0x43,
        WM_PAINT = 0xF,
        WM_PAINTCLIPBOARD = 0x309,
        WM_PAINTICON = 0x26,
        WM_PALETTECHANGED = 0x311,
        WM_PALETTEISCHANGING = 0x310,
        WM_PARENTNOTIFY = 0x210,
        WM_PASTE = 0x302,
        WM_PENWINFIRST = 0x380,
        WM_PENWINLAST = 0x38F,
        WM_POWER = 0x48,
        WM_QUERYDRAGICON = 0x37,
        WM_QUERYENDSESSION = 0x11,
        WM_QUERYNEWPALETTE = 0x30F,
        WM_QUERYOPEN = 0x13,
        WM_QUEUESYNC = 0x23,
        WM_QUIT = 0x12,
        WM_RBUTTONDBLCLK = 0x206,
        WM_RBUTTONDOWN = 0x204,
        WM_RBUTTONUP = 0x205,
        WM_RENDERALLFORMATS = 0x306,
        WM_RENDERFORMAT = 0x305,
        WM_SETCURSOR = 0x20,
        WM_SETFOCUS = 0x7,
        WM_SETFONT = 0x30,
        WM_SETHOTKEY = 0x32,
        WM_SETREDRAW = 0xB,
        WM_SETTEXT = 0xC,
        WM_SHOWWINDOW = 0x18,
        WM_SIZE = 0x5,
        WM_SIZECLIPBOARD = 0x30B,
        WM_SPOOLERSTATUS = 0x2A,
        WM_SYSCHAR = 0x106,
        WM_SYSCOLORCHANGE = 0x15,
        WM_SYSCOMMAND = 0x112,
        WM_SYSDEADCHAR = 0x107,
        WM_SYSKEYDOWN = 0x104,
        WM_SYSKEYUP = 0x105,
        WM_TIMECHANGE = 0x1E,
        WM_TIMER = 0x113,
        WM_UNDO = 0x304,
        WM_USER = 0x400,
        WM_VKEYTOITEM = 0x2E,
        WM_VSCROLL = 0x115,
        WM_VSCROLLCLIPBOARD = 0x30A,
        WM_WINDOWPOSCHANGED = 0x47,
        WM_WINDOWPOSCHANGING = 0x46,
        WM_WININICHANGE = 0x1A,
    }
}
