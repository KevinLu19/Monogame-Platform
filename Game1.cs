using Entities.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Platformer__Mario;
public class Game1 : Game
{
	private GraphicsDeviceManager _graphics;
	private SpriteBatch _spriteBatch;

	// Player sprite class.
	private Player _player;

	// Pre-load all player animation
	private Texture2D _idle_sheet;
	private Texture2D _run_right_sheet;
	private Texture2D _dead_sheet;
	private Texture2D _jump_all_sheet;
	private Texture2D _run_left_sheet;
	private Texture2D _fall_sheet;


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
		// Reso size: 1366 x 768 - Average laptop size.
		/*_graphics.PreferredBackBufferWidth = 1366;
		_graphics.PreferredBackBufferHeight = 768;*/

		// Smaller reso size: 640 x 480
		_graphics.PreferredBackBufferWidth = 640;
		_graphics.PreferredBackBufferHeight = 480;

		_graphics.ApplyChanges();

		base.Initialize();
	}

	// Load your game content. Called once per game. - Before main game loop starts.
	protected override void LoadContent()
	{
		_spriteBatch = new SpriteBatch(GraphicsDevice);

		// TODO: use this.Content to load your game content here

		// Pre-load all charcter animations into player class.
		/*List<Texture2D> list_player_animations = new List<Texture2D> 
		{
			Content.Load<Texture2D>("Idle-Sheet"),
			Content.Load<Texture2D>("Run-Left-Sheet"),
			Content.Load<Texture2D>("Jump-All-Sheet"),
			Content.Load<Texture2D>("Fall-Sheet"),
			Content.Load<Texture2D>("Run-Sheet"),
			Content.Load<Texture2D>("Dead-Sheet"),
		} ;*/

		_idle_sheet = Content.Load<Texture2D>("Idle-Sheet");
		_run_left_sheet = Content.Load<Texture2D>("Run-Left-Sheet");
		_jump_all_sheet = Content.Load<Texture2D>("Jump-All-Sheet");
		_fall_sheet = Content.Load<Texture2D>("Fall-Sheet");
		_run_right_sheet = Content.Load<Texture2D>("Run-Sheet");
		_dead_sheet = Content.Load<Texture2D>("Dead-Sheet");

		// var player_sprite = Content.Load<Texture2D>("Run-Sheet");					// Locate player.png at sprite folder.
		var player_initial_pos = new Vector2(100, 200);                            // Initial position.
		
		_player = new Player(_idle_sheet, _run_left_sheet, _jump_all_sheet, _fall_sheet, _run_right_sheet, _dead_sheet, player_initial_pos);
	}

	protected override void Update(GameTime gameTime)
	{
		if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			Exit();

		// TODO: Add your update logic here
		_player.Movement();
		_player.Update(gameTime);

		base.Update(gameTime);
	}

	protected override void Draw(GameTime gameTime)
	{
		GraphicsDevice.Clear(Color.CornflowerBlue);

		// TODO: Add your drawing code here
		_spriteBatch.Begin();

		// Draw player class.
		_player.Draw(_spriteBatch);

		_spriteBatch.End();
		base.Draw(gameTime);
	}
}
