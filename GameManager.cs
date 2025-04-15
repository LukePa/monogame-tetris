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
    private BlockMovementController _movementController;
    private BlockDropController _blockDropController;
    private int _playerControlledDropSpeed = 10;
    private double _blockDropCounter = 1;

    public GameManager(Game game)
    {
        _game = game;
        _movementController = new BlockMovementController(_gameBoard);
        _blockDropController = new BlockDropController(_gameBoard);
    }

    public void Update(GameTime gameTime)
    {
        HandleExit();
        _movementController.Update(gameTime);
        _blockDropController.Update(gameTime);
    }

    void HandleExit()
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            _game.Exit();
        }
    }
    

    
    
    
}
