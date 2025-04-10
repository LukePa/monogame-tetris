﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tetris;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private Renderer renderer;


    private GameManager gameManager;

    

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = 1600;
        _graphics.PreferredBackBufferHeight = 900;
        _graphics.IsFullScreen = false;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        gameManager = new GameManager(this);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        renderer = new Renderer(GraphicsDevice, Content);
    }

    protected override void Update(GameTime gameTime)
    {
        gameManager.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        renderer.Render(gameManager);
        base.Draw(gameTime);
    }
}
