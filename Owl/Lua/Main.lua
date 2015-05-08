import ('Microsoft.Xna.Framework')
import ('Microsoft.Xna.Framework.Graphics')
import ('Microsoft.Xna.Framework.Input')
import ('MonoGame.Framework')
import ('Owl', 'Owl.Framework')

--[[ Global variables :
	spriteBatch -> Default SpriteBatch
	graphics -> Default GraphicsDeviceManager
	content -> Default ContentManager
	game -> Default Game
--]]

local owl = Sprite("logo_32.png", Vector2(42,42))
local spSpeed = 2

function Init()
	game.Window.Title = "Example Game"
	game.IsMouseVisible = true
end

function Load()
	owl:Load(graphics)
end

function Unload()

end

cPressed = false

function Update(gameTime, keyboard, mouse)

	if(keyboard:IsKeyDown(Keys.Up)) then owl:AddPositionY(-spSpeed) end
	if(keyboard:IsKeyDown(Keys.Down)) then	owl:AddPositionY(spSpeed) end
	if(keyboard:IsKeyDown(Keys.Left)) then	owl:AddPositionX(-spSpeed) end
	if(keyboard:IsKeyDown(Keys.Right)) then	owl:AddPositionX(spSpeed) end
	
	
	if(keyboard:IsKeyDown(Keys.C)) then 
		if(cPressed == false) then
			if(owl:GetTextureName() == "logo_32.png") then
				owl:SetTexture("logo_512.png")
			else
				owl:SetTexture("logo_32.png")
			end
		end
		cPressed = true
	else
		cPressed = false
	end
	
end

function Draw(gameTime)
	spriteBatch:Begin()
	--owl:Draw(spriteBatch)
	spriteBatch:Draw(owl:GetTexture(), owl:GetPosition(), Color.White)
	spriteBatch:End()
end