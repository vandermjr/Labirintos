using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Labirinto
{
    [SuppressUnmanagedCodeSecurity]
    internal static class WinApi
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA")]
        public static extern int MciSendString(string strCommand, string strReturn, int iReturnLength, IntPtr hwndCallback);
    }
}
