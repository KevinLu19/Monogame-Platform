using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer_Mario.Managers;

namespace Platformer_Mario.Entities.Player;

public class Heart : Sprite
{
    private readonly int _max_lives;
    private SpriteSheetAnimation _animation;
    private Vector2 _heart_position;

    public Texture2D heart_texture;

    public Heart(SpriteSheetAnimation heart_animation, Texture2D heart_text)
    {
        heart_texture = heart_text;
        _max_lives = 5;

        _heart_position = new Vector2(100, 0);

        _animation = heart_animation;
    }

    public void Update(GameTime game_time)
    {
        _animation.Update(game_time);
    }

    public void Draw(SpriteBatch sprite_batch)
    {
        sprite_batch.Draw(heart_texture, _heart_position, Color.White);
    }
}