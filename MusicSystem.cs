using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargoAltMusicMod
{
    public class MusicSystem : ModSystem
    {
        public static int GetMusic(string name) => MusicLoader.GetMusicSlot(FargoAltMusicMod.Instance, $"Music/{name}");

        private const BindingFlags UniversalBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
        public override void Load()
        {
            MonoModHooks.Add(Update, Update_Detour);
        }

        public static int OverrideMusicID(int i)
        {
            if (Main.gameMenu)
                return i;
            int old = i;
            var config = MusicConfig.Instance;
            switch (i)
            {
                case MusicID.TownDay:
                case MusicID.TownNight:
                    if (config.Town)
                    {
                        i = GetMusic("MyCastleTown");
                        NowPlayingSystem.nowPlayingString = "My Castle Town";
                    }
                    break;

                case MusicID.OverworldDay:
                case MusicID.AltOverworldDay:
                case MusicID.WindyDay:
                case MusicID.Night:
                    if (config.Forest)
                    {
                        i = GetMusic("ScarletForest");
                        NowPlayingSystem.nowPlayingString = "Scarlet Forest";
                    }
                    break;

                case MusicID.Space:
                case MusicID.SpaceDay:
                    if (config.Space)
                    {
                        i = GetMusic("QuietAndFalling");
                        NowPlayingSystem.nowPlayingString = "Quiet and Falling";
                    }
                    break;

                case MusicID.Underground:
                case MusicID.AltUnderground:
                    if (config.Underground)
                    {
                        i = GetMusic("TerraPluviam");
                        NowPlayingSystem.nowPlayingString = "Terra Pluviam";
                    }
                    break;

                case MusicID.Jungle:
                case MusicID.JungleNight:
                    if (config.Jungle)
                    {
                        i = GetMusic("Greenpath");
                        NowPlayingSystem.nowPlayingString = "Greenpath";
                    }
                    break;

                case MusicID.JungleUnderground:
                    if (config.UndergroundJungle)
                    {
                        i = GetMusic("QueensGardens");
                        NowPlayingSystem.nowPlayingString = "Queen's Gardens";
                    }
                    break;

                case MusicID.Crimson:
                    if (config.Crimson)
                    {
                        i = GetMusic("Guts");
                        NowPlayingSystem.nowPlayingString = "Guts";
                    }
                    break;

                case MusicID.UndergroundCrimson:
                    if (config.UndergroundCrimson)
                    {
                        i = GetMusic("Glory");
                        NowPlayingSystem.nowPlayingString = "Glory";
                    }
                    break;

                case MusicID.Corruption:
                    if (config.Corruption)
                    {
                        i = GetMusic("TheWorldLooksWhite");
                        NowPlayingSystem.nowPlayingString = "The World Looks White";
                    }
                    break;

                case MusicID.UndergroundCorruption:
                    if (config.UndergroundCorruption)
                    {
                        i = GetMusic("TheWorldLooksRedCalm");
                        NowPlayingSystem.nowPlayingString = "The World Looks Red (Calm)";
                    }
                    break;


                case MusicID.Desert:
                    if (config.Desert)
                    {
                        i = GetMusic("DancerInTheDarkness");
                        NowPlayingSystem.nowPlayingString = "Dancer in the Darkness";
                    }
                    break;

                case MusicID.UndergroundDesert:
                    if (config.UndergroundDesert)
                    {
                        i = GetMusic("SandsOfTideCalm");
                        NowPlayingSystem.nowPlayingString = "Sands of Tide (Calm)";
                    }
                    break;

                case MusicID.Snow:
                    if (config.Tundra)
                    {
                        i = GetMusic("FirstSteps");
                        NowPlayingSystem.nowPlayingString = "First Steps";
                    }
                    break;

                case MusicID.Ice:
                    if (config.UndergroundTundra)
                    {
                        i = GetMusic("ScatteredAndLostCalm");
                        NowPlayingSystem.nowPlayingString = "Scattered and Lost (Calm)";
                    }
                    break;

                case MusicID.TheHallow:
                    if (config.Hallow)
                    {
                        i = GetMusic("JoyOfRemembrance");
                        NowPlayingSystem.nowPlayingString = "Joy of Remembrance";
                    }
                    break;

                case MusicID.UndergroundHallow:
                    if (config.UndergroundHallow)
                    {
                        i = GetMusic("PurpleRain");
                        NowPlayingSystem.nowPlayingString = "Rain Formerly Known as Purple";
                    }
                    break;

                case MusicID.Ocean:
                case MusicID.OceanNight:
                    if (config.Ocean)
                    {
                        i = GetMusic("DeepBlueCalm");
                        NowPlayingSystem.nowPlayingString = "Deep Blue (Calm)";
                    }
                    break;

                case MusicID.Mushrooms:
                    if (config.Mushroom)
                    {
                        i = GetMusic("TheyMightAswellBeDead");
                        NowPlayingSystem.nowPlayingString = "They Might As Well Be Dead";
                    }
                    break;

                case MusicID.Hell:
                    if (config.Underworld)
                    {
                        i = GetMusic("AltarsOfApostasyCalm");
                        NowPlayingSystem.nowPlayingString = "Altars of Apostasy (Calm)";
                    }
                    break;

                // events
                case MusicID.Rain:
                    if (config.Rain)
                    {
                        i = GetMusic("Cyclogenesis");
                        NowPlayingSystem.nowPlayingString = "Cyclogenesis";
                    }
                    break;

                case MusicID.Sandstorm:
                    if (config.Sandstorm)
                    {
                        i = GetMusic("SandsOfTideCombat");
                        NowPlayingSystem.nowPlayingString = "Sands of Tide (Combat)";
                    }
                    break;

                // dungeons
                case MusicID.Dungeon:
                    if (config.Dungeon)
                    {
                        i = GetMusic("MirrorTempleB");
                        NowPlayingSystem.nowPlayingString = "Mirror Temple B";
                    }
                    break;

                case MusicID.Temple:
                    if (config.Temple)
                    {
                        i = GetMusic("CastleVein");
                        NowPlayingSystem.nowPlayingString = "Castle Vein";
                    }
                    break;


            }
            if (i >= Main.musicFade.Length)
                return old;
            return i;
        }

        private static readonly MethodInfo Update = typeof(LegacyAudioSystem).GetMethod("Update", UniversalBindingFlags);
        public delegate void Orig_Update(LegacyAudioSystem self);
        internal static void Update_Detour(Orig_Update orig, LegacyAudioSystem self)
        {
            Main.newMusic = OverrideMusicID(Main.newMusic);
            orig(self);
        }
    }
}
