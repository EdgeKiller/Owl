using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Owl
{
    public class Sprite
    {
        private Texture2D texture;
        private string texturePath;
        private Vector2 position;

        public Sprite(string texturePath, Vector2 position)
        {
            this.texturePath = "Resources/Textures/" + texturePath;
            this.position = position;
        }

        public void Load(GraphicsDeviceManager graphicsDeviceManager)
        {
            using(FileStream fs = new FileStream(this.texturePath, FileMode.Open))
            {
                this.texture = Texture2D.FromStream(graphicsDeviceManager.GraphicsDevice, fs);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);

            
        }

        // GET & SET
        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }
        public void SetPosition(float x, float y)
        {
            this.position = new Vector2(x, y);
        }
        public Vector2 GetPosition()
        {
            return this.position;
        }

        
    }
}
