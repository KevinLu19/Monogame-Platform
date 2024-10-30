using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer_Mario.Managers;

public abstract class Component
{
	public abstract void Draw(GameTime game_time, SpriteBatch sprte_batch);

	public abstract void Update(GameTime game_time);
}