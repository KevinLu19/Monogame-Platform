using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer__Mario;
using Platformer_Mario.Entities.Player;
using Platformer_Mario.Managers;
using System.Collections.Generic;

namespace Entities.Player;

public class Player
{
    private Vector2 _player_position;

    private SpriteSheetAnimation _animation;
    private Texture2D _player_animation_state;              // Used for game state.

    private List<Texture2D> _list_player_animation = new();

    // Variable for different states pre-loaded.
    private SpriteSheetAnimation _idle_state;
    private SpriteSheetAnimation _run_left_state;
    private SpriteSheetAnimation _jump_state;
    private SpriteSheetAnimation _fall_state;
    private SpriteSheetAnimation _run_right_state;
    private SpriteSheetAnimation _dead_state;

    private SpriteSheetAnimation _current_animation;
    // All the possible character animation states
    private AnimationState _current_state;

    public Player(SpriteSheetAnimation idle, SpriteSheetAnimation run_left, SpriteSheetAnimation jump, SpriteSheetAnimation fall, SpriteSheetAnimation run_right,
		SpriteSheetAnimation dead, Vector2 initial_position)
    {
        _idle_state = idle;
        _run_left_state = run_left;
        _jump_state = jump;
        _fall_state = fall;
        _run_right_state = run_right;
        _dead_state = dead;

        // Default state for character.
        _current_state = AnimationState.Idle;
        _current_animation = _idle_state;

		// For now, set initial position to 100, 200
		_player_position = initial_position;
    }
    

    public void Update(GameTime game_time)
    {
		// Movement Function.

		// Need to default back to idle state when no keyboard movement button is pressed.

		KeyboardState kb_state = Keyboard.GetState();

		// Move sprite based on keyboard presses.
		if (kb_state.IsKeyDown(Keys.Up))
		{
			_current_state = AnimationState.Jump;
			_current_animation = _jump_state;
			_player_position.Y -= 10;               // Temporary for jump. Will fix this when implementing jump to get burst of movement.
		}

		else if (kb_state.IsKeyDown(Keys.Down))
		{
			_current_state = AnimationState.Fall;
			_current_animation = _fall_state;
			_player_position.Y += 10;               // Temporary for fall. There is no jump down. Will fix this when gravity is implemented.
		}

		else if (kb_state.IsKeyDown(Keys.Left))
		{
			_current_state = AnimationState.Run_Left;
			_current_animation = _run_left_state;
			_player_position.X -= 10;               // Move left at fixed speed. Will tweak this.
		}

		else if (kb_state.IsKeyDown(Keys.Right))
		{
			_current_state = AnimationState.Run_Right;
			_current_animation = _run_right_state;
			_player_position.X += 10;               // Move right at fixed speed. Will tweak this.
		}
		else
		{
			// Default state will be default.
			_current_state = AnimationState.Idle;
			_current_animation = _idle_state;
		}

		_current_animation.Update(game_time);
	}

	public void Draw(SpriteBatch sprite_batch)
    {
        // Draws the entire sprite sheet for testing purposes.
        // sprite_batch.Draw(_player_sprite, _player_position, Color.White);

        _current_animation.Draw(sprite_batch, _player_position);
    }
}