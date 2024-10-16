using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer_Mario.Managers;
using System.Collections.Generic;

namespace Entities.Player;

public class Player
{
    private Texture2D _player_sprite;
    private Vector2 _player_position;

    private SpriteSheetAnimation _animation;
    private Texture2D _player_animation_state;              // Used for game state.

    private List<Texture2D> _list_player_animation = new();

    // Variable for different states pre-loaded.
    private Texture2D _idle_state;
    private Texture2D _run_left_state;
    private Texture2D _jump_state;
    private Texture2D _fall_state;
    private Texture2D _run_right_state;
    private Texture2D _dead_state;
	public Player(Texture2D idle, Texture2D run_left, Texture2D jump, Texture2D fall, Texture2D run_right, 
        Texture2D dead, Vector2 initial_position)
    {
        _idle_state = idle;
        _run_left_state = run_left;
        _jump_state = jump;
        _fall_state = fall;
        _run_right_state = run_right;
        _dead_state = dead;

		// Initial state for the character is in idle mode or if no input it being pressed -> idle state.
		_animation = new(_idle_state, 4, 0.1f);

		//_list_player_animation = sprite;

		// _player_sprite = sprite;

		// For now, set initial position to 100, 200
		_player_position = initial_position;
    }
    

    public void Update(GameTime game_time)
    {
        _animation.Update(game_time);
	}

    // Controls moving the player sprite. - Movement update function.
    public void Movement()
    {
       /* 
            States:
            Idle state if no movement button is pressed. Run sprite sheet used for either left or right movement. 
            Jump sprite used for jumping and fall for fall movement.
        */

        KeyboardState kb_state = Keyboard.GetState();

		// Move sprite based on keyboard presses.
		if (kb_state.IsKeyDown(Keys.Up))
        {
            
            _player_position.Y -= 10;               // Temporary for jump. Will fix this when implementing jump to get burst of movement.
		}
            
		
        if (kb_state.IsKeyDown(Keys.Down))
        {
            _player_position.Y += 10;               // Temporary for fall. There is no jump down. Will fix this when gravity is implemented.
		}
		
        if (kb_state.IsKeyDown(Keys.Left))
        {
            
			_player_position.X -= 10;               // Move left at fixed speed. Will tweak this.
		}
		
        if (kb_state.IsKeyDown(Keys.Right))
        {
            
            _player_position.X += 10;               // Move right at fixed speed. Will tweak this.
		}
	}

	public void Draw(SpriteBatch sprite_batch)
    {
        // Draws the entire sprite sheet for testing purposes.
        // sprite_batch.Draw(_player_sprite, _player_position, Color.White);

        _animation.Draw(sprite_batch, _player_position);
    }
}