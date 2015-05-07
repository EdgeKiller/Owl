import ('Microsoft.Xna.Framework')
import ('Microsoft.Xna.Framework.Graphics')
import ('Microsoft.Xna.Framework.Input')
import ('MonoGame.Framework')
import ('Owl')

--[[ Global variables :
	spriteBatch -> Default SpriteBatch
	graphics -> Default GraphicsDeviceManager
	content -> Default ContentManager
	game -> Default Game
--]]

local sp = Sprite("logo_32.png", Vector2(50,50))
local spSpeed = 2

function Init()
	game.Window.Title = "Example Game"
end

function Load()
	sp:Load(graphics)
end

function Unload()

end

function Update(gameTime, keyboard, mouse)
		
	if(keyboard:IsKeyDown(Keys.Z)) then
		sp:SetPosition(sp:GetPosition().X, sp:GetPosition().Y - spSpeed)
	end
	
	if(keyboard:IsKeyDown(Keys.S)) then
		sp:SetPosition(sp:GetPosition().X, sp:GetPosition().Y + spSpeed)
	end
	
	if(keyboard:IsKeyDown(Keys.Q)) then
		sp:SetPosition(sp:GetPosition().X - spSpeed, sp:GetPosition().Y)
	end
	
	if(keyboard:IsKeyDown(Keys.D)) then
		sp:SetPosition(sp:GetPosition().X + spSpeed, sp:GetPosition().Y)
	end
		
end

function Draw(gameTime)
	spriteBatch:Begin()
	sp:Draw(spriteBatch)
	spriteBatch:End()
end