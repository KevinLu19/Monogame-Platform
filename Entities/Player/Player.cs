using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;

namespace Entities.Player;

public class Player
{
    private Texture2D _player_sprite;
    private Vector2 _player_position;
    public Player(Texture2D sprite, Vector2 initial_position)
    {
        _player_sprite = sprite;

        // For now, set initial position to 100, 200
        _player_position = initial_position;
    }
    
    public void UpdatePosition(float x, float y)
    {

    }

    public void Draw(SpriteBatch sprite_batch)
    {
        sprite_batch.Draw(_player_sprite, _player_position, Color.White);
    }
}
