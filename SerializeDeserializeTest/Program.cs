using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeDeserializeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"D:\SerializedPlayerData.txt";
            CreatePlayerAndSerialize(filepath);
            Console.ReadKey();
            DeserializePlayer(filepath);
            Console.ReadKey();
        }
        static void CreatePlayerAndSerialize(string filepath)
        {
            Player player = new PlayerFactory().CreateNewPlayer("xXPuppySlayerXx", 120, 30, new SkillFactory().AutoCreateSkill("Attack", 5, 3));
            Console.WriteLine(player.GetInfo());
            Serializer.Serialize(filepath, player);
        }
        static void DeserializePlayer(string filepath)
        {
            Player player = (Player)Deserializer.Deserialize(filepath);
            Console.WriteLine(player.GetInfo());
        }
    }
}
