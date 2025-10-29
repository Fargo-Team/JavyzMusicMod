using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;
using Terraria.ModLoader;

namespace FargoAltMusicMod
{
    public class MusicConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        public static MusicConfig Instance => ModContent.GetInstance<MusicConfig>();

        [DefaultValue(NowPlayingID.Notification)]
        [DrawTicks]
        public NowPlayingID NowPlayingEnum;

        [Header("Bosses")]

        [DefaultValue(true)]
        public bool KingSlime;

        [DefaultValue(true)]
        public bool EyeOfCthulhu;

        [DefaultValue(true)]
        public bool BrainOfCthulhu;

        [DefaultValue(true)]
        public bool EaterOfWorlds;

        [DefaultValue(true)]
        public bool QueenBee;

        [DefaultValue(true)]
        public bool Skeletron;

        [DefaultValue(false)]
        public bool Deviantt;

        [DefaultValue(true)]
        public bool WallOfFlesh;

        [DefaultValue(false)]
        public bool Baron;

        [DrawTicks]
        [OptionStrings(["Default", "War Without Reason", "Red Sun", "Red Sun (Instrumental)"])]
        [DefaultValue("War Without Reason")]
        public string MechBosses;

        [DefaultValue(false)]
        public bool Lieflight;

        [DrawTicks]
        [OptionStrings(["Default", "God of the Dead", "AFTERLIFE"])]
        [DefaultValue("God of the Dead")]
        public string Plantera;

        [DefaultValue(true)]
        public bool Betsy;

        [DefaultValue(true)]
        public bool Golem;

        [DefaultValue(true)]
        public bool DukeFishron;

        [DrawTicks]
        [OptionStrings(["Default", "A Mother's Love", "Death of God's Will", "Border of Life"])]
        [DefaultValue("A Mother's Love")]
        public string EmpressOfLight;

        [DefaultValue(true)]
        public bool Cultist;

        [DrawTicks]
        [OptionStrings(["Default", "Bigger Guitar", "GUARDIAN"])]
        [DefaultValue("GUARDIAN")]
        public string MoonLord;

        [DefaultValue(false)]
        public bool Eridanus;

        [DrawTicks]
        [OptionStrings(["Default", "WAR", "Stigma"])]
        [DefaultValue("Default")]
        public string Abom;

        [DefaultValue(false)]
        public bool Mutant;

        [Header("Events")]

        [DefaultValue(true)]
        public bool Rain;

        [DefaultValue(true)]
        public bool Sandstorm;

        [DefaultValue(true)]
        public bool Blizzard;

        [DrawTicks]
        [OptionStrings(["Default", "Coalescence/con lentitud poderosa", "Crumbling Tower"])]
        [DefaultValue("Crumbling Tower")]
        public string LunarPillars;

        [Header("Biomes")]

        [DefaultValue(true)]
        public bool Town;

        [DefaultValue(true)]
        public bool Forest;

        [DefaultValue(true)]
        public bool Underground;

        [DefaultValue(true)]
        public bool Jungle;

        [DefaultValue(true)]
        public bool UndergroundJungle;

        [DefaultValue(true)]
        public bool Crimson;

        [DefaultValue(true)]
        public bool UndergroundCrimson;

        [DefaultValue(true)]
        public bool Corruption;

        [DefaultValue(true)]
        public bool UndergroundCorruption;

        [DefaultValue(true)]
        public bool Space;

        [DefaultValue(true)]
        public bool Desert;

        [DefaultValue(true)]
        public bool UndergroundDesert;

        [DefaultValue(true)]
        public bool Tundra;

        [DefaultValue(true)]
        public bool UndergroundTundra;

        [DefaultValue(true)]
        public bool Hallow;

        [DefaultValue(true)]
        public bool UndergroundHallow;

        [DefaultValue(true)]
        public bool Ocean;

        [DefaultValue(true)]
        public bool Mushroom;

        [DefaultValue(true)]
        public bool Dungeon;

        [DefaultValue(true)]
        public bool Temple;

        [DefaultValue(true)]
        public bool Underworld;

    }
}
