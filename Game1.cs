using Entities.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Platformer__Mario;
public class Game1 : Game
{
	private GraphicsDeviceManager _graphics;
	private SpriteBatch _spriteBatch;

	// Player sprite class.
	private Player _player;

	public Game1()
	{
		_graphics = new GraphicsDeviceManager(this);
		Content.RootDirectory = "Content";
		IsMouseVisible = true;
	}

	// Load any non graphic related content.
	protected override void Initialize()
	{
		// TODO: Add your initialization logic here
		_graphics.IsFullScreen = false;
		_graphics.PreferredBackBufferWidth = 1366;
		_graphics.PreferredBackBufferHeight = 768;
		_graphics.ApplyChanges();

		base.Initialize();
	}

	// Load your game content. Called once per game. - Before main game loop starts.
	protected override void LoadContent()
	{
		_spriteBatch = new SpriteBatch(GraphicsDevice);

		// TODO: use this.Content to load your game content here
		var player_sprite = Content.Load<Texture2D>("player"); // Locate player.png at sprite folder.
		var player_initial_pos = new Vector2(100, 200);                            // Initial position.
		
		_player = new Player(player_sprite, player_initial_pos);
	}

	protected override void Update(GameTime gameTime)
	{
		if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			Exit();

		// TODO: Add your update logic here

		base.Update(gameTime);
	}

	protected override void Draw(GameTime gameTime)
	{
		GraphicsDevice.Clear(Color.CornflowerBlue);

		// TODO: Add your drawing code here
		_spriteBatch.Begin();

		_player.Draw(_spriteBatch);

		_spriteBatch.End();
		base.Draw(gameTime);
	}
}
