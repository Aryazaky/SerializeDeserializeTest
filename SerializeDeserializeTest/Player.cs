using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializeDeserializeTest
{
    [Serializable]
    public class Player
    {
        string name;
        int ID;
        public int mp;
        public int hp;
        int MAXMP;
        int MAXHP;
        public List<Skill> skills;
        [Serializable]
        public class Skill
        {
            int ID;
            public string name;
            public string description;
            public int mp_cost;
            public Skill(string _name, int _ID, string desc, int cost)
            {
                name = _name;
                description = desc;
                mp_cost = cost;
                ID = _ID;
            }
        }
        public Player(string _name, int _ID, int _MAXHP, int _MAXMP, List<Skill> _skills)
        {
            name = _name;
            ID = _ID;
            MAXHP = _MAXHP;
            hp = _MAXHP;
            MAXMP = _MAXMP;
            mp = _MAXMP;
            skills = _skills;
        }
        public string GetInfo()
        {
            string skill_list = "";
            int count = 1;
            foreach(Skill s in skills)
            {
                skill_list += $"{count++}. {s.name}\nCost: {s.mp_cost}\n{s.description}\n";
            }
            return $"{name} (Player ID {ID})'s status\n{hp}/{MAXHP}\n{mp}/{MAXMP}\n{skill_list}";
        }
    }
    class PlayerFactory
    {
        int highestID = 0;
        public Player CreateNewPlayer(string name, int _MAXHP, int _MAXMP, List<Player.Skill> _skills)
        {
            return new Player(name, highestID++, _MAXHP, _MAXMP, _skills);
        }
    }
    class SkillFactory
    {
        int highestID = 0;
        public List<Player.Skill> skills = new List<Player.Skill>();
        public Player.Skill CreateSkill(string name, int cost, string desc)
        {
            skills.Add(new Player.Skill(name, highestID++, desc, cost));
            return skills[skills.Count - 1];
        }
        public List<Player.Skill> AutoCreateSkill(string name, int cost, int count)
        {
            int lvl = 0;
            while (lvl < count)
            {
                skills.Add(new Player.Skill(name, highestID++, "normal", cost));
                if(lvl > 0)
                {
                    skills[skills.Count - 1].name = $"{skills[0].name} Lvl.{lvl+1}";
                    skills[skills.Count - 1].description = $"the stronger {skills[skills.Count - 2].name}";
                    skills[skills.Count - 1].mp_cost = skills[skills.Count - 2].mp_cost * 2;
                }
                lvl++;
            }
            return skills;
        }
    }
}
