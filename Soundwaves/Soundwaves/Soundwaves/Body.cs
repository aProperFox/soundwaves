using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Soundwaves
{
    class Body
    {
        Rectangle spine;
        Limb CalfL, CalfR;
        Limb ThighL, ThighR;
        Limb ForeArmL, ForeArmR;
        Limb BicepL, BicepR;
        Texture2D stick;
        public Body(Rectangle position, float size, Texture2D newTexture)
        {
            spine = position;
            /*
            distance.X = currentButt.X - spritePosition.X;
            distance.Y = currentButt.Y - spritePosition.Y;
            rotation = (float)Math.Atan2(distance.Y, distance.X);
            */
            ThighL = new Limb(new Vector2(position.X + (position.Width/2), position.Y+position.Height), new Vector2(position.Width/2, position.Height), -160, newTexture, new Vector2(position.Width * size, position.Height * size));
            ThighR = new Limb(new Vector2(position.X + (position.Width / 2), position.Y + position.Height), new Vector2(position.Width / 2, position.Height), 140, newTexture, new Vector2(position.Width * size, position.Height * size));
            CalfL = new Limb(new Vector2(ThighL.getEnd().X, ThighL.getEnd().Y), new Vector2(position.Width/2,position.Height), 180, newTexture, new Vector2(position.Width * size, position.Height * size));
            CalfR = new Limb(new Vector2(ThighR.getEnd().X, ThighR.getEnd().Y), new Vector2(position.Width/2,position.Height), 180, newTexture, new Vector2(position.Width * size, position.Height * size));
            size = size * 0.7f;
            BicepL = new Limb(new Vector2(position.X + (position.Width/2), position.Y+(position.Height/2)), new Vector2(position.Width/2, position.Height), -90, newTexture, new Vector2(position.Width * size, position.Height * size));
            BicepR = new Limb(new Vector2(position.X + (position.Width/2), position.Y+(position.Height/2)), new Vector2(position.Width/2, position.Height), 90, newTexture, new Vector2(position.Width * size, position.Height * size));
            ForeArmL = new Limb(new Vector2(BicepL.getEnd().X, BicepL.getEnd().Y), new Vector2(position.Width/2,position.Height), -30, newTexture, new Vector2(position.Width * size, position.Height * size));
            ForeArmR = new Limb(new Vector2(BicepR.getEnd().X, BicepR.getEnd().Y), new Vector2(position.Width / 2, position.Height), 30, newTexture, new Vector2(position.Width * size, position.Height * size));
            stick = newTexture;
            System.Diagnostics.Debug.Write(ThighL.getEnd().X + " " + ThighL.getEnd().Y + Environment.NewLine);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ThighL.Draw(spriteBatch);
            ThighR.Draw(spriteBatch);
            CalfL.Draw(spriteBatch);
            CalfR.Draw(spriteBatch);

            BicepL.Draw(spriteBatch);
            BicepR.Draw(spriteBatch);
            ForeArmL.Draw(spriteBatch);
            ForeArmR.Draw(spriteBatch);
            spriteBatch.Draw(stick, spine, Color.White);
        }
    }

}
