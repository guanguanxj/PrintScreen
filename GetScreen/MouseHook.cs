using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace GetScreen
{
    public class MouseHook : IDisposable
    {
        private int hMouseHook = 0;
        public const int WH_MOUSE_LL = 14;
        public const int WH_MOUSE = 7;
        public const int WM_MOUSEMOVE = 0x200;
        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_LBUTTONUP = 0x202;
        public Win32Api.HookProc hProc;
        public MouseHook()
        {
            //Start();
        }
        public int Start()
        {
            if (hMouseHook == 0)
            {
                Process curProcess = Process.GetCurrentProcess();
                ProcessModule curModule = curProcess.MainModule;
                //Create an instance of HookProc. 
                hProc = new Win32Api.HookProc(MouseHookProc);
                //hMouseHook = Win32Api.SetWindowsHookEx(WH_MOUSE_LL, hProc, Win32Api.GetModuleHandle(curModule.ModuleName), 0);// Win32Api.GetCurrentThreadId());//curProcess.Id//Process.GetCurrentProcess().Id
                hMouseHook = Win32Api.SetWindowsHookEx(WH_MOUSE_LL, hProc, Win32Api.GetModuleHandle("user32"), 0);//
                //SetWindowsHookEx fails.
                if (hMouseHook == 0)
                {
                    Stop();
                    Console.WriteLine("SetWindowsHookEx failed. ");
                    throw new Exception("SetWindowsHookEx failed. ");
                }
                else
                {
                    //Win32Api.UnhookWindowsHookEx(hMouseHook);
                    hMouseHook = 0;
                }
            }
            return hMouseHook;
        }
        private int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && MouseClickEvent != null)
            {
                Win32Api.MouseHookStruct MyMouseHookStruct = (Win32Api.MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(Win32Api.MouseHookStruct));
                MouseButtons button = MouseButtons.None;
                int clicks = 0;
                switch (wParam.ToInt32())
                {
                    //Mouse left key down
                    case WM_LBUTTONDOWN:
                        clicks = 1;
                        break;
                    //Mouse Left key up
                    case WM_LBUTTONUP:
                        clicks = 2;
                        break;
                    default:
                        break;
                }
                if (clicks > 0)
                {
                    button = MouseButtons.Left;
                    MouseEventArgs e = new MouseEventArgs(button, clicks, MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y, 0);
                    MouseClickEvent(this, e);
                }
            }
            return Win32Api.CallNextHookEx(hMouseHook, nCode, wParam, lParam);
        }

        public void Dispose()
        {
            Stop();
        }

        public void Stop()
        {
            bool retMouse = true;
            if (hMouseHook != 0)
            {
                retMouse = Win32Api.UnhookWindowsHookEx(hMouseHook);
                hMouseHook = 0;
            }
            if (!(retMouse))
            {
                Console.WriteLine("UnhookWindowsHookEx failed.");
                throw new Exception("UnhookWindowsHookEx failed.");
            }
        }
        //委托+事件（把钩到的消息封装为事件，由调用者处理） 
        public delegate void MouseClickHandler(object sender, MouseEventArgs e);
        public event MouseClickHandler MouseClickEvent;
    }
}
