using Entities.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer_Mario.Entities.Player;
using Platformer_Mario.Managers;

namespace Platformer__Mario;

// on spawn up, map sprite is outside of preferred window boundary.
// Main character sprite too small.
public class Game1 : Game
{
	private GraphicsDeviceManager _graphics;
	private SpriteBatch _spriteBatch;

	// Player sprite class.
	private Player _player;

	// Heart Class - Lives
	private Heart _heart;
	private Texture2D _heart_texture;

	// Pre-load all player animation
	private Texture2D _idle_sheet;
	private Texture2D _run_right_sheet;
	private Texture2D _dead_sheet;
	private Texture2D _jump_all_sheet;
	private Texture2D _run_left_sheet;
	private Texture2D _fall_sheet;
	private Texture2D _attack_right;

	// Resolution size - Static
	public static int _screen_height = 600;
	public static int _screen_width = 900;

	// Player camera
	private Camera _camera;

	// Map sprite
	private Texture2D _map;

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

		_graphics.PreferredBackBufferWidth = _screen_width;
		_graphics.PreferredBackBufferHeight = _screen_height;

		_graphics.ApplyChanges();

		// Initialize camera with screen dimension.
		_camera = new Camera(_screen_width, _screen_height);

		base.Initialize();
	}

	// Load your game content. Called once per game. - Before main game loop starts.
	protected override void LoadContent()
	{
		_spriteBatch = new SpriteBatch(GraphicsDevice);

		// TODO: use this.Content to load your game content here

		// Load all the textures for different animation.
		_idle_sheet = Content.Load<Texture2D>("Idle-Sheet");
		_run_left_sheet = Content.Load<Texture2D>("Run-Left-Sheet");
		_jump_all_sheet = Content.Load<Texture2D>("Jump-All-Sheet");
		_fall_sheet = Content.Load<Texture2D>("Fall-Sheet");
		_run_right_sheet = Content.Load<Texture2D>("Run-Sheet");
		_dead_sheet = Content.Load<Texture2D>("Dead-Sheet");
		_attack_right = Content.Load<Texture2D>("Attack-right");

		// Create animation based on texture
		SpriteSheetAnimation idle = new SpriteSheetAnimation(_idle_sheet, 4, 0.1f);
		SpriteSheetAnimation run_left = new SpriteSheetAnimation(_run_left_sheet, 8, 0.1f);
		SpriteSheetAnimation jump = new SpriteSheetAnimation(_jump_all_sheet, 15, 0.1f);
		SpriteSheetAnimation fall = new SpriteSheetAnimation(_fall_sheet, 3, 0.1f);
		SpriteSheetAnimation run_right = new SpriteSheetAnimation(_run_right_sheet, 8, 0.1f);
		SpriteSheetAnimation dead = new SpriteSheetAnimation(_dead_sheet, 8, 0.1f);
		SpriteSheetAnimation attack_right = new SpriteSheetAnimation(_attack_right, 8, 0.1f);

		// Heart - Num of lives
		_heart_texture = Content.Load<Texture2D>("Heart");
		SpriteSheetAnimation heart_anim = new SpriteSheetAnimation(_heart_texture, 8, 0.1f);
		_heart = new Heart(heart_anim, _heart_texture);

		// Map texture
		_map = Content.Load<Texture2D>("map");

		// var player_sprite = Content.Load<Texture2D>("Run-Sheet");					// Locate player.png at sprite folder.
		var player_initial_pos = new Vector2(100, 200);									// Initial position.
		
		_player = new Player(idle, run_left, jump, fall, run_right, dead, attack_right,player_initial_pos);
	}

	protected override void Update(GameTime gameTime)
	{
		if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			Exit();

		// TODO: Add your update logic here
		_player.Update(gameTime);

		// Heart - Lives update for animation
		_heart.Update(gameTime);

		// Update camera
		_camera.Follow(_player.player_position);

		base.Update(gameTime);
	}

	protected override void Draw(GameTime gameTime)
	{
		GraphicsDevice.Clear(Color.CornflowerBlue);

		// TODO: Add your drawing code here
		_spriteBatch.Begin(transformMatrix: _camera.Transform);

		// Draws the map
		// 0, -400 starts at the platform at the bottom.
		_spriteBatch.Draw(_map, new Vector2(0, -400), Color.White);

		// Draw Heart - Lives
		_heart.Draw(_spriteBatch);

		// Draw player class.
		_player.Draw(_spriteBatch);

		_spriteBatch.End();
		base.Draw(gameTime);
	}
}
