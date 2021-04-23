using System;
using System.Runtime.InteropServices;

namespace WPFTestHarness
{
    static class WKRender
    {
        [DllImport("WKEngine4.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWitcherExePath(string exePath);
        [DllImport("WKEngine4.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddResourcePath([MarshalAs(UnmanagedType.LPStr)] string resourcePath);
        [DllImport("WKEngine4.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LoadAsset([MarshalAs(UnmanagedType.LPStr)] string assetPath);
        [DllImport("WKEngine4.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void WKRun(IntPtr hInstance, IntPtr hWnd, uint width, uint height);
    }
}
