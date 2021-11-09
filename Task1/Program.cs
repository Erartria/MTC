using System;
using System.Diagnostics;
using System.Linq;

namespace Task1
{
    /// <summary>
    /// Ломай меня полностью. 
    /// Реализуйте метод FailProcess так, чтобы процесс завершался.
    /// 
    /// Предложите побольше различных решений.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FailProcess();
                //FailProcessEnvironment(-1);
                //FailProcess("Task1");
                //FailProcess(Process.GetCurrentProcess().Id);
                //FailProcess(Process.GetCurrentProcess());
                //FailProcessLinq("Task1");
            }
            catch
            {
            }

            Console.WriteLine("Failed to fail process!");
            Console.ReadKey();
        }

        static void FailProcess()
        {
            Process.GetCurrentProcess().Kill();
        }

        static void FailProcessEnvironment(int exitCode)
        {
            Environment.Exit(exitCode);
        }

        static void FailProcess(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                process.Kill();
            }
        }

        static void FailProcess(int processId)
        {
            Process.GetProcessById(processId).Kill();
        }

        static void FailProcess(Process process)
        {
            process?.Kill();
        }

        static void FailProcessLinq(string processName)
        {
            Process.GetProcesses().Where(process => process.ProcessName == processName)
                .ToList().ForEach(process => process.Kill());
        }
    }
}
