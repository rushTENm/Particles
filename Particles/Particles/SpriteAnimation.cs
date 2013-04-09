using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Particles
{
    class SpriteAnimation
    {
        Texture2D Texture;

        Vector2 m_Position;

        int m_FrameCounter = 0;
        int m_WaitCounter = 0;

        int m_Width;
        int m_Height;

        int rowPositon;
        int columnPositon;
        int m_Column;

        int m_LastFrame;
        int m_Wait;

        float m_Scale;

        public void Init(ContentManager content, string address, Vector2 position, int row, int column, int lastFrame, int wait, float scale)
        {
            Texture = content.Load<Texture2D>(address);

            m_Position = position;

            m_Width = Texture.Width / column;
            m_Height = Texture.Height / row;

            m_Column = column;

            m_LastFrame = lastFrame;
            m_Wait = wait;

            m_Scale = scale;
        }

        public void Update()
        {
            if (m_WaitCounter % m_Wait == 0)
            {
                if (m_FrameCounter > m_LastFrame)
                {
                    m_FrameCounter = 0;
                    m_WaitCounter = 0;
                }
                m_FrameCounter++;
            }
            m_WaitCounter++;

            rowPositon = m_FrameCounter / m_Column;
            columnPositon = m_FrameCounter % m_Column;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(Texture, m_Position, new Rectangle(columnPositon * m_Width, rowPositon * m_Height, m_Width, m_Height), Color.White, 0.0f, Vector2.Zero, m_Scale, SpriteEffects.None, 0);

            spriteBatch.End();
        }
    }
}
