using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NLua;
/*
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Utilities;
*/

namespace Owl
{
    public class GameMain : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Lua lua = new Lua();
        LuaFunction luaInit, luaLoad, luaUnload, luaUpdate, luaDraw;

        public GameMain()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            lua.LoadCLRPackage();
            lua["spriteBatch"] = spriteBatch;
            lua["graphics"] = graphics;
            lua["content"] = Content;
            lua["game"] = this;
            lua.DoFile("Lua/Main.lua");
            luaInit = lua["Init"] as LuaFunction;
            luaLoad = lua["Load"] as LuaFunction;
            luaUnload = lua["Unload"] as LuaFunction;
            luaUpdate = lua["Update"] as LuaFunction;
            luaDraw = lua["Draw"] as LuaFunction;
            luaInit.Call();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            luaLoad.Call();
        }

        protected override void UnloadContent()
        {
            luaUnload.Call();
        }

        protected override void Update(GameTime gameTime)
        {
            luaUpdate.Call(gameTime, Keyboard.GetState(), Mouse.GetState());
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            luaDraw.Call(gameTime);
            base.Draw(gameTime);
        }
    }
}
