using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI;

namespace FargoAltMusicMod.UI
{
    public class NowPlayingNotif : IInGameNotification
    {
        public bool ShouldBeRemoved => timeLeft <= 0;

        private const int MAX_TIMELEFT = 6 * 60;

        private int timeLeft = MAX_TIMELEFT;
        private string displayText;

        public NowPlayingNotif(string displayText)
        {
            this.displayText = displayText;
        }

        private float Scale
        {
            get
            {
                if (timeLeft < 30)
                    return MathHelper.Lerp(0f, 1f, timeLeft / 30f);

                const int durationOfFadeIn = 30;
                const int timeLeftThreshold = MAX_TIMELEFT - durationOfFadeIn;
                if (timeLeft > timeLeftThreshold)
                    return MathHelper.Lerp(1f, 0f, (timeLeft - timeLeftThreshold) / durationOfFadeIn);

                return 1f;
            }
        }

        private float Opacity
        {
            get
            {
                if (Scale <= 0.5f)
                    return 0f;

                return (Scale - 0.5f) / 0.5f;
            }
        }

        public void Update()
        {
            if (--timeLeft < 0)
                timeLeft = 0;
        }

        public void DrawInGame(SpriteBatch spriteBatch, Vector2 bottomAnchorPosition)
        {
            if (Opacity <= 0f)
                return;

            if (displayText == null)
                return;

            float effectiveScale = Scale * 1.1f;
            Vector2 size = (FontAssets.ItemStack.Value.MeasureString(displayText) + new Vector2(28f, 10f)) * effectiveScale;
            Vector2 notifPosition = bottomAnchorPosition;
            notifPosition.Y = 64;
            Rectangle panelSize = Utils.CenteredRectangle(notifPosition + new Vector2(0f, (0f - size.Y) * 0.5f), size);

            bool hovering = panelSize.Contains(Main.MouseScreen.ToPoint());

            Utils.DrawInvBG(spriteBatch, panelSize, new Color(30, 30, 30) * (hovering ? 0.9f : 0.6f));
            float iconScale = effectiveScale * 0.7f;
            Vector2 vector = panelSize.Right() - Vector2.UnitX * effectiveScale * 12f;
            Utils.DrawBorderString(color: NowPlayingSystem.TextColor * Opacity, sb: spriteBatch, text: displayText, pos: vector, scale: effectiveScale * 0.9f, anchorx: 1f, anchory: 0.4f);

            if (hovering)
            {
                OnMouseOver();
            }
        }

        private void OnMouseOver()
        {
            if (PlayerInput.IgnoreMouseInterface)
                return;

            Main.LocalPlayer.mouseInterface = true;

            if (!Main.mouseLeft || !Main.mouseLeftRelease)
                return;

            Main.mouseLeftRelease = false;

            if (timeLeft > 30)
                timeLeft = 30;
        }

        public void PushAnchor(ref Vector2 positionAnchorBottom)
        {
            // positionAnchorBottom.Y -= 50f * Opacity;
        }
    }
}
