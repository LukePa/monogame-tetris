using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace tetris;

public class GameManager
{
    GameBoard _gameBoard = new GameBoard();
    public GameBoard gameBoard => _gameBoard;

    private Game _game;

    public GameManager(Game game)
    {
        _game = game;
    }

    public void Update(GameTime gameTime)
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            _game.Exit();
        }

        if (KeyUpController.HasKeyReleased(Keys.W))
        {
            _gameBoard.TryRotateActiveTetromino();
        }
    }
}
