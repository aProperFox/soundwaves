using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Soundwaves
{

    class Enemy
    {
        public bool isVisible;
        Body body;

        public Enemy(Texture2D newTexture, Rectangle newPosition)
        {
            isVisible = true;
            body = new Body(newPosition, 1, newTexture);

        }

        public void hpUpdate(int damageType)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            body.Draw(spriteBatch);
        }
/*

        public void Update(GameTime gameTime, Vector2 heroPos)
        {

            incrementSpritePosition(getXVelocity(), getYVelocity());
            if (getHasJumped())
            {
                float i = 1;
                incrementVelocity(0, (0.15f * i));
            }

            if (getYPosition() + getMyTexture().Height >= 720)
                setHasJumped(false);

            if (!getHasJumped())
                setYVelocity(0f);

            trackPlayer(heroPos);
            rectangle = new Rectangle((int)spritePosition.X,
                (int)spritePosition.Y, getMyTexture().Width / 2, getMyTexture().Height);

        }

        public void trackPlayer(Vector2 pos)
        {
            Vector2 tempPosition = getSpritePosition();


            if (Math.Abs(tempPosition.X - pos.X) > 100)
            {
                if ((tempPosition.X < pos.X))
                {
                    setCharState("enemyright");
                    incrementSpritePosition(1, 0);
                }
                else if ((tempPosition.X > pos.X))
                {
                    setCharState("enemyleft");
                    incrementSpritePosition(-1, 0);
                }
            }
            else
            {
                setCharState("enemynorm");
            }

        }
        */
    }
}
