using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace tetris;

public class GameManager
{
    GameBoard _gameBoard = new GameBoard();
    public GameBoard gameBoard => _gameBoard;
    public int CurrentLevel = 1;

    private Game _game;
    private double _timeSinceLastDrop = 0;

    public GameManager(Game game)
    {
        _game = game;
    }

    public void Update(GameTime gameTime)
    {
        HandleInput();
        HandleBlockDropLogic(gameTime.ElapsedGameTime.TotalSeconds);
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

        if (KeyUpController.HasKeyReleased(Keys.A))
        {
            _gameBoard.TryMoveActiveTetrominoLeft();
        }

        if (KeyUpController.HasKeyReleased(Keys.D))
        {
            _gameBoard.TryMoveActiveTetrominoRight();
        }
    }

    void HandleBlockDropLogic(double secondsSinceLastCall)
    {
        HandleIncrementTimeSinceLastDrop(secondsSinceLastCall);
        DropBlockIfShould();
    }

    void HandleIncrementTimeSinceLastDrop(double secondsSinceLastCall)
    {
        if (ShouldBlockBeFallingDoubleSpeed())
        {
            _timeSinceLastDrop += (secondsSinceLastCall * 2);
        }
        else
        {
            _timeSinceLastDrop += secondsSinceLastCall;
        }
    }

    bool ShouldBlockBeFallingDoubleSpeed()
    {
        return Keyboard.GetState().IsKeyDown(Keys.S);
    }

    void DropBlockIfShould()
    {
        if (_timeSinceLastDrop >= GetDropIntervalInSeconds())
        {
            _gameBoard.TryMoveActiveTetrominoDown();
            _timeSinceLastDrop = 0;
        }
    }
    
    double GetDropIntervalInSeconds()
    {
        return 1 / GetAmountBlockDropPerSecond();
    }

    double GetAmountBlockDropPerSecond()
    {
        // Use current level to calculate this
        return 1;
    }
}
