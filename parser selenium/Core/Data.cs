﻿using parser_selenium.Imports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser_selenium.Core
{
    internal class Data
    {
        public Dictionary<string, string> URL_Replaces = new Dictionary<string, string>
        {
            { "(" , "%28" },
            { ")" , "%29" },
            { " " , "%20" },
            { "|" , "%7C" },
            { "-" , "%20" }
        };
        public List<string> Types = new List<string>
        {
            "Pistols",
            "Rifles",
            "SMGs",
            "Heavy",
            "Knives",
            "Other"
        };
        public List<string> Weapons = new List<string>
        {
            "CZ75-Auto",
            "Desert Eagle",
            "Dual Berettas",
            "Five-SeveN",
            "Glock-18",
            "P2000",
            "P250",
            "R8 Revolver",
            "Tec-9",
            "USP-S",
            "AK-47",
            "AUG",
            "AWP",
            "FAMAS",
            "G3SG1",
            "Galil AR",
            "M4A1-S",
            "M4A4",
            "SCAR-20",
            "SG 553",
            "SSG 08",
            "MAC-10",
            "MP5-SD",
            "MP7",
            "MP9",
            "PP-Bizon",
            "P90",
            "UMP-45",
            "MAG-7",
            "Nova",
            "Sawed-Off",
            "XM1014",
            "M249",
            "Negev",
            "Bayonet",
            "Bowie Knife",
            "Butterfly Knife",
            "Classic Knife",
            "Falchion Knife",
            "Flip Knife",
            "Gut Knife",
            "Huntsman Knife",
            "Karambit",
            "Kukri Knife",
            "M9 Bayonet",
            "Navaja Knife",
            "Nomad Knife",
            "Paracord Knife",
            "Shadow Daggers",
            "Skeleton Knife",
            "Stiletto Knife",
            "Survival Knife",
            "Talon Knife",
            "Ursus Knife",
            "Zeus x27"

        };
        public List<string> quality = new List<string>
        {
            "Factory-New",
            "Minimal-Wear",
            "Field-Tested",
            "Well-Worn",
            "Battle-Scarred"
        };
        public List<Item> items = new List<Item>();
        
        public Data()
        {
            items = Imports.Data.GetItems("CSGODB.json");
        }
    }
    internal class Item
    {

        string name;
        public string Name { get => name; set { name = value; } }

        string rarity;
        public string Rarity { get => rarity; set { rarity = value; } }

        string collection;
        public string Collection { get => collection; set { collection = value; } }

        string introduced;
        public string Introduced { get => introduced; set { introduced = value; } }

        Dictionary<string,string> steamURLs;
        public Dictionary<string,string> SteamURLs { get => steamURLs; set { steamURLs = value; } }

        public Item()
        {
            steamURLs = new Dictionary<string, string>();
        }
    }
}
