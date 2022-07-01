using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Mechvibes.CSharp
{
	internal static class KeymapHelper
	{
		private static readonly Dictionary<int, Key> keycodes = new Dictionary<int, Key>
		{
			{ 1, Key.Escape },

			{ 59, Key.F1  },
			{ 60, Key.F2  },
			{ 61, Key.F3  },
			{ 62, Key.F4  },
			{ 63, Key.F5  },
			{ 64, Key.F6  },
			{ 65, Key.F7  },
			{ 66, Key.F8  },
			{ 67, Key.F9  },
			{ 68, Key.F10 },
			{ 87, Key.F11 },
			{ 88, Key.F12 },

			{ 41, Key.Tilde },

			{ 2,  Key.D1 },
			{ 3,  Key.D2 },
			{ 4,  Key.D3 },
			{ 5,  Key.D4 },
			{ 6,  Key.D5 },
			{ 7,  Key.D6 },
			{ 8,  Key.D7 },
			{ 9,  Key.D8 },
			{ 10, Key.D9 },
			{ 11, Key.D0 },

			{ 12, Key.Hyphen    },
			{ 13, Key.Equals    },
			{ 14, Key.Backspace },

			{ 15, Key.Tab      },
			{ 58, Key.CapsLock },

			{ 30, Key.A },
			{ 48, Key.B },
			{ 46, Key.C },
			{ 32, Key.D },
			{ 18, Key.E },
			{ 33, Key.F },
			{ 34, Key.G },
			{ 35, Key.H },
			{ 23, Key.I },
			{ 36, Key.J },
			{ 37, Key.K },
			{ 38, Key.L },
			{ 50, Key.M },
			{ 49, Key.N },
			{ 24, Key.O },
			{ 25, Key.P },
			{ 16, Key.Q },
			{ 19, Key.R },
			{ 31, Key.S },
			{ 20, Key.T },
			{ 22, Key.U },
			{ 47, Key.V },
			{ 17, Key.W },
			{ 45, Key.X },
			{ 21, Key.Y },
			{ 44, Key.Z },

			{ 26, Key.OpenBracket  },
			{ 27, Key.CloseBracket },
			{ 43, Key.BackSlash },

			{ 39, Key.Semicolon  },
			{ 40, Key.Apostrophe },
			{ 28, Key.Enter      },

			{ 51, Key.Comma        },
			{ 52, Key.Period       },
			{ 53, Key.ForwardSlash },

			{ 57, Key.Space },

			{ 3639, Key.PrintScreen },
			{ 70,   Key.ScrollLock  },
			{ 3653, Key.Pause       },

			{ 3666, Key.Insert   },
			{ 3667, Key.Delete   },
			{ 3655, Key.Home     },
			{ 3663, Key.End      },
			{ 3657, Key.PageUp   },
			{ 3665, Key.PageDown },

			{ 57416, Key.UpArrow    },
			{ 57419, Key.LeftArrow  },
			{ 57421, Key.RightArrow },
			{ 57424, Key.DownArrow  },

			{ 42,   Key.LeftShift    },
			{ 54,   Key.RightShift   },
			{ 29,   Key.LeftControl  },
			{ 3613, Key.RightControl },
			{ 56,   Key.LeftAlt      },
			{ 3640, Key.RightAlt     },
			{ 3675, Key.LeftWin      },
			{ 3676, Key.RightWin     },
			{ 3677, Key.Menu         },

			{ 61010, Key.Insert },
			{ 61011, Key.Delete },
			{ 60999, Key.Home },
			{ 61007, Key.End },
			{ 61001, Key.PageUp },
			{ 61009, Key.PageDown },
			{ 61000, Key.UpArrow },
			{ 61003, Key.LeftArrow },
			{ 61005, Key.RightArrow },
			{ 61008, Key.DownArrow },

			{ 69,   Key.NumLock     }, // Numpad
			{ 3637, Key.Divide      }, // Numpad
			{ 55,   Key.Multiply    }, // Numpad
			{ 74,   Key.Subtract    }, // Numpad
			{ 78,   Key.Add         }, // Numpad
			{ 3612, Key.NumPadEnter }, // Numpad
			{ 83,   Key.Decimal     }, // Numpad

			{ 79, Key.NumPad1 }, // Numpad
			{ 80, Key.NumPad2 }, // Numpad
			{ 81, Key.NumPad3 }, // Numpad
			{ 75, Key.NumPad4 }, // Numpad
			{ 76, Key.NumPad5 }, // Numpad
			{ 77, Key.NumPad6 }, // Numpad
			{ 71, Key.NumPad7 }, // Numpad
			{ 72, Key.NumPad8 }, // Numpad
			{ 73, Key.NumPad9 }, // Numpad
			{ 82, Key.NumPad0 }, // Numpad
		};

		public static Key GetKeyFromManifest(int Code)
		{
			switch (Code)
			{
				case 91: return Key.Unsupported;
				case 92: goto case 91;
				case 93: goto case 91;
				case 3597: goto case 91;
				default: return keycodes[Code];
			}
		}

		public static int GetCodeFromKey(Key Key) => keycodes.Where(keycode => keycode.Value == Key).First().Key;

		public static Key GetSoundPackKey(Keys WindowsKey, bool Extended = false)
		{
			if (WindowsKey == Keys.Return && Extended)
				return Key.NumPadEnter;

			switch (WindowsKey)
			{
				case Keys.Escape: return Key.Escape;
				case Keys.F1: return Key.F1;
				case Keys.F2: return Key.F2;
				case Keys.F3: return Key.F3;
				case Keys.F4: return Key.F4;
				case Keys.F5: return Key.F5;
				case Keys.F6: return Key.F6;
				case Keys.F7: return Key.F7;
				case Keys.F8: return Key.F8;
				case Keys.F9: return Key.F9;
				case Keys.F10: return Key.F10;
				case Keys.F11: return Key.F11;
				case Keys.F12: return Key.F12;
				case Keys.Oemtilde: return Key.Tilde;
				case Keys.D1: return Key.D1;
				case Keys.D2: return Key.D2;
				case Keys.D3: return Key.D3;
				case Keys.D4: return Key.D4;
				case Keys.D5: return Key.D5;
				case Keys.D6: return Key.D6;
				case Keys.D7: return Key.D7;
				case Keys.D8: return Key.D8;
				case Keys.D9: return Key.D9;
				case Keys.D0: return Key.D0;
				case Keys.OemMinus: return Key.Hyphen;
				case Keys.Oemplus: return Key.Equals;
				case Keys.Back: return Key.Backspace;
				case Keys.Insert: return Key.Insert;
				case Keys.Home: return Key.Home;
				case Keys.PageUp: return Key.PageUp;
				case Keys.NumLock: return Key.NumLock;
				case Keys.Divide: return Key.Divide;
				case Keys.Multiply: return Key.Multiply;
				case Keys.Subtract: return Key.Subtract;
				case Keys.Tab: return Key.Tab;
				case Keys.Q: return Key.Q;
				case Keys.W: return Key.W;
				case Keys.E: return Key.E;
				case Keys.R: return Key.R;
				case Keys.T: return Key.T;
				case Keys.Y: return Key.Y;
				case Keys.U: return Key.U;
				case Keys.I: return Key.I;
				case Keys.O: return Key.O;
				case Keys.P: return Key.P;
				case Keys.OemOpenBrackets: return Key.OpenBracket;
				case Keys.Oem6: return Key.CloseBracket;
				case Keys.Oem5: return Key.BackSlash;
				case Keys.Delete: return Key.Delete;
				case Keys.End: return Key.End;
				case Keys.PageDown: return Key.PageDown;
				case Keys.NumPad7: return Key.NumPad7;
				case Keys.NumPad8: return Key.NumPad8;
				case Keys.NumPad9: return Key.NumPad9;
				case Keys.Add: return Key.Add;
				case Keys.CapsLock: return Key.CapsLock;
				case Keys.A: return Key.A;
				case Keys.S: return Key.S;
				case Keys.D: return Key.D;
				case Keys.F: return Key.F;
				case Keys.G: return Key.G;
				case Keys.H: return Key.H;
				case Keys.J: return Key.J;
				case Keys.K: return Key.K;
				case Keys.L: return Key.L;
				case Keys.Oem1: return Key.Semicolon;
				case Keys.Oem7: return Key.Apostrophe;
				case Keys.Return: return Key.Enter;
				case Keys.NumPad4: return Key.NumPad4;
				case Keys.NumPad5: return Key.NumPad5;
				case Keys.NumPad6: return Key.NumPad6;
				case Keys.LShiftKey: return Key.LeftShift;
				case Keys.Z: return Key.Z;
				case Keys.X: return Key.X;
				case Keys.C: return Key.C;
				case Keys.V: return Key.V;
				case Keys.B: return Key.B;
				case Keys.N: return Key.N;
				case Keys.M: return Key.M;
				case Keys.Oemcomma: return Key.Comma;
				case Keys.OemPeriod: return Key.Period;
				case Keys.OemQuestion: return Key.ForwardSlash;
				case Keys.RShiftKey: return Key.RightShift;
				case Keys.Up: return Key.UpArrow;
				case Keys.NumPad1: return Key.NumPad1;
				case Keys.NumPad2: return Key.NumPad2;
				case Keys.NumPad3: return Key.NumPad3;
				case Keys.LControlKey: return Key.LeftControl;
				case Keys.LWin: return Key.LeftWin;
				case Keys.LMenu: return Key.LeftAlt;
				case Keys.Space: return Key.Space;
				case Keys.RMenu: return Key.RightAlt;
				case Keys.RWin: return Key.RightWin;
				case Keys.Apps: return Key.Menu;
				case Keys.RControlKey: return Key.RightControl;
				case Keys.Left: return Key.LeftArrow;
				case Keys.Down: return Key.DownArrow;
				case Keys.Right: return Key.RightArrow;
				case Keys.NumPad0: return Key.NumPad0;
				case Keys.Decimal: return Key.Decimal;
				default: return Key.Unsupported;
			}
		}

		public static (Keys, bool) GetWindowsKey(Key Keybind)
		{
			if (Keybind == Key.NumPadEnter)
				return (Keys.Return, true);

			switch (Keybind)
			{
				case Key.Escape: return (Keys.Escape, false);
				case Key.F1: return (Keys.F1, false);
				case Key.F2: return (Keys.F2, false);
				case Key.F3: return (Keys.F3, false);
				case Key.F4: return (Keys.F4, false);
				case Key.F5: return (Keys.F5, false);
				case Key.F6: return (Keys.F6, false);
				case Key.F7: return (Keys.F7, false);
				case Key.F8: return (Keys.F8, false);
				case Key.F9: return (Keys.F9, false);
				case Key.F10: return (Keys.F10, false);
				case Key.F11: return (Keys.F11, false);
				case Key.F12: return (Keys.F12, false);
				case Key.Tilde: return (Keys.Oemtilde, false);
				case Key.D1: return (Keys.D1, false);
				case Key.D2: return (Keys.D2, false);
				case Key.D3: return (Keys.D3, false);
				case Key.D4: return (Keys.D4, false);
				case Key.D5: return (Keys.D5, false);
				case Key.D6: return (Keys.D6, false);
				case Key.D7: return (Keys.D7, false);
				case Key.D8: return (Keys.D8, false);
				case Key.D9: return (Keys.D9, false);
				case Key.D0: return (Keys.D0, false);
				case Key.Hyphen: return (Keys.OemMinus, false);
				case Key.Equals: return (Keys.Oemplus, false);
				case Key.Backspace: return (Keys.Back, false);
				case Key.Insert: return (Keys.Insert, false);
				case Key.Home: return (Keys.Home, false);
				case Key.PageUp: return (Keys.PageUp, false);
				case Key.NumLock: return (Keys.NumLock, false);
				case Key.Divide: return (Keys.Divide, false);
				case Key.Multiply: return (Keys.Multiply, false);
				case Key.Subtract: return (Keys.Subtract, false);
				case Key.Tab: return (Keys.Tab, false);
				case Key.Q: return (Keys.Q, false);
				case Key.W: return (Keys.W, false);
				case Key.E: return (Keys.E, false);
				case Key.R: return (Keys.R, false);
				case Key.T: return (Keys.T, false);
				case Key.Y: return (Keys.Y, false);
				case Key.U: return (Keys.U, false);
				case Key.I: return (Keys.I, false);
				case Key.O: return (Keys.O, false);
				case Key.P: return (Keys.P, false);
				case Key.OpenBracket: return (Keys.OemOpenBrackets, false);
				case Key.CloseBracket: return (Keys.Oem6, false);
				case Key.BackSlash: return (Keys.Oem5, false);
				case Key.Delete: return (Keys.Delete, false);
				case Key.End: return (Keys.End, false);
				case Key.PageDown: return (Keys.PageDown, false);
				case Key.NumPad7: return (Keys.NumPad7, false);
				case Key.NumPad8: return (Keys.NumPad8, false);
				case Key.NumPad9: return (Keys.NumPad9, false);
				case Key.Add: return (Keys.Add, false);
				case Key.CapsLock: return (Keys.CapsLock, false);
				case Key.A: return (Keys.A, false);
				case Key.S: return (Keys.S, false);
				case Key.D: return (Keys.D, false);
				case Key.F: return (Keys.F, false);
				case Key.G: return (Keys.G, false);
				case Key.H: return (Keys.H, false);
				case Key.J: return (Keys.J, false);
				case Key.K: return (Keys.K, false);
				case Key.L: return (Keys.L, false);
				case Key.Semicolon: return (Keys.Oem1, false);
				case Key.Apostrophe: return (Keys.Oem7, false);
				case Key.Enter: return (Keys.Return, false);
				case Key.NumPad4: return (Keys.NumPad4, false);
				case Key.NumPad5: return (Keys.NumPad5, false);
				case Key.NumPad6: return (Keys.NumPad6, false);
				case Key.LeftShift: return (Keys.LShiftKey, false);
				case Key.Z: return (Keys.Z, false);
				case Key.X: return (Keys.X, false);
				case Key.C: return (Keys.C, false);
				case Key.V: return (Keys.V, false);
				case Key.B: return (Keys.B, false);
				case Key.N: return (Keys.N, false);
				case Key.M: return (Keys.M, false);
				case Key.Comma: return (Keys.Oemcomma, false);
				case Key.Period: return (Keys.OemPeriod, false);
				case Key.ForwardSlash: return (Keys.OemQuestion, false);
				case Key.RightShift: return (Keys.RShiftKey, false);
				case Key.UpArrow: return (Keys.Up, false);
				case Key.NumPad1: return (Keys.NumPad1, false);
				case Key.NumPad2: return (Keys.NumPad2, false);
				case Key.NumPad3: return (Keys.NumPad3, false);
				case Key.LeftControl: return (Keys.LControlKey, false);
				case Key.LeftWin: return (Keys.LWin, false);
				case Key.LeftAlt: return (Keys.LMenu, false);
				case Key.Space: return (Keys.Space, false);
				case Key.RightAlt: return (Keys.RMenu, false);
				case Key.RightWin: return (Keys.RWin, false);
				case Key.Menu: return (Keys.Apps, false);
				case Key.RightControl: return (Keys.RControlKey, false);
				case Key.LeftArrow: return (Keys.Left, false);
				case Key.DownArrow: return (Keys.Down, false);
				case Key.RightArrow: return (Keys.Right, false);
				case Key.NumPad0: return (Keys.NumPad0, false);
				case Key.Decimal: return (Keys.Decimal, false);
				default: return (Keys.None, false);
			}
		}
	}
}
