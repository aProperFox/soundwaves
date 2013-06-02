using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Soundwaves
{
   
    class Limb
    {
        float convert = (float)(Math.PI / 180.0);
        float angle;
        Vector2 origin;
        Vector2 size;
        Texture2D stick;
        Vector2 position;

        public Limb(Vector2 newPosition, Vector2 origin, int angle, Texture2D newTexture, Vector2 size)
        {
            this.angle = ((float)angle)*convert;
            stick = newTexture;
            this.position = newPosition;
            this.origin = origin;
            this.size = size;
            System.Diagnostics.Debug.Write(newPosition.X + " " + newPosition.Y + Environment.NewLine);
        }

        public void rotateCloc(int angle)
        {

        }

        public void rotateCounterCloc(int angle)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(stick, getRect(), null, Color.White, angle, origin, SpriteEffects.None, 0);
            
        }

        public Rectangle getRect()
        {
           
            return new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
        }

        public Vector2 getEnd()
        {
             System.Diagnostics.Debug.Write((int)(Math.Cos(angle)*size.Y) + Environment.NewLine);
            return new Vector2((int)(Math.Sin(angle)*size.Y)+position.X, (int)(Math.Cos(angle+Math.PI)*size.Y)+this.position.Y);
        }
    }
}
