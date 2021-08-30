﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerializeDeserializeTest;

namespace SerializerProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"D:\SerializedPlayerData.txt";
            SerializeDeserializeTest.Program.CreatePlayerAndSerialize(filepath);
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
}
