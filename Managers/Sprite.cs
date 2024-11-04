using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer_Mario.Managers;

public class Sprite : Component
{
    protected Texture2D _texture;
    public Vector2 Position { get; set; }


    public Rectangle Rectangle
    {
        get { return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height); }
    }

    public override void Draw(GameTime game_time, SpriteBatch sprite_batch)
	{
        sprite_batch.Draw(_texture, Position, Color.White);
	}

	public override void Update(GameTime game_time)
	{

	}
}