using FargoAltMusicMod.UI;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace FargoAltMusicMod
{
    public class NowPlayingSystem : ModSystem
    {
        public static string nowPlayingString = null;
        public static int lastFullVolumeSong = -1;
        public static Color TextColor => new Color(255, 255, 255);

        public override void PostUpdateEverything()
        {
            if (!Main.dedServ && !Main.gameMenu)
            {
                if (Main.musicFade[Main.curMusic] == 1f && lastFullVolumeSong != Main.curMusic)
                {
                    lastFullVolumeSong = Main.curMusic;
                    //Main.NewText($"{Main.curMusic} {lastFullVolumeSong} {Main.musicFade[Main.curMusic]} {nowPlayingString}");
                    string displayString = $"Now Playing: {nowPlayingString}";
                    if (nowPlayingString != null && nowPlayingString.Length > 0)
                    {
                        if (MusicConfig.Instance.NowPlayingEnum == NowPlayingID.Notification)
                        {
                            InGameNotificationsTracker.Clear();
                            InGameNotificationsTracker.AddNotification(new NowPlayingNotif(displayString));
                        }
                        else if (MusicConfig.Instance.NowPlayingEnum == NowPlayingID.Chat)
                        {
                            Main.NewText(displayString, TextColor);
                        }
                    }
                }
            }

            nowPlayingString = null;
        }
    }
}
