using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace tetris;

public class ActiveTetrominoDropController
{
    private GameBoard _gameBoard;
    
    private int _playerControlledDropSpeed = 10;
    private double _blockDropCounter = 1;
    private Keys _increaseDropSpeedKey = Keys.Down;

    public ActiveTetrominoDropController(GameBoard gameBoard)
    {
        _gameBoard = gameBoard;
    }

    public void Update(GameTime gameTime)
    {
        HandleIncrementTimeSinceLastDrop(gameTime.ElapsedGameTime.TotalSeconds);
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
            _gameBoard.TryMoveActiveTetrominoDown();
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
        return Keyboard.GetState().IsKeyDown(_increaseDropSpeedKey);
    }
}