using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Soundwaves
{
    class Platform
    {
        Texture2D platformTex;
        Rectangle platformPos;

        public Platform(Texture2D newTexture, Rectangle newPosition)
        {
            platformTex = newTexture;
            platformPos = newPosition;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(platformTex, platformPos, null, Color.White);
        }

        public Rectangle getPosition()
        {
            return platformPos;
        }
    }
}
