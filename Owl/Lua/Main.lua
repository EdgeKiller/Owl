import ('Microsoft.Xna.Framework')
import ('Microsoft.Xna.Framework.Graphics')
import ('Microsoft.Xna.Framework.Input')
import ('MonoGame.Framework')
import ('Owl')

local pos = Vector2(50,50)
local sp = Sprite("logo_512.png", pos)

function Init()

end

function Load()
	sp:Load(graphics)
end

function Unload()

end

function Update(gameTime)

end

function Draw(gameTime)
	spriteBatch:Begin()
	sp:Draw(spriteBatch)
	spriteBatch:End()
end