using System;
using System.Diagnostics;
using System.Linq;
namespace LoLSharp.Modules
{
    class Utils
    {
        public static Process GetLeagueProcess()
        {
            try
            {
                return Process.GetProcessesByName("League of Legends").FirstOrDefault();
            }
            catch (Exception Ex)
            {
                Console.WriteLine($"Could Not Find League of Legend's Process\n{Ex.ToString()}");
                return null;
            }
        }

        public static bool IsGameOnDisplay()
        {
            //TODO: HWND Locking up on League's HWND
        
            return NativeImport.GetActiveWindowTitle() == "League of Legends (TM) Client";
        }

        public static bool IsKeyPressed(System.Windows.Forms.Keys keys)
        {
            return 0 != (NativeImport.GetAsyncKeyState((int)keys));
        }

        public static bool IsKeyPressed(uint keys)
        {
            return 0 != (NativeImport.GetAsyncKeyState((int)keys) & 0x8000);
        }
    }
}
