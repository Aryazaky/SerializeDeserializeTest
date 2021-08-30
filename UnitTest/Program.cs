using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Process process = new Process();
            process.StartInfo.FileName = @"C:\Users\Keluarga\source\repos\SerializeDeserializeTest\SerializeDeserializeTest\bin\Debug\SerializeDeserializeTest.exe";
            process.Start();
            process.WaitForExit();
            if(process.ExitCode == 0)
            {
                Console.WriteLine("SerializeDeserialize success");
                if (File.Exists(@"D:\SerializedPlayerData.txt"))
                {
                    Console.WriteLine("Serialized file exists!");
                }
            }
            Console.ReadKey();
        }
    }
}
