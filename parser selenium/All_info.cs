using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser_selenium
{
    public class All_Info
    {

        public static  List<string> Types = new List<string>
            {
                "Sticker",
                "Knife",
                "Glove",
                "Rifle",
                "Pistol",
                "SMG",
                "Shotgun",
                "Machinegun",
                "Agent",
                "Case",
                "Key",
                "Other"
            };
        public static Dictionary<string, string> Name_Type = new Dictionary<string, string>
        {
            {"Nova","Shotgun" },
            {"XM1014","Shotgun" },
            {"MAG-7","Shotgun" },
            {"Sawed-off","Shotgun" },

            {"M249","Machinegun" },
            {"Negev","Machinegun" },

            {"AK-47","Rifle"},
            {"AWP","Rifle"},
            {"M4A1-S","Rifle"},
            {"M4A4","Rifle"},
            {"AUG","Rifle"},
            {"SG 553","Rifle"},
            {"FAMAS","Rifle"},
            {"Galil AR","Rifle"},
            {"SSG 08","Rifle"},
            {"SCAR-20","Rifle"},
            {"G3SG1","Rifle"},

            {"Butterfly","Knife"},
            {"★ M9 Bayonet","Knife"},
            {"Karambit","Knife"},
            {"Kukri","Knife"},
            {"Bayonet","Knife"},
            {"Skeleton","Knife"},
            {"Talon","Knife"},
            {"Nomad","Knife"},
            {"Flip","Knife"},
            {"Stiletto","Knife"},
            {"Classic","Knife"},
            {"Urus","Knife"},
            {"Huntsman","Knife"},
            {"Paracord","Knife"},
            {"Survival","Knife"},
            {"Falchion","Knife"},
            {"Shadow Dagger","Knife"},
            {"Bowie","Knife"},
            {"Gut","Knife"},
            {"Navaja","Knife"},

            {"Sport","Glove"},
            {"Specialist","Glove"},
            {"Moto","Glove"},
            {"Hand Wraps","Glove"},
            {"Driver","Glove"},
            {"Broken Fang","Glove"},
            {"Hydra","Glove"},
            {"Bloodhound","Glove"},

            {"Desert Eagle","Pistol"},
            {"USP-S","Pistol"},
            {"Glock-18","Pistol"},
            {"P250","Pistol"},
            {"P2000","Pistol"},
            {"Five-SeveN","Pistol"},
            {"R8 Revolver","Pistol"},
            {"Tec-9","Pistol"},
            {"Dual","Pistol"},//переделать
            {"Berettas","Pistol"},

            {"CZ75-Auto","Pistol"},
            {"Zeus","Pistol"},

            {"MP9","SMG"},
            {"MAC-10","SMG"},
            {"UMP-45","SMG"},
            {"P90","SMG"},
            {"MP7","SMG"},
            {"PP-Bizon","SMG"},
            {"MP5-SD","SMG"},

            {"Sticker","Sticker" },
            {"Case","Case" }
        };


    }
}
