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
                        i = GetMusic("MyCastleTown");
                    break;

                case MusicID.OverworldDay:
                case MusicID.AltOverworldDay:
                case MusicID.WindyDay:
                    if (config.Forest)
                        i = GetMusic("ScarletForest");
                    break;

                case MusicID.Space:
                case MusicID.SpaceDay:
                    if (config.Space)
                        i = GetMusic("QuietAndFalling");
                    break;

                case MusicID.Underground:
                case MusicID.AltUnderground:
                    if (config.Underground)
                        i = GetMusic("TerraPluviam");
                    break;

                case MusicID.Jungle:
                case MusicID.JungleNight:
                    if (config.Jungle)
                        i = GetMusic("Greenpath");
                    break;

                case MusicID.JungleUnderground:
                    if (config.UndergroundJungle)
                        i = GetMusic("QueensGardens");
                    break;

                case MusicID.Crimson:
                    if (config.Crimson)
                        i = GetMusic("Guts");
                    break;

                case MusicID.UndergroundCrimson:
                    if (config.UndergroundCrimson)
                        i = GetMusic("Glory");
                    break;

                case MusicID.Corruption:
                    if (config.Corruption)
                        i = GetMusic("TheWorldLooksWhite");
                    break;

                case MusicID.UndergroundCorruption:
                    if (config.UndergroundCorruption)
                        i = GetMusic("TheWorldLooksRedCalm");
                    break;


                case MusicID.Desert:
                    if (config.Desert)
                        i = GetMusic("DancerInTheDarkness");
                    break;

                case MusicID.UndergroundDesert:
                    if (config.UndergroundDesert)
                        i = GetMusic("SandsOfTideCalm");
                    break;

                case MusicID.Snow:
                    if (config.Tundra)
                        i = GetMusic("FirstSteps");
                    break;

                case MusicID.Ice:
                    if (config.UndergroundTundra)
                        i = GetMusic("ScatteredAndLostCalm");
                    break;

                case MusicID.TheHallow:
                    if (config.Hallow)
                        i = GetMusic("JoyOfRemembrance");
                    break;

                case MusicID.UndergroundHallow:
                    if (config.UndergroundHallow)
                        i = GetMusic("PurpleRain");
                    break;

                case MusicID.Ocean:
                case MusicID.OceanNight:
                    if (config.Ocean)
                        i = GetMusic("DeepBlueCalm");
                    break;

                case MusicID.Mushrooms:
                    if (config.Mushroom)
                        i = GetMusic("TheyMightAswellBeDead");
                    break;

                case MusicID.Hell:
                    if (config.Underworld)
                        i = GetMusic("AltarsOfApostasyCalm");
                    break;

                // events
                case MusicID.Rain:
                    if (config.Rain)
                        i = GetMusic("Cyclogenesis");
                    break;

                case MusicID.Sandstorm:
                    if (config.Sandstorm)
                        i = GetMusic("SandsOfTideCombat");
                    break;

                // dungeons
                case MusicID.Dungeon:
                    if (config.Dungeon)
                        i = GetMusic("MirrorTempleB");
                    break;

                case MusicID.Temple:
                    if (config.Temple)
                        i = GetMusic("CastleVein");
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
