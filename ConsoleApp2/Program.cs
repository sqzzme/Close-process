using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp2
{
    internal class Program
    {
        public static string nameProc = "ThPanel";
        private static readonly string appPath = Path.Combine(AppContext.BaseDirectory, @"D:\Thunder Master\ThPanel");
        Process[] processes = Process.GetProcessesByName(processName: nameProc);
        void StartAutoClose(int seconds)
        {
            if (processes.Length == 0)
            {
                Console.WriteLine("Not running");
                Process.Start(new ProcessStartInfo
                {
                    FileName = appPath,
                    UseShellExecute = true,
                    Verb = "runas"
                });
            }
            else
            {
                if (processes.Length != 0)
                {
                    Console.WriteLine("Running");
                }
                Console.WriteLine("Auto closing the application after {0} seconds.", seconds);
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.StartAutoClose(10);
            var timer = new System.Timers.Timer(5000);
            timer.Start();
            timer.Elapsed += (s, e) =>
            {
                    foreach (Process processes in Process.GetProcessesByName("ThPanel"))
                    {
                        processes.Kill();
     
                    try 
                    { 
                        if (processes.HasExited) 
                        { 
                            Console.WriteLine("Process closed successfully."); 
                        } 
                        else 
                        { 
                            Console.WriteLine("Failed to close the process."); 
                        } 
                    } 

                    catch (System.ComponentModel.Win32Exception ex) 
                    { 
                        Console.WriteLine("Cannot inspect the process. Run this application as administrator. " + ex.Message); 
                    }
                        timer.Stop();
                    }
                
                Environment.Exit(0);
            };
            Console.ReadLine();
        }
    }
}
