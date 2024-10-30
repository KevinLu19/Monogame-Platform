using Microsoft.Xna.Framework;

namespace Platformer_Mario.Managers;

public class Camera
{
    public Matrix Transform { get; private set; }
    private int _view_width;
    private int _view_height;
    private Vector2 _position;

    public Camera(int view_width, int view_height)
    {
        _view_width = view_width;
        _view_height = view_height;
        _position = Vector2.Zero;
    }

    // Parameter takes base sprite - Need to create this. 
    public void Follow(Vector2 player_position)
    {
        // Center camera on sprites position (player)
        _position = new Vector2(
            player_position.X - _view_width / 2,
            player_position.Y - _view_height / 2
            );

        // Update transform matrix
        Transform = Matrix.CreateTranslation(-_position.X, -_position.Y, 0);
    }
}