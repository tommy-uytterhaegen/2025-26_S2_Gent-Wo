using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Core.Assets;
using MonoGame_Pikachu.Core.Graphics;
using MonoGame_Pikachu.Core.Input;
using MonoGame_Pikachu.Objects;

namespace MonoGame_Pikachu
{
    // Ik heb mogelijke TODO's toegevoegd die het spel interessanter kunnen maken. Deze zijn vrijblijvend, maar aangeraden. 
    // Onthou ook dat alles wat je hier ziet 'een' oplossing is. Niet 'de' oplossing. Vele zaken hangen af van context en waar je met je design naartoe wil.
    public class Game1 : Game
    {

        private GameContext _gameContext;
   
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            GraphicsFacade.Initialize(this, width: 768, height: 540);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _gameContext = new GameContext(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardFacade.UpdateState();

            _gameContext.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // TODO: Afhankelijk van het aantal haaien die onze speler voorbij is zouden we de clear kleur kunnen aanpassen, zo wordt het spel steeds donkerder naarmate je meer haaien voorbij bent. Nu is de clear kleur altijd hetzelfde.
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _gameContext.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
