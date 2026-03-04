using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Extensions;
using System;
using System.Collections.Generic;

namespace MonoGame_Pikachu
{
    // Ik heb mogelijke TODO's toegevoegd die het spel interessanter kunnen maken. Deze zijn vrijblijvend, maar aangeraden. 
    public class Game1 : Game
    {
        public enum States
        {
            Menu,
            Play,
            Pause,
            GameOver
        }

        // Constants for game configuration
        private const int SHARK_SPAWN_TIME_IN_MS = 3000;

        private const int PLAYER_SPEED = 5;
        private const float PLAYER_SCALE = 0.5F;

        private const int SHARK_SPEED = 2;
        private const float SHARK_SCALE = 0.25F;

        private const int BACKGROUND_SPEED = 2;
        private const float BACKGROUND_SCALE = 0.25F;

        // We houden bij welke staat de huidige is. Afhankeliujk van de staat, zullen we andere dingen doen in de update en draw methodes.
        private States _currentState;

        // We willen iedere 3 seconden een nieuwe haai, hiervoor moeten wij bijhouden hoeveel tijd er is verstreken sinds de laatste haai is gespawned. Hiervoor gebruiken wij deze variabele.
        private double _elapsedTimeForSpawn;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont _spriteFont;

        private Texture2D _pikachuTexture;
        private Vector2 _pikachuPosition;

        private Texture2D _sharkTexture;
        private List<Vector2> _sharkPositions;

        private Texture2D _backgroundTexture;
        private Vector2 _backgroundPosition;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferHeight = 540;
            _graphics.PreferredBackBufferWidth = 768;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            _currentState = States.Menu;

            _elapsedTimeForSpawn = 0;

            _pikachuPosition = new Vector2(0, _graphics.PreferredBackBufferHeight / 2);
            _backgroundPosition = new Vector2(0, 0);
            _sharkPositions = new List<Vector2>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _spriteFont = Content.Load<SpriteFont>("game-font");
            _pikachuTexture = Content.Load<Texture2D>("surfing-pikachu");
            _sharkTexture = Content.Load<Texture2D>("haai");
            _backgroundTexture = Content.Load<Texture2D>("water");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Afhankelijk van de huidige staat, willen we andere dingen doen in de update methode.
            // Daarom gebruiken we een if statement om te checken in welke staat we zitten.
            if (_currentState == States.Menu)
            {
                if (IsKeyDown(Keys.Enter))
                    _currentState = States.Play;
            }
            else if (_currentState == States.Play)
            {
                // TODO: Controlleer of de speler een haai aanraakt. Indien 'ja', ga naar de GameOver staat.

                UpdateBackgroundPosition();
                UpdatePlayerPosition();

                // TODO: Er is nog geen limiet aan het aantal haaien dat kan spawnen. Voeg een limiet toe van 8 haaien tegelijk.
                _elapsedTimeForSpawn += gameTime.ElapsedGameTime.TotalMilliseconds;
                if (_elapsedTimeForSpawn >= SHARK_SPAWN_TIME_IN_MS)
                {
                    // TODO: Geef een haai ook verschillende snelheden, nu hebben alle haaien dezelfde snelheid (wat het speelveld saai maakt). Je kan bijvoorbeeld een random snelheid geven tussen de 1 en 3.
                    // TODO: Spawn elke haai op een random hoogte, nu spawnen ze altijd in het midden van het scherm.
                    _sharkPositions.Add(new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight / 2));
                    _elapsedTimeForSpawn = 0;
                }

                for (var i = 0; i < _sharkPositions.Count; i++)
                    _sharkPositions[i] = new Vector2(_sharkPositions[i].X - SHARK_SPEED, _sharkPositions[i].Y);
                
                // TODO: Als een haai links uit beeld is, dan mag deze uit de lijst. Nu blijven de haaien oneindig in de lijst staan, ook al zijn ze al lang uit beeld.

                if (IsKeyDown(Keys.P))
                    _currentState = States.Pause;
            }
            else if (_currentState == States.Pause)
            {
                if (IsKeyDown(Keys.Enter))
                    _currentState = States.Play;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // TODO: Afhankelijk van het aantal haaien die onze speler voorbij is zouden we de clear kleur kunnen aanpassen, zo wordt het spel steeds donkerder naarmate je meer haaien voorbij bent. Nu is de clear kleur altijd hetzelfde.
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // Afhankelijk van de huidige staat, willen we andere dingen tekenen in de draw methode.
            if (_currentState == States.Menu)
            {
                // TODO: We zouden de tekst kunnen ophalen uit een bestand, in plaats van dat deze hardcoded is in de code. Dit zou het makkelijker maken om de tekst aan te passen, zonder dat je de code moet aanpassen. Alsook zou je zo meerdere talen kunnen ondersteunen
                // TODO: Voorzien een extension methode waarvoor we geen kleur moeten meegeven
                // TODO: 'Teken' de tekst in het center van het scherm ipv op 0,0
                _spriteBatch.DrawString(_spriteFont, "Druk op enter om te beginnen", Vector2.Zero, Color.White);
            }
            else if (_currentState == States.Play || _currentState == States.Pause) // Bij de staat 'Pause' willen we de huidige wereld staat laten zien, met een pauze boodschap erbij
            {
                _spriteBatch.Draw(_backgroundTexture, _backgroundPosition, BACKGROUND_SCALE);

                // TODO: We zouden bij het spawned van de haaien een bepaalde random scale kunnen geven aan een specifieke haai, zo zien sommige er groter uit dan anderen. Dit zou het speelveld interessanter maken. Nu hebben alle haaien dezelfde grootte.
                foreach (var sharkPosition in _sharkPositions)
                    _spriteBatch.Draw(_sharkTexture, sharkPosition, SHARK_SCALE);

                _spriteBatch.Draw(_pikachuTexture, _pikachuPosition, PLAYER_SCALE);

                if ( _currentState == States.Pause)
                    // TODO: We zouden de tekst kunnen ophalen uit een bestand, in plaats van dat deze hardcoded is in de code. Dit zou het makkelijker maken om de tekst aan te passen, zonder dat je de code moet aanpassen. Alsook zou je zo meerdere talen kunnen ondersteunen
                    _spriteBatch.DrawString(_spriteFont, "Pause. Druk op enter om door te doen", Vector2.Zero, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void UpdateBackgroundPosition()
        {
            _backgroundPosition.X -= BACKGROUND_SPEED;
        }

        private void UpdatePlayerPosition()
        {
            // TODO: We zouden deze toetsen kunnen uitlezen uit een bestand (denk aan wat jullie bij programmeren gedaan hebben). Dit zou het makkelijker maken om de controls aan te passen, zonder dat je de code moet aanpassen. Nu zijn de controls hardcoded in de code.
            if (IsKeyDown(Keys.Right, Keys.D))
                _pikachuPosition.X += PLAYER_SPEED;

            if (IsKeyDown(Keys.Left, Keys.Q))
                _pikachuPosition.X -= PLAYER_SPEED;

            if (IsKeyDown(Keys.Up, Keys.Z))
                _pikachuPosition.Y -= PLAYER_SPEED;

            if (IsKeyDown(Keys.Down, Keys.S))
                _pikachuPosition.Y += PLAYER_SPEED;
        }

        private bool IsKeyDown(Keys key1, Keys key2)
            => IsKeyDown(key1) || IsKeyDown(key2);

        private bool IsKeyDown(Keys key)
            => Keyboard.GetState().IsKeyDown(key);

    }
}
