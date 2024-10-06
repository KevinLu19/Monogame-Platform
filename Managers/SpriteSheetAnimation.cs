using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Platformer_Mario.Managers;

public class SpriteSheetAnimation
{
    private readonly Texture2D _texture;
    private readonly List<Rectangle> _list_source_rectangle = new();
    private readonly int _frames;
    private int _frame;
    private readonly float _frame_time;
    private float _frame_time_left;
    private bool _active = true;

    public SpriteSheetAnimation(Texture2D texutre, int frame_x, float frame_time)
    {
        _texture = texutre;
        _frame_time = frame_time;
        _frames = frame_x;

        var frame_width = _texture.Width / frame_x;
        var frame_height = _texture.Height;

        // Loop through framex and store source rectangle.
        for (int i = 0; i < frame_x; i++)
        {
            _list_source_rectangle.Add(new(i * frame_width, 0, frame_width, frame_height));
        }
    }

	public void StopAnimation()
	{
		_active = false;
	}

	public void StartAnimation()
	{
		_active = true;
	}

	public void Reset()
	{
		_frame = 0;
		_frame_time_left = _frame_time;
	}

    // Process the frame time and when it is ready, will display it
    public void Update(GameTime game_time)
    {
        if (!_active) return;

        _frame_time_left -= (float) game_time.ElapsedGameTime.TotalSeconds;

        if (_frame_time_left <= 0)
        {
            _frame_time_left += _frame_time;
            _frame = (_frame + 1) % _frames;
        }
    }

    public void Draw(SpriteBatch sprite_batch, Vector2 pos)
    {
        sprite_batch.Draw(_texture, pos, _list_source_rectangle[_frame], Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 1);
    }
}