using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NETF_ScreenCapture
{
	class GlobalKeyboardHook
	{
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);


        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        const int WH_KEYBOARD_LL = 13; // Номер глобального LowLevel-хука на клавиатуру
        const int WM_KEYDOWN = 0x100; 
        const int WM_KEYUP = 0x0101;


        private LowLevelKeyboardProc _proc;
        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;

        private IntPtr hhook = IntPtr.Zero;
        

        public void SetHook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            _proc = hookProc;
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);
        }

        public void UnHook()
        {
            UnhookWindowsHookEx(hhook);
        }

        public IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code >= 0)
            {
                if (wParam == (IntPtr)WM_KEYDOWN)
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    KeyEventArgs args = new KeyEventArgs((Keys)vkCode);
                    if ((Keys)vkCode == Keys.W || (Keys)vkCode == Keys.H || (Keys)vkCode == Keys.LShiftKey || (Keys)vkCode == Keys.Space)
                    {
                        KeyDown(this, args);
                        return (IntPtr)1;
                    }
                }

                if (wParam == (IntPtr)WM_KEYUP)
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    KeyEventArgs args = new KeyEventArgs((Keys)vkCode);
                    if ((Keys)vkCode == Keys.W || (Keys)vkCode == Keys.H || (Keys)vkCode == Keys.LShiftKey || (Keys)vkCode == Keys.Space)
                    {
                        KeyUp(this, args);
                        return (IntPtr)1;
                    }
                }
            }
            return CallNextHookEx(hhook, code, (int)wParam, lParam);
        }

    }
}
