using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer_Mario.Managers;

namespace Entities.Player;

public class Player
{
    private Texture2D _player_sprite;
    private Vector2 _player_position;

    private readonly SpriteSheetAnimation _animation;
    public Player(Texture2D sprite, Vector2 initial_position)
    {
        _player_sprite = sprite;

        // For now, set initial position to 100, 200
        _player_position = initial_position;

        // Call the animation class.
        // Test animation class. Testing idle-sheet.png animation. Need to change based on different animation state.
        _animation = new(_player_sprite, 8, 0.1f);
    }
    
    public void Update(GameTime game_time)
    {
        _animation.Update(game_time);
	}

    // Controls moving the player sprite. - Movement update function.
    public void Movement()
    {
        KeyboardState kb_state = Keyboard.GetState();

        // Move sprite based on keyboard presses.
        if (kb_state.IsKeyDown(Keys.Up))
            _player_position.Y -= 10;               // Temporary for jump. Will fix this when implementing jump to get burst of movement.
		
        if (kb_state.IsKeyDown(Keys.Down))
			_player_position.Y += 10;               // Temporary for fall. There is no jump down. Will fix this when gravity is implemented.
		
        if (kb_state.IsKeyDown(Keys.Left))
			_player_position.X -= 10;               // Move left at fixed speed. Will tweak this.
		
        if (kb_state.IsKeyDown(Keys.Right))
			_player_position.X += 10;               // Move right at fixed speed. Will tweak this.

	}

	public void Draw(SpriteBatch sprite_batch)
    {
        // Draws the entire sprite sheet for testing purposes.
        // sprite_batch.Draw(_player_sprite, _player_position, Color.White);

        _animation.Draw(sprite_batch, _player_position);
    }
}