using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Core.Graphics;
using MonoGame_Pikachu.Core.Input;
using MonoGame_Pikachu.Extensions;
using MonoGame_Pikachu.Factories;
using MonoGame_Pikachu.Objects;
using MonoGame_Pikachu.Objects.Base;
using MonoGame_Pikachu.States;
using MonoGame_Pikachu.States.Base;
using System;
using System.Collections.Generic;

namespace MonoGame_Pikachu
{
    // Ik heb mogelijke TODO's toegevoegd die het spel interessanter kunnen maken. Deze zijn vrijblijvend, maar aangeraden. 
    public class Game1 : Game
    {
        // Constants for game configuration
        public const int SHARK_SPAWN_TIME_IN_MS = 3000;

        public const int PLAYER_SPEED = 5;
        public const float PLAYER_SCALE = 0.5F;

        public const int SHARK_SPEED = 2;
        public const float SHARK_SCALE = 0.25F;

        public const int BACKGROUND_SPEED = 2;
        public const float BACKGROUND_SCALE = 0.25F;

        // We houden bij welke staat de huidige is. Afhankeliujk van de staat, zullen we andere dingen doen in de update en draw methodes.
        private AbstractState _currentState;

        // We willen iedere 3 seconden een nieuwe haai, hiervoor moeten wij bijhouden hoeveel tijd er is verstreken sinds de laatste haai is gespawned. Hiervoor gebruiken wij deze variabele.
        private double _elapsedTimeForSpawnIsMs;
        public double ElapsedTimeForSpawnIsMs
        {
            get => _elapsedTimeForSpawnIsMs;
            set => _elapsedTimeForSpawnIsMs = value;
        }

        private SpriteBatch _spriteBatch;

        private SpriteFont _spriteFont;
        public SpriteFont SpriteFont
            => _spriteFont;

        public Texture2D _playerTexture;
        public PlayerSprite _playerSprite;

        public List<EnemySprite> _enemySprites;

        public Texture2D _sharkTexture;
        //public Texture2D SharkTexture
        //    => _sharkTexture;
        //private List<Vector2> _enemyPositions;
        //public List<Vector2> EnemyPositions
        //{
        //    get => _enemyPositions;
        //    set => _enemyPositions = value;
        //}

        private Texture2D _backgroundTexture;
        public Texture2D BackgroundTexture
            => _backgroundTexture;
        private Vector2 _backgroundPosition;
        public Vector2 BackgroundPosition
        {
            get => _backgroundPosition;
            set => _backgroundPosition = value;
        }

        public void ChangeState(AbstractState newActiveState)
        {
            _currentState = newActiveState;
        }

        public Game1()
        {
            GraphicsFacade.Initialize(this, width: 768, height: 540);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _currentState = new MenuState(this);

            _elapsedTimeForSpawnIsMs = 0;

            _backgroundPosition = new Vector2(0, 0);
            _enemySprites = new List<EnemySprite>();

            // LoadContent wordt hierin opgeroepen.
            base.Initialize();
            
            // Dit moet na LoadContent want we hebben de texture nodig
            _playerSprite = SpriteFactory.CreatePlayerInVerticalCenter(_playerTexture, PLAYER_SCALE);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: Maak hiervan een manager die alles inlaadt wanneer het nodig is en die je kan meegeven bij create van sprites via de factory. 
            _spriteFont = Content.Load<SpriteFont>("game-font");
            _playerTexture = Content.Load<Texture2D>("surfing-pikachu");
            _sharkTexture = Content.Load<Texture2D>("haai");
            _backgroundTexture = Content.Load<Texture2D>("water");

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardFacade.UpdateState();

            _currentState.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // TODO: Afhankelijk van het aantal haaien die onze speler voorbij is zouden we de clear kleur kunnen aanpassen, zo wordt het spel steeds donkerder naarmate je meer haaien voorbij bent. Nu is de clear kleur altijd hetzelfde.
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            
            _currentState.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
