using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Soundwaves
{
    class Booty
    {
        float convert = (float)(Math.PI / 180.0);
        Rectangle spine;
        Limb CalfL, CalfR;
        Limb ThighL, ThighR;
        Limb ForeArmL, ForeArmR;
        Limb BicepL, BicepR;
        Texture2D stick;
        public Booty(Rectangle position, float size, Texture2D newTexture)
        {
            spine = position;
            /*
            distance.X = currentButt.X - spritePosition.X;
            distance.Y = currentButt.Y - spritePosition.Y;
            rotation = (float)Math.Atan2(distance.Y, distance.X);
            */
            ThighL = new Limb(new Vector2(position.X + (position.Width/2), position.Y+position.Height), new Vector2(position.Width/2, position.Height), -160, newTexture, new Vector2(position.Width * size, position.Height * size));
            ThighR = new Limb(new Vector2(position.X + (position.Width / 2), position.Y + position.Height), new Vector2(position.Width / 2, position.Height), 140, newTexture, new Vector2(position.Width * size, position.Height * size));
            CalfL = new Limb(new Vector2(ThighL.getEnd().X, ThighL.getEnd().Y), new Vector2(position.Width/2,position.Height), -179, newTexture, new Vector2(position.Width * size, position.Height * size));
            CalfR = new Limb(new Vector2(ThighR.getEnd().X, ThighR.getEnd().Y), new Vector2(position.Width/2,position.Height), 179, newTexture, new Vector2(position.Width * size, position.Height * size));
            size = size * 0.7f;
            BicepL = new Limb(new Vector2(position.X + (position.Width/2), position.Y+(position.Height/2)), new Vector2(position.Width/2, position.Height), -90, newTexture, new Vector2(position.Width * size, position.Height * size));
            BicepR = new Limb(new Vector2(position.X + (position.Width/2), position.Y+(position.Height/2)), new Vector2(position.Width/2, position.Height), 90, newTexture, new Vector2(position.Width * size, position.Height * size));
            ForeArmL = new Limb(new Vector2(BicepL.getEnd().X, BicepL.getEnd().Y), new Vector2(position.Width/2,position.Height), -30, newTexture, new Vector2(position.Width * size, position.Height * size));
            ForeArmR = new Limb(new Vector2(BicepR.getEnd().X, BicepR.getEnd().Y), new Vector2(position.Width / 2, position.Height), 30, newTexture, new Vector2(position.Width * size, position.Height * size));
            stick = newTexture;

            ThighL.setMaxAngle(-50f*convert);
            ThighL.setMinAngle(-179f*convert);
            ThighR.setMaxAngle(179f*convert);
            ThighR.setMinAngle(50f*convert);

            CalfL.setMaxAngle(-50f*convert);
            CalfL.setMinAngle(-179f*convert);
            CalfR.setMaxAngle(179f*convert);
            CalfR.setMinAngle(50f*convert);

            BicepL.setMaxAngle(0f * convert);
            BicepL.setMinAngle(-180f * convert);
            BicepR.setMaxAngle(180f * convert);
            BicepR.setMinAngle(0f * convert);

            ForeArmL.setMaxAngle(0f * convert);
            ForeArmL.setMinAngle(-180f * convert);
            ForeArmR.setMaxAngle(180f * convert);
            ForeArmR.setMinAngle(0f * convert);
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
        //Increase Angle Functions
        public void incThighL()
        {
            ThighL.rotateCloc();
        }
        public void incThighR()
        {
            ThighR.rotateCloc();
        }
        public void incBicepL()
        {
            BicepL.rotateCloc();
        }
        public void incBicepR()
        {
            BicepR.rotateCloc();
        }
        public void incCalfL()
        {
            CalfL.rotateCloc();
        }
        public void incCalfR()
        {
            CalfR.rotateCloc();
        }
        public void incForeArmL()
        {
            ForeArmL.rotateCloc();
        }
        public void incForeArmR()
        {
            ForeArmR.rotateCloc();
        }
        // Decrease angle functions
        public void decThighL()
        {
            ThighL.rotateCounterCloc();
        }
        public void decThighR()
        {
            ThighR.rotateCounterCloc();
        }
        public void decBicepL()
        {
            BicepL.rotateCounterCloc();
        }
        public void decBicepR()
        {
            BicepR.rotateCounterCloc();
        }
        public void decCalfL()
        {
            CalfL.rotateCounterCloc();
        }
        public void decCalfR()
        {
            CalfR.rotateCounterCloc();
        }
        public void decForeArmL()
        {
            ForeArmL.rotateCounterCloc();
        }
        public void decForeArmR()
        {
            ForeArmR.rotateCounterCloc();
        }

        public void update()
        {
            CalfL.setPosition(ThighL.getEnd());
            CalfR.setPosition(ThighR.getEnd());
            ForeArmL.setPosition(BicepL.getEnd());
            ForeArmR.setPosition(BicepR.getEnd());
        }
    }

}
