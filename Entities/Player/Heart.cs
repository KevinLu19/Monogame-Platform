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

    public Heart(SpriteSheetAnimation heart_anim ,Texture2D heart_text)
    {
        heart_texture = heart_text;
        _max_lives = 5;

        _heart_position = new Vector2(0, 0);

        _animation = heart_anim;
    }

    public override void Update(GameTime game_time)
    {
        _animation.Update(game_time);
    }

    public void Draw(SpriteBatch sprite_batch)
    {
        _animation.Draw(sprite_batch, _heart_position);
    }
}