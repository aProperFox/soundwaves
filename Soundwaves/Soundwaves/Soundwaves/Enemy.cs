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
        private int hitPoints;
        private int type;
        public bool isVisible;

        public Enemy(Texture2D newTexture, Vector2 newPosition, ContentManager Content, int hp, int kind)
        {
            hitPoints = hp;
            type = kind;
            isVisible = true;

        }

        public int getHP()
        {
            return hitPoints;
        }
        public void hpUpdate(int damageType)
        {
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
