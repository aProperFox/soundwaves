using System;
using System.Collections.Generic;
using System.Linq;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Soundwaves
{
    abstract class Player
    {
        private int charState = -1;
        private Texture2D myTexture;
        protected Texture2D head;
        public Vector2 spritePosition;
        protected Vector2 headPosition;
        protected ContentManager myContent;
        private Vector2 velocity;
        bool hasJumped;
        public Rectangle rectangle;

        public Player(Texture2D newTexture, Vector2 newPosition, ContentManager Content)
        {
            myContent = Content;

            myTexture = newTexture;
            spritePosition = newPosition;
            hasJumped = true;
        }


        public float getYPosition()
        {
            return spritePosition.Y;
        }

        public float getXPosition()
        {
            return spritePosition.X;
        }
        public Texture2D getMyTexture()
        {
            return myTexture;
        }
        public void incrementSpritePosition(float x, float y)
        {
            spritePosition.X += x;
            spritePosition.Y += y;

        }
        public void incrementVelocity(float x, float y)
        {
            velocity.X += x;
            velocity.Y += y;

        }
        public Vector2 getVelocity()
        {
            return velocity;
        }

        public bool getHasJumped()
        {
            return hasJumped;
        }
        public void setHasJumped(bool foo)
        {
            hasJumped = foo;
        }

        public float getXVelocity()
        {
            return velocity.X;
        }
        public float getYVelocity()
        {
            return velocity.Y;
        }
        public void setXVelocity(float x)
        {
            velocity.X = x;
        }
        public void setYVelocity(float y)
        {
            velocity.Y = y;
        }
        public Vector2 getSpritePosition()
        {
            return spritePosition;
        }

        public void setSpritePosition(Vector2 pos)
        {
            spritePosition = pos;
        }

        public int getCharState()
        {
            return charState;
        }
        public void setCharState(String state)
        {
            myTexture = myContent.Load<Texture2D>(state);
        }

        public string getNewTexture()
        {

            if (charState == 0)
                return "chac1";
            else if (charState == 1)
                return "right";
            else if (charState == 2)
                return "left";
            else
                return "chac1";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //  string temp = getNewTexture();
            // myTexture = myContent.Load<Texture2D>(temp);
            spriteBatch.Draw(myTexture, spritePosition, Color.White);
        }
        public void DrawHead(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(head, headPosition, Color.White);
        }
        public SpriteBatch spriteBatch { get; set; }

    }



    class hero : Player
    {
        public string[] threeTypes = new string[3];
        int type = 0;
        public hero(Texture2D newTexture, Vector2 newPosition, ContentManager Content) :
            base(newTexture, newPosition, Content)
        {
            type = 0;
        }

        public void setHeight(float height)
        {
            spritePosition.Y = height - 72;

        }

        public void Update(GameTime gameTime)
        {
            rectangle = new Rectangle((int)spritePosition.X,
(int)spritePosition.Y, getMyTexture().Width / 2, getMyTexture().Height);
            incrementSpritePosition(getXVelocity(), getYVelocity());
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                setXVelocity(3f);
                headPosition.X = spritePosition.X + 10;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                setXVelocity(-3f);
                headPosition.X = spritePosition.X + 10;
            }
            else if (getHasJumped() == true)
            {
                headPosition.X = spritePosition.X + 5;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Tab))
            {
                type += 1;
                type = type % 4;
            }
            else
            {
                setXVelocity(0f);
                headPosition.X = spritePosition.X + 5;
            }

            headPosition.Y = spritePosition.Y;

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && getHasJumped() == false)
            {
                incrementSpritePosition(0, -10f);

                setYVelocity(-5f);
                setHasJumped(true);
            }

            float i = 1;
            incrementVelocity(0, (0.15f * i));

        }
        public void setHeadState(String state)
        {
            head = myContent.Load<Texture2D>(state);
        }
    }

}

