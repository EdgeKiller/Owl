using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Owl.Framework
{
    public class Sprite
    {
        private Texture2D texture;
        private string texturePath;
        private Vector2 position;
        private GraphicsDeviceManager gdm;

        public Sprite(string texturePath, Vector2 position)
        {
            this.texturePath = "Resources/Textures/" + texturePath;
            this.position = position;
        }

        public void Load(GraphicsDeviceManager graphicsDeviceManager)
        {
            gdm = graphicsDeviceManager;
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

        //  Position
        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }
        public void SetPosition(float x, float y)
        {
            this.position = new Vector2(x, y);
        }
        public void SetPositionX(float x)
        {
            this.position.X = x;
        }
        public void SetPositionY(float y)
        {
            this.position.Y = y;
        }
        public void AddPosition(Vector2 position)
        {
            this.position += position;
        }
        public void AddPosition(float x, float y)
        {
            this.position += new Vector2(x,y);
        }
        public void AddPositionX(float x)
        {
            this.position.X += x;
        }
        public void AddPositionY(float y)
        {
            this.position.Y += y;
        }
        public Vector2 GetPosition()
        {
            return this.position;
        }

        // Texture
        public void SetTexture(string texturePath)
        {
            this.texturePath = "Resources/Textures/" + texturePath;
            this.Load(gdm);
        }
        public Texture2D GetTexture()
        {
            return this.texture;
        }
        public string GetTextureName()
        {
            return this.texturePath.Replace("Resources/Textures/", "");
        }
        public string GetTexturePath()
        {
            return this.texturePath;
        }


    }
}
