using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Runtime.ConstrainedExecution;
using Microsoft.Win32;
using System.Threading;

namespace tsrvtcnew
{
    class GameHandle
    {
        internal struct ProcessInformation
        {
            public IntPtr hProcess;

            public IntPtr hThread;

            public int dwProcessId;

            public int dwThreadId;
        }

        public struct SecurityAttributes
        {
            public int nLength;

            public IntPtr lpSecurityDescriptor;

            public int bInheritHandle;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct Startupinfo
        {
            public int cb;

            public string lpReserved;

            public string lpDesktop;

            public string lpTitle;

            public int dwX;

            public int dwY;

            public int dwXSize;

            public int dwYSize;

            public int dwXCountChars;

            public int dwYCountChars;

            public int dwFillAttribute;

            public int dwFlags;

            public short wShowWindow;

            public short cbReserved2;

            public IntPtr lpReserved2;

            public IntPtr hStdInput;

            public IntPtr hStdOutput;

            public IntPtr hStdError;
        }
        public enum AllocationType
        {
            Commit = 4096,
            Reserve = 8192,
            Decommit = 16384,
            Release = 32768,
            Reset = 524288,
            Physical = 4194304,
            TopDown = 1048576,
            WriteWatch = 2097152,
            LargePages = 536870912
        }
        [Flags]
        public enum MemoryProtection
        {
            Execute = 16,
            ExecuteRead = 32,
            ExecuteReadWrite = 64,
            ExecuteWriteCopy = 128,
            NoAccess = 1,
            ReadOnly = 2,
            ReadWrite = 4,
            WriteCopy = 8,
            GuardModifierflag = 256,
            NoCacheModifierflag = 512,
            WriteCombineModifierflag = 1024
        }

        [Flags]
        public enum FreeType
        {
            Decommit = 16384,
            Release = 32768
        }

        public static bool Launch()
        {
            if (Process.GetProcessesByName("Steam").Length == 0)
            {
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var steamkey = hklm.OpenSubKey(@"SOFTWARE\Valve\Steam"))
                if (steamkey != null)
                {
                    string SteamExe = (string)steamkey.GetValue("SteamExe");
                    if (SteamExe != null)
                    {
                        Process.Start(SteamExe);
                        Thread.Sleep(2000);         //wait is needed to allow steam to update and connect
                    }
                    }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Steam is not installed!\n\nPlease install Steam to continue!.\n\nWant to do it now? ", "Steam Vailidation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Process.Start("http://store.steampowered.com/about/");
                        Environment.Exit(1);
                    }
                    else
                    {
                        Environment.Exit(1);
                    }
                }
            }

            String gamelocation = Properties.Settings.Default.ETS2Location;

            //allows a user who has trucksbook installed, run it before launching the game and connecting to MP
            if (Properties.Settings.Default.tbchk == true)
            {
                if (!File.Exists(Path.Combine(Properties.Settings.Default.tbpath, "TB Client.exe")))
                {
                    string error = "TrucksBook is not installed";
                    Loghandling.Logerror(error);
                    Form1.Errorsound();
                }
                var processes = Process.GetProcessesByName("TB Client");

                if (processes.Length == 0 && File.Exists(Path.Combine(Properties.Settings.Default.tbpath, "TB Client.exe")))
                {
                    Process.Start(Path.Combine(Properties.Settings.Default.tbpath, "TB Client.exe"));
                    Thread.Sleep(1500);     //allows trucksbook to launch without the 'game running' error
                }
            }

            if (Properties.Settings.Default.singleplayer == true)
            {
                Process.Start(gamelocation + "\\bin\\win_x64\\eurotrucks2.exe");
                Environment.Exit(0);
            }

            String binPath;
            String exe;
            String dll;
            String arguments = "";
            String mplocation = Properties.Settings.Default.launcherpath;

            //Lets get our games straight
            if (Properties.Settings.Default.ETS2Location !=null)
            {
                Environment.SetEnvironmentVariable("SteamGameId", "227300");
                Environment.SetEnvironmentVariable("SteamAppID", "227300");

                binPath = gamelocation + "\\bin\\win_x64";
                exe = "\\eurotrucks2.exe";
                dll = "\\core_ets2mp.dll";
                arguments += " -64bit";
            }
            else
            {
                return false; //Invalid game, lets not do this
            }

            //Intialize variables 'n stuff
            ProcessInformation processInformation = default(ProcessInformation);
            Startupinfo startupinfo = default(Startupinfo);
            SecurityAttributes securityAttributes = default(SecurityAttributes);
            SecurityAttributes securityAttributes2 = default(SecurityAttributes);
            startupinfo.cb = Marshal.SizeOf(startupinfo);
            securityAttributes.nLength = Marshal.SizeOf(securityAttributes);
            securityAttributes2.nLength = Marshal.SizeOf(securityAttributes2);

            //Lets run the game!
            if (!CreateProcess(binPath + exe, arguments, ref securityAttributes, ref securityAttributes2, false, 4u, IntPtr.Zero, binPath, ref startupinfo, out processInformation))
            {
                string error = "Failed to start game";
                Loghandling.Logerror(error);
                return false;
            }

            if (!Inject(processInformation.hProcess, "C:\\ProgramData\\TruckersMP" + dll))
            {
                string error = "DLL injection failed";
                Loghandling.Logerror(error);
                return false;
            }

            ResumeThread(processInformation.hThread);
            return true;
        }
        private static bool Inject(IntPtr process, string dllPath)
        {
            if (!File.Exists(dllPath))
                return false;

            byte[] bytes = Encoding.ASCII.GetBytes(dllPath + "\0");
            byte[] expr_A3 = bytes;
            uint num;
            IntPtr moduleHandle = GetModuleHandle("kernel32.dll");
            IntPtr procAddress = GetProcAddress(moduleHandle, "LoadLibraryA");
            IntPtr intPtr = VirtualAllocEx(process, IntPtr.Zero, (IntPtr)bytes.Length, (AllocationType)12288, MemoryProtection.ReadWrite);
            IntPtr zero = IntPtr.Zero;
            IntPtr arg_A8_1 = intPtr;


            if (moduleHandle == IntPtr.Zero || procAddress == IntPtr.Zero || intPtr == IntPtr.Zero)
                return false;

            if (!WriteProcessMemory(process, arg_A8_1, expr_A3, expr_A3.Length, out zero))
                return false;
            if ((int)zero != bytes.Length)
                return false;

            IntPtr intPtr2 = CreateRemoteThread(process, IntPtr.Zero, 0u, procAddress, intPtr, 0u, out IntPtr intPtr3);
            if (intPtr2 == IntPtr.Zero)
                return false;

            WaitForSingleObject(intPtr2, 4294967295u);
            GetExitCodeThread(intPtr2, out num);

            if (num == 0u)
                return false;

            CloseHandle(intPtr2);
            FreeLibrary(moduleHandle);

            return true;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool CreateProcess(string lpApplicationName, string lpCommandLine, ref SecurityAttributes lpProcessAttributes, ref SecurityAttributes lpThreadAttributes, bool bInheritHandles, uint dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, [In] ref Startupinfo lpStartupInfo, out ProcessInformation lpProcessInformation);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern uint ResumeThread(IntPtr hThread);

        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, AllocationType flAllocationType, MemoryProtection flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll")]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out IntPtr lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

        [DllImport("kernel32.dll")]
        private static extern bool GetExitCodeThread(IntPtr hThread, out uint lpExitCode);

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, FreeType dwFreeType);
    }
}
