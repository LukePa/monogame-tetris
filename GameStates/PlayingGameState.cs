using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using tetris.GameStates;

namespace tetris;

public class PlayingGameState: IGameState
{
    GameBoard _gameBoard = new GameBoard();
    public GameBoard GameBoard => _gameBoard;
    
    private BlockMovementController _movementController;
    private ActiveTetrominoDropController _activeTetrominoDropController;
    private PlayingGameStateRenderer _renderer;

    public PlayingGameState(GraphicsDevice graphicsDevice)
    {
        _movementController = new BlockMovementController(_gameBoard);
        _activeTetrominoDropController = new ActiveTetrominoDropController(_gameBoard);
        _renderer = new PlayingGameStateRenderer(graphicsDevice, this);
    }

    public void Update(GameTime gameTime)
    {
        HandleExit();
        HandleHeldTetrominoInput();
        _movementController.Update(gameTime);
        _activeTetrominoDropController.Update(gameTime);
    }
    
    public void Render()
    {
        _renderer.Render(this);
    }

    void HandleExit()
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            GlobalGameStateController.CloseGame();
        }
    }

    void HandleHeldTetrominoInput()
    {
        if (KeyUpController.HasKeyReleased(Keys.C))
        {
            _gameBoard.TrySwapActiveTetromino();
        }
    }

    
    
    
}
