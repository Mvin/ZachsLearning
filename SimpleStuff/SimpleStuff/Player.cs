using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleStuff
{
    public class Stats
    {
        public int Strength { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Health { get; set; }
    }

    /// <summary>
    /// The player class which holds all the state information for the current player.
    /// 
    /// At any point the state can be saved, or loaded new.
    /// </summary>
    public class Player
    {
        public int Level { get; set; }
        public long Exp { get; set; }
        public string Name { get; set; }
        public Stats Stats { get; set; }

        /// <summary>
        /// Create a name player.
        /// </summary>
        /// <param name="name"></param>
        public Player(string name)
        {
            Level = 0;
            Exp = 0;
            Name = name;
            Stats = new Stats();
        }

        public int GetLevel() { return Level; }
        public long GetExp() { return Exp; }
        public string GetName() { return Name; }

        /// <summary>
        /// Load a players save file, the file must exist for this to take place.
        /// </summary>
        /// <param name="filePath"></param>
        public void LoadPlayer(string name)
        {
            string PlayerFile = String.Format("{0}.json", name);

            if (File.Exists(PlayerFile))
            {
                string FileContents = File.ReadAllText(PlayerFile);
                Player SavedState = JsonConvert.DeserializeObject<Player>(FileContents);
                Level = SavedState.Level;
                Exp = SavedState.Exp;
                Name = SavedState.Name;
                Stats = SavedState.Stats;
            }
            else
            {
                Console.WriteLine("That players save file was not found");
            }
        }

        /// <summary>
        /// Save the current players state to a file.
        /// </summary>
        public void SavePlayer()
        {
            string thisPlayer = JsonConvert.SerializeObject(this);
            string PlayerFile = String.Format("{0}.json", Name);
            File.WriteAllText(PlayerFile, thisPlayer);
        }

        /// <summary>
        /// Give the current player exp, if the given exp levels them up increment their level as well.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public long GiveExp(int exp)
        {
            Exp += exp;
            Level = CalcLevel(Exp);
            return Exp;
        }

        /// <summary>
        /// Recalculate the current level of the user.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public int CalcLevel(long exp)
        {
            double level = 0.5 + Math.Sqrt(1 + 8 * (exp) / (50)) / 2;
            return Convert.ToInt32(Math.Floor(level));
        }
    }
}
