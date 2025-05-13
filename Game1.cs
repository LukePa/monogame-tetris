
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tetris;

public class Game1 : Game
{
    
    public Game1()
    {
        var graphicsDeviceManager = new GraphicsDeviceManager(this);
        graphicsDeviceManager.PreferredBackBufferWidth = 1600;
        graphicsDeviceManager.PreferredBackBufferHeight = 900;
        graphicsDeviceManager.IsFullScreen = false;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        GlobalGameStateController.SetGame(this);
    }

    protected override void Initialize()
    {
        GlobalGameStateController.SetStartingGameState();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        Textures.LoadTextures(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        GlobalGameStateController.GetCurrentGameState().Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GlobalGameStateController.GetCurrentGameState().Render();
        base.Draw(gameTime);
    }
}
