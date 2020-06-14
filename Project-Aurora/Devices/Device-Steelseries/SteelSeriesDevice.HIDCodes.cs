using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurora;
using Aurora.Devices;
using Aurora.Settings;

namespace Device_SteelSeries
{
    public partial class SteelSeriesDevice
    {
        public bool TryGetHid(DeviceKeys key, out byte hid)
        {
            return SteelSeriesHidCodes.TryGetValue(key, out hid);
        }

        private static Dictionary<DeviceKeys, byte> SteelSeriesHidCodes = new Dictionary<DeviceKeys, byte>
        {
            { DeviceKeys.LOGO,          0x00 },  { DeviceKeys.A,                  0x04 },  { DeviceKeys.B,                     0x05 },  { DeviceKeys.C,            0x06 },  { DeviceKeys.D,             0x07 },
            { DeviceKeys.E,             0x08 },  { DeviceKeys.F,                  0x09 },  { DeviceKeys.G,                     0x0A },  { DeviceKeys.H,            0x0B },  { DeviceKeys.I,             0x0C },
            { DeviceKeys.J,             0x0D },  { DeviceKeys.K,                  0x0E },  { DeviceKeys.L,                     0x0F },  { DeviceKeys.M,            0x10 },  { DeviceKeys.N,             0x11 },
            { DeviceKeys.O,             0x12 },  { DeviceKeys.P,                  0x13 },  { DeviceKeys.Q,                     0x14 },  { DeviceKeys.R,            0x15 },  { DeviceKeys.S,             0x16 },
            { DeviceKeys.T,             0x17 },  { DeviceKeys.U,                  0x18 },  { DeviceKeys.V,                     0x19 },  { DeviceKeys.W,            0x1A },  { DeviceKeys.X,             0x1B },
            { DeviceKeys.Y,             0x1C },  { DeviceKeys.Z,                  0x1D },  { DeviceKeys.ONE,                   0x1E },  { DeviceKeys.TWO,          0x1F },  { DeviceKeys.THREE,         0x20 },
            { DeviceKeys.FOUR,          0x21 },  { DeviceKeys.FIVE,               0x22 },  { DeviceKeys.SIX,                   0x23 },  { DeviceKeys.SEVEN,        0x24 },  { DeviceKeys.EIGHT,         0x25 },
            { DeviceKeys.NINE,          0x26 },  { DeviceKeys.ZERO,               0x27 },  { DeviceKeys.ENTER,                 0x28 },  { DeviceKeys.ESC,          0x29 },  { DeviceKeys.BACKSPACE,     0x2A },
            { DeviceKeys.TAB,           0x2B },  { DeviceKeys.SPACE,              0x2C },  { DeviceKeys.MINUS,                 0x2D },  { DeviceKeys.EQUALS,       0x2E },  { DeviceKeys.OPEN_BRACKET,  0x2F },
            { DeviceKeys.CLOSE_BRACKET, 0x30 },  { DeviceKeys.BACKSLASH,          0x31 },  { DeviceKeys.HASHTAG,               0x32 },  { DeviceKeys.SEMICOLON,    0x33 },  { DeviceKeys.APOSTROPHE,    0x34 },
            { DeviceKeys.TILDE,         0x35 },  { DeviceKeys.JPN_HALFFULLWIDTH,  0x35 },  { DeviceKeys.OEM5,                  0x35 },  { DeviceKeys.COMMA,        0x36 },  { DeviceKeys.PERIOD,        0x37 },
            { DeviceKeys.FORWARD_SLASH, 0x38 },  { DeviceKeys.OEM8,               0x38 },  { DeviceKeys.CAPS_LOCK,             0x39 },  { DeviceKeys.F1,           0x3A },  { DeviceKeys.F2,            0x3B },
            { DeviceKeys.F3,            0x3C },  { DeviceKeys.F4,                 0x3D },  { DeviceKeys.F5,                    0x3E },  { DeviceKeys.F6,           0x3F },  { DeviceKeys.F7,            0x40 },
            { DeviceKeys.F8,            0x41 },  { DeviceKeys.F9,                 0x42 },  { DeviceKeys.F10,                   0x43 },  { DeviceKeys.F11,          0x44 },  { DeviceKeys.F12,           0x45 },
            { DeviceKeys.PRINT_SCREEN,  0x46 },  { DeviceKeys.SCROLL_LOCK,        0x47 },  { DeviceKeys.PAUSE_BREAK,           0x48 },  { DeviceKeys.INSERT,       0x49 },  { DeviceKeys.HOME,          0x4A },
            { DeviceKeys.PAGE_UP,       0x4B },  { DeviceKeys.DELETE,             0x4C },  { DeviceKeys.END,                   0x4D },  { DeviceKeys.PAGE_DOWN,    0x4E },  { DeviceKeys.ARROW_RIGHT,   0x4F },
            { DeviceKeys.ARROW_LEFT,    0x50 },  { DeviceKeys.ARROW_DOWN,         0x51 },  { DeviceKeys.ARROW_UP,              0x52 },  { DeviceKeys.NUM_LOCK,     0x53 },  { DeviceKeys.NUM_SLASH,     0x54 },
            { DeviceKeys.NUM_ASTERISK,  0x55 },  { DeviceKeys.NUM_MINUS,          0x56 },  { DeviceKeys.NUM_PLUS,              0x57 },  { DeviceKeys.NUM_ENTER,    0x58 },  { DeviceKeys.NUM_ONE,       0x59 },
            { DeviceKeys.NUM_TWO,       0x5A },  { DeviceKeys.NUM_THREE,          0x5B },  { DeviceKeys.NUM_FOUR,              0x5C },  { DeviceKeys.NUM_FIVE,     0x5D },  { DeviceKeys.NUM_SIX,       0x5E },
            { DeviceKeys.NUM_SEVEN,     0x5F },  { DeviceKeys.NUM_EIGHT,          0x60 },  { DeviceKeys.NUM_NINE,              0x61 },  { DeviceKeys.NUM_ZERO,     0x62 },  { DeviceKeys.NUM_PERIOD,    0x63 },
            { DeviceKeys.BACKSLASH_UK,  0x64 },  { DeviceKeys.APPLICATION_SELECT, 0x65 },  { DeviceKeys.JPN_HIRAGANA_KATAKANA, 0x88 },  { DeviceKeys.JPN_HENKAN,   0x8A },  { DeviceKeys.JPN_MUHENKAN,  0x8B },
            { DeviceKeys.LEFT_CONTROL,  0xE0 },  { DeviceKeys.LEFT_SHIFT,         0xE1 },  { DeviceKeys.LEFT_ALT,              0xE2 },  { DeviceKeys.LEFT_WINDOWS, 0xE3 },  { DeviceKeys.RIGHT_CONTROL, 0xE4 },
            { DeviceKeys.RIGHT_SHIFT,   0xE5 },  { DeviceKeys.RIGHT_ALT,          0xE6 },  { DeviceKeys.RIGHT_WINDOWS,         0xE7 },  { DeviceKeys.G0,           0xE8 },  { DeviceKeys.G1,            0xE9 },
            { DeviceKeys.G2,            0xEA },  { DeviceKeys.G3,                 0xEB },  { DeviceKeys.G4,                    0xEC },  { DeviceKeys.G5,           0xED },  { DeviceKeys.FN_Key,        0xEF }
        };
        
        public static byte GetHIDCode(DeviceKeys key)
        {

            switch (key)
            {
                case (DeviceKeys.LOGO):
                    return (byte)SteelSeriesKeyCodes.LOGO;
                case (DeviceKeys.FN_Key):
                    return (byte)SteelSeriesKeyCodes.SS_KEY;
                case (DeviceKeys.G0):
                    return (byte)SteelSeriesKeyCodes.G0;
                case (DeviceKeys.G1):
                    return (byte)SteelSeriesKeyCodes.G1;
                case (DeviceKeys.G2):
                    return (byte)SteelSeriesKeyCodes.G2;
                case (DeviceKeys.G3):
                    return (byte)SteelSeriesKeyCodes.G3;
                case (DeviceKeys.G4):
                    return (byte)SteelSeriesKeyCodes.G4;
                case (DeviceKeys.G5):
                    return (byte)SteelSeriesKeyCodes.G5;
                case (DeviceKeys.ESC):
                    return (byte)USBHIDCodes.ESC;
                case (DeviceKeys.F1):
                    return (byte)USBHIDCodes.F1;
                case (DeviceKeys.F2):
                    return (byte)USBHIDCodes.F2;
                case (DeviceKeys.F3):
                    return (byte)USBHIDCodes.F3;
                case (DeviceKeys.F4):
                    return (byte)USBHIDCodes.F4;
                case (DeviceKeys.F5):
                    return (byte)USBHIDCodes.F5;
                case (DeviceKeys.F6):
                    return (byte)USBHIDCodes.F6;
                case (DeviceKeys.F7):
                    return (byte)USBHIDCodes.F7;
                case (DeviceKeys.F8):
                    return (byte)USBHIDCodes.F8;
                case (DeviceKeys.F9):
                    return (byte)USBHIDCodes.F9;
                case (DeviceKeys.F10):
                    return (byte)USBHIDCodes.F10;
                case (DeviceKeys.F11):
                    return (byte)USBHIDCodes.F11;
                case (DeviceKeys.F12):
                    return (byte)USBHIDCodes.F12;
                case (DeviceKeys.PRINT_SCREEN):
                    return (byte)USBHIDCodes.PRINT_SCREEN;
                case (DeviceKeys.SCROLL_LOCK):
                    return (byte)USBHIDCodes.SCROLL_LOCK;
                case (DeviceKeys.PAUSE_BREAK):
                    return (byte)USBHIDCodes.PAUSE_BREAK;
                case (DeviceKeys.JPN_HALFFULLWIDTH):
                    return (byte)USBHIDCodes.TILDE;
                case (DeviceKeys.OEM5):
                    if (Global.kbLayout.Loaded_Localization == PreferredKeyboardLocalization.jpn)
                        return (byte)USBHIDCodes.ERROR;
                    else
                        return (byte)USBHIDCodes.TILDE;
                case (DeviceKeys.TILDE):
                    return (byte)USBHIDCodes.TILDE;
                case (DeviceKeys.ONE):
                    return (byte)USBHIDCodes.ONE;
                case (DeviceKeys.TWO):
                    return (byte)USBHIDCodes.TWO;
                case (DeviceKeys.THREE):
                    return (byte)USBHIDCodes.THREE;
                case (DeviceKeys.FOUR):
                    return (byte)USBHIDCodes.FOUR;
                case (DeviceKeys.FIVE):
                    return (byte)USBHIDCodes.FIVE;
                case (DeviceKeys.SIX):
                    return (byte)USBHIDCodes.SIX;
                case (DeviceKeys.SEVEN):
                    return (byte)USBHIDCodes.SEVEN;
                case (DeviceKeys.EIGHT):
                    return (byte)USBHIDCodes.EIGHT;
                case (DeviceKeys.NINE):
                    return (byte)USBHIDCodes.NINE;
                case (DeviceKeys.ZERO):
                    return (byte)USBHIDCodes.ZERO;
                case (DeviceKeys.MINUS):
                    return (byte)USBHIDCodes.MINUS;
                case (DeviceKeys.EQUALS):
                    return (byte)USBHIDCodes.EQUALS;
                case (DeviceKeys.BACKSPACE):
                    return (byte)USBHIDCodes.BACKSPACE;
                case (DeviceKeys.INSERT):
                    return (byte)USBHIDCodes.INSERT;
                case (DeviceKeys.HOME):
                    return (byte)USBHIDCodes.HOME;
                case (DeviceKeys.PAGE_UP):
                    return (byte)USBHIDCodes.PAGE_UP;
                case (DeviceKeys.NUM_LOCK):
                    return (byte)USBHIDCodes.NUM_LOCK;
                case (DeviceKeys.NUM_SLASH):
                    return (byte)USBHIDCodes.NUM_SLASH;
                case (DeviceKeys.NUM_ASTERISK):
                    return (byte)USBHIDCodes.NUM_ASTERISK;
                case (DeviceKeys.NUM_MINUS):
                    return (byte)USBHIDCodes.NUM_MINUS;
                case (DeviceKeys.TAB):
                    return (byte)USBHIDCodes.TAB;
                case (DeviceKeys.Q):
                    return (byte)USBHIDCodes.Q;
                case (DeviceKeys.W):
                    return (byte)USBHIDCodes.W;
                case (DeviceKeys.E):
                    return (byte)USBHIDCodes.E;
                case (DeviceKeys.R):
                    return (byte)USBHIDCodes.R;
                case (DeviceKeys.T):
                    return (byte)USBHIDCodes.T;
                case (DeviceKeys.Y):
                    return (byte)USBHIDCodes.Y;
                case (DeviceKeys.U):
                    return (byte)USBHIDCodes.U;
                case (DeviceKeys.I):
                    return (byte)USBHIDCodes.I;
                case (DeviceKeys.O):
                    return (byte)USBHIDCodes.O;
                case (DeviceKeys.P):
                    return (byte)USBHIDCodes.P;
                case (DeviceKeys.OPEN_BRACKET):
                    return (byte)USBHIDCodes.OPEN_BRACKET;
                case (DeviceKeys.CLOSE_BRACKET):
                    return (byte)USBHIDCodes.CLOSE_BRACKET;
                case (DeviceKeys.BACKSLASH):
                    return (byte)USBHIDCodes.BACKSLASH;
                case (DeviceKeys.DELETE):
                    return (byte)USBHIDCodes.KEYBOARD_DELETE;
                case (DeviceKeys.END):
                    return (byte)USBHIDCodes.END;
                case (DeviceKeys.PAGE_DOWN):
                    return (byte)USBHIDCodes.PAGE_DOWN;
                case (DeviceKeys.NUM_SEVEN):
                    return (byte)USBHIDCodes.NUM_SEVEN;
                case (DeviceKeys.NUM_EIGHT):
                    return (byte)USBHIDCodes.NUM_EIGHT;
                case (DeviceKeys.NUM_NINE):
                    return (byte)USBHIDCodes.NUM_NINE;
                case (DeviceKeys.NUM_PLUS):
                    return (byte)USBHIDCodes.NUM_PLUS;
                case (DeviceKeys.CAPS_LOCK):
                    return (byte)USBHIDCodes.CAPS_LOCK;
                case (DeviceKeys.A):
                    return (byte)USBHIDCodes.A;
                case (DeviceKeys.S):
                    return (byte)USBHIDCodes.S;
                case (DeviceKeys.D):
                    return (byte)USBHIDCodes.D;
                case (DeviceKeys.F):
                    return (byte)USBHIDCodes.F;
                case (DeviceKeys.G):
                    return (byte)USBHIDCodes.G;
                case (DeviceKeys.H):
                    return (byte)USBHIDCodes.H;
                case (DeviceKeys.J):
                    return (byte)USBHIDCodes.J;
                case (DeviceKeys.K):
                    return (byte)USBHIDCodes.K;
                case (DeviceKeys.L):
                    return (byte)USBHIDCodes.L;
                case (DeviceKeys.SEMICOLON):
                    return (byte)USBHIDCodes.SEMICOLON;
                case (DeviceKeys.APOSTROPHE):
                    return (byte)USBHIDCodes.APOSTROPHE;
                case (DeviceKeys.HASHTAG):
                    return (byte)USBHIDCodes.HASHTAG;
                case (DeviceKeys.ENTER):
                    return (byte)USBHIDCodes.ENTER;
                case (DeviceKeys.NUM_FOUR):
                    return (byte)USBHIDCodes.NUM_FOUR;
                case (DeviceKeys.NUM_FIVE):
                    return (byte)USBHIDCodes.NUM_FIVE;
                case (DeviceKeys.NUM_SIX):
                    return (byte)USBHIDCodes.NUM_SIX;
                case (DeviceKeys.LEFT_SHIFT):
                    return (byte)USBHIDCodes.LEFT_SHIFT;
                case (DeviceKeys.BACKSLASH_UK):
                    if (Global.kbLayout.Loaded_Localization == PreferredKeyboardLocalization.jpn)
                        return (byte)USBHIDCodes.ERROR;
                    else
                        return (byte)USBHIDCodes.BACKSLASH_UK;
                case (DeviceKeys.Z):
                    return (byte)USBHIDCodes.Z;
                case (DeviceKeys.X):
                    return (byte)USBHIDCodes.X;
                case (DeviceKeys.C):
                    return (byte)USBHIDCodes.C;
                case (DeviceKeys.V):
                    return (byte)USBHIDCodes.V;
                case (DeviceKeys.B):
                    return (byte)USBHIDCodes.B;
                case (DeviceKeys.N):
                    return (byte)USBHIDCodes.N;
                case (DeviceKeys.M):
                    return (byte)USBHIDCodes.M;
                case (DeviceKeys.COMMA):
                    return (byte)USBHIDCodes.COMMA;
                case (DeviceKeys.PERIOD):
                    return (byte)USBHIDCodes.PERIOD;
                case (DeviceKeys.FORWARD_SLASH):
                    return (byte)USBHIDCodes.FORWARD_SLASH;
                case (DeviceKeys.OEM8):
                    return (byte)USBHIDCodes.FORWARD_SLASH;
                case (DeviceKeys.OEM102):
                    return (byte)USBHIDCodes.ERROR;
                case (DeviceKeys.RIGHT_SHIFT):
                    return (byte)USBHIDCodes.RIGHT_SHIFT;
                case (DeviceKeys.ARROW_UP):
                    return (byte)USBHIDCodes.ARROW_UP;
                case (DeviceKeys.NUM_ONE):
                    return (byte)USBHIDCodes.NUM_ONE;
                case (DeviceKeys.NUM_TWO):
                    return (byte)USBHIDCodes.NUM_TWO;
                case (DeviceKeys.NUM_THREE):
                    return (byte)USBHIDCodes.NUM_THREE;
                case (DeviceKeys.NUM_ENTER):
                    return (byte)USBHIDCodes.NUM_ENTER;
                case (DeviceKeys.LEFT_CONTROL):
                    return (byte)USBHIDCodes.LEFT_CONTROL;
                case (DeviceKeys.LEFT_WINDOWS):
                    return (byte)USBHIDCodes.LEFT_WINDOWS;
                case (DeviceKeys.LEFT_ALT):
                    return (byte)USBHIDCodes.LEFT_ALT;
                case (DeviceKeys.JPN_MUHENKAN):
                    return (byte)USBHIDCodes.JPN_MUHENKAN;
                case (DeviceKeys.SPACE):
                    return (byte)USBHIDCodes.SPACE;
                case (DeviceKeys.JPN_HENKAN):
                    return (byte)USBHIDCodes.JPN_HENKAN;
                case (DeviceKeys.JPN_HIRAGANA_KATAKANA):
                    return (byte)USBHIDCodes.JPN_HIRAGANA_KATAKANA;
                case (DeviceKeys.RIGHT_ALT):
                    return (byte)USBHIDCodes.RIGHT_ALT;
                case (DeviceKeys.RIGHT_WINDOWS):
                    return (byte)USBHIDCodes.RIGHT_WINDOWS;
                //case (DeviceKeys.FN_Key):
                //return (byte) USBHIDCodes.RIGHT_WINDOWS;
                case (DeviceKeys.APPLICATION_SELECT):
                    return (byte)USBHIDCodes.APPLICATION_SELECT;
                case (DeviceKeys.RIGHT_CONTROL):
                    return (byte)USBHIDCodes.RIGHT_CONTROL;
                case (DeviceKeys.ARROW_LEFT):
                    return (byte)USBHIDCodes.ARROW_LEFT;
                case (DeviceKeys.ARROW_DOWN):
                    return (byte)USBHIDCodes.ARROW_DOWN;
                case (DeviceKeys.ARROW_RIGHT):
                    return (byte)USBHIDCodes.ARROW_RIGHT;
                case (DeviceKeys.NUM_ZERO):
                    return (byte)USBHIDCodes.NUM_ZERO;
                case (DeviceKeys.NUM_PERIOD):
                    return (byte)USBHIDCodes.NUM_PERIOD;

                default:
                    return (byte)USBHIDCodes.ERROR;
            }
        }
    }

    public enum SteelSeriesKeyCodes
    {
        LOGO = 0x00,
        SS_KEY = 0xEF,
        G0 = 0xE8,
        G1 = 0xE9,
        G2 = 0xEA,
        G3 = 0xEB,
        G4 = 0xEC,
        G5 = 0xED,
    };

    public enum USBHIDCodes
{
    //NONE = 0x00,
    ERROR = 0x03,

    A = 0x04,
    B = 0x05,
    C = 0x06,
    D = 0x07,
    E = 0x08,
    F = 0x09,
    G = 0x0A,
    H = 0x0B,
    I = 0x0C,
    J = 0x0D,
    K = 0x0E,
    L = 0x0F,
    M = 0x10,
    N = 0x11,
    O = 0x12,
    P = 0x13,
    Q = 0x14,
    R = 0x15,
    S = 0x16,
    T = 0x17,
    U = 0x18,
    V = 0x19,
    W = 0x1A,
    X = 0x1B,
    Y = 0x1C,
    Z = 0x1D,

    ONE = 0x1E,
    TWO = 0x1F,
    THREE = 0x20,
    FOUR = 0x21,
    FIVE = 0x22,
    SIX = 0x23,
    SEVEN = 0x24,
    EIGHT = 0x25,
    NINE = 0x26,
    ZERO = 0x27,

    ENTER = 0x28,
    ESC = 0x29,
    BACKSPACE = 0x2A,
    TAB = 0x2B,
    SPACE = 0x2C,
    MINUS = 0x2D,
    EQUALS = 0x2E,
    OPEN_BRACKET = 0x2F,
    CLOSE_BRACKET = 0x30,
    BACKSLASH = 0x31,
    HASHTAG = 0x32,         // Keyboard Non-US # and ~
    SEMICOLON = 0x33,
    APOSTROPHE = 0x34,
    TILDE = 0x35,
    COMMA = 0x36,
    PERIOD = 0x37,
    FORWARD_SLASH = 0x38,
    CAPS_LOCK = 0x39,

    F1 = 0x3A,
    F2 = 0x3B,
    F3 = 0x3C,
    F4 = 0x3D,
    F5 = 0x3E,
    F6 = 0x3F,
    F7 = 0x40,
    F8 = 0x41,
    F9 = 0x42,
    F10 = 0x43,
    F11 = 0x44,
    F12 = 0x45,

    PRINT_SCREEN = 0x46,
    SCROLL_LOCK = 0x47,
    PAUSE_BREAK = 0x48,
    INSERT = 0x49,
    HOME = 0x4A,
    PAGE_UP = 0x4B,
    KEYBOARD_DELETE = 0x4C,
    END = 0x4D,
    PAGE_DOWN = 0x4E,

    ARROW_RIGHT = 0x4F,
    ARROW_LEFT = 0x50,
    ARROW_DOWN = 0x51,
    ARROW_UP = 0x52,
    
    NUM_LOCK = 0x53,
    NUM_SLASH = 0x54,
    NUM_ASTERISK = 0x55,
    NUM_MINUS = 0x56,
    NUM_PLUS = 0x57,
    NUM_ENTER = 0x58,
    NUM_ONE = 0x59,
    NUM_TWO = 0x5A,
    NUM_THREE = 0x5B,
    NUM_FOUR = 0x5C,
    NUM_FIVE = 0x5D,
    NUM_SIX = 0x5E,
    NUM_SEVEN = 0x5F,
    NUM_EIGHT = 0x60,
    NUM_NINE = 0x61,
    NUM_ZERO = 0x62,
    NUM_PERIOD = 0x63,

    BACKSLASH_UK = 0x64,    // Keyboard Non-US \ and |
    APPLICATION_SELECT = 0x65,

    // skip unused special keys from 0x66 to 0xA4
    //0x66	Keyboard Power
    //0x67	Keypad =
    //0x68  Keyboard F13
    //0x69	Keyboard F14
    //0x6A	Keyboard F15
    //0x6B	Keyboard F16
    //0x6C	Keyboard F17
    //0x6D	Keyboard F18
    //0x6E	Keyboard F19
    //0x6F	Keyboard F20
    //0x70	Keyboard F21
    //0x71	Keyboard F22
    //0x72	Keyboard F23
    //0x73	Keyboard F24
    //0x74	Keyboard Execute
    //0x75	Keyboard Help
    //0x76	Keyboard Menu
    //0x77	Keyboard Select
    //0x78	Keyboard Stop
    //0x79	Keyboard Again
    //0x7A	Keyboard Undo
    //0x7B	Keyboard Cut
    //0x7C	Keyboard Copy
    //0x7D	Keyboard Paste
    //0x7E	Keyboard Find
    //0x7F	Keyboard Mute
    //0x80	Keyboard Volume Up
    //0x81	Keyboard Volume Down
    //0x82	Keyboard Locking Caps Lock
    //0x83	Keyboard Locking Num Lock
    //0x84	Keyboard Locking Scroll Lock
    //0x85	Keypad Comma
    //0x86	Keypad Equal Sign
    //0x87	Keyboard International1
    JPN_HIRAGANA_KATAKANA = 0x88, // Keyboard International2
    //0x89	Keyboard International3
    JPN_HENKAN = 0x8a,      // Keyboard International4
    JPN_MUHENKAN = 0x8b,    // Keyboard International5
    //0x8C	Keyboard International6
    //0x8D	Keyboard International7
    //0x8E	Keyboard International8
    //0x8F	Keyboard International9
    //0x90	Keyboard LANG1
    //0x91	Keyboard LANG2
    //0x92	Keyboard LANG3
    //0x93	Keyboard LANG4
    //0x94	Keyboard LANG5
    //0x95	Keyboard LANG6
    //0x96	Keyboard LANG7
    //0x97	Keyboard LANG8
    //0x98	Keyboard LANG9
    //0x99	Keyboard Alternate Erase
    //0x9A	Keyboard SysReq/Attention
    //0x9B	Keyboard Cancel
    //0x9C	Keyboard Clear
    //0x9D	Keyboard Prior
    //0x9E	Keyboard Return
    //0x9F	Keyboard Separator
    //0xA0	Keyboard Out
    //0xA1	Keyboard Oper
    //0xA2	Keyboard Clear/Again
    //0xA3	Keyboard CrSel/Props
    //0xA4	Keyboard ExSel

    LEFT_CONTROL = 0xE0,
    LEFT_SHIFT = 0xE1,
    LEFT_ALT = 0xE2,
    LEFT_WINDOWS = 0xE3,
    RIGHT_CONTROL = 0xE4,
    RIGHT_SHIFT = 0xE5,
    RIGHT_ALT = 0xE6,
    RIGHT_WINDOWS = 0xE7,

    //OEM102 = 384,  
};
}