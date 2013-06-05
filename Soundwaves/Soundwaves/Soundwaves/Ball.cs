using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using FarseerPhysics;
using FarseerPhysics.Factories;
using FarseerPhysics.Collision;
using FarseerPhysics.SamplesFramework;
using Microsoft.Xna.Framework;


namespace Soundwaves
{
    class Ball
    {
        Texture2D image;
        Body body;
        public Ball(Texture2D texture, World world, float x, float y)
        {
            image = texture;
            body = Bodyfactory.CreateRectangle(world, (float)ConvertUnits.ToSimUnits(image.Width), (float)ConvertUnits.ToSimUnits(image.Height), 1.0f);
            body.Mass = 0.01f;
            body.BodyType = BodyType.Dynamic;
            body.Restitution = .2f;
            body.Position = new Vector2(ConvertUnits.ToSimUnits(x), ConvertUnits.ToSimUnits(y));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, new Rectangle((int)ConvertUnits.ToDisplayUnits(body.Position.X), (int)ConvertUnits.ToDisplayUnits(body.Position.Y), image.Width, image.Height), Color.White);
        }

    }
}
