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
    private int _playerControlledDropSpeed = 10;
    private double _blockDropCounter = 1;

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
        var blockDropPerSecond = GetBlockDropPerSecond();
        _blockDropCounter -= blockDropPerSecond * secondsSinceLastCall;
    }
    

    void DropBlockIfShould()
    {
        if (_blockDropCounter <= 0)
        {
            gameBoard.TryMoveActiveTetrominoDown();
            _blockDropCounter = 1;
        }
    }

    float GetBlockDropPerSecond()
    {
        var levelBasedDropsPerSecond = GetBlockDropPerSecondBasedOnLevel();


        if (PlayerIsIncreasingDropSpeed() && levelBasedDropsPerSecond < _playerControlledDropSpeed)
        {
            return _playerControlledDropSpeed;
        }
        else
        {
            return levelBasedDropsPerSecond;
        }
    }

    float GetBlockDropPerSecondBasedOnLevel()
    {
        // Use current level to calculate this somehow
        return 1;
    }

    bool PlayerIsIncreasingDropSpeed()
    {
        return Keyboard.GetState().IsKeyDown(Keys.S);
    }
}
