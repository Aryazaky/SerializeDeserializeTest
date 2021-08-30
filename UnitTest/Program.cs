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
            Process serializer = new Process();
            Process deserializer = new Process();
            serializer.StartInfo.FileName = @"SerializerProject.exe";
            deserializer.StartInfo.FileName = @"DeserializerProgram.exe";
            serializer.Start();
            serializer.WaitForExit();
            if(serializer.ExitCode == 0)
            {
                Console.WriteLine("Serialize success");
                if (File.Exists(@"D:\SerializedPlayerData.txt"))
                {
                    Console.WriteLine("Serialized file exists!");
                }
            }
            Console.WriteLine("Press any key to start deserializer program");
            Console.ReadKey();
            deserializer.Start();
            deserializer.WaitForExit();
            if (deserializer.ExitCode == 0)
            {
                Console.WriteLine("Deserialize success");
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
