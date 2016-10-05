using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace SubirAndroid
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Iniciando Subida de Datos....");
                
                System.Diagnostics.Process processRespaldo = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfoRespaldo = new System.Diagnostics.ProcessStartInfo();
                startInfoRespaldo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfoRespaldo.FileName = "cmd.exe";
                startInfoRespaldo.Arguments = "/c adb pull /mnt/sdcard/Lecturas/Lect1.txt C:\\facturacion\\RespaldoLecturas";
                processRespaldo.StartInfo = startInfoRespaldo;
                processRespaldo.Start();

                var stopwatch = Stopwatch.StartNew();
                Thread.Sleep(10000);
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
                Console.WriteLine(DateTime.Now.ToLongTimeString());

                String fecha = DateTime.Now.ToString("yyyyMMddHHmmss");
                System.Diagnostics.Process processRenombrar = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfoRenombrar = new System.Diagnostics.ProcessStartInfo();
                startInfoRenombrar.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfoRenombrar.FileName = "cmd.exe";
                startInfoRenombrar.Arguments = "/c rename C:\\facturacion\\RespaldoLecturas\\Lect1.txt " + fecha + ".txt";
                processRenombrar.StartInfo = startInfoRenombrar;
                processRenombrar.Start();

                stopwatch = Stopwatch.StartNew();
                Thread.Sleep(10000);
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
                Console.WriteLine(DateTime.Now.ToLongTimeString());

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/c adb push C:\\facturacion\\Lect1.txt  /mnt/sdcard/Lecturas";
                process.StartInfo = startInfo;
                process.Start();

                stopwatch = Stopwatch.StartNew();
                Thread.Sleep(10000);
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
                Console.WriteLine(DateTime.Now.ToLongTimeString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                System.Environment.Exit(0);
            }
        }
    }
}
