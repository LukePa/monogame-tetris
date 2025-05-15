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
        _renderer = new PlayingGameStateRenderer(graphicsDevice);
    }

    public void Update(GameTime gameTime)
    {
        HandleExit();
        HandleHeldTetrominoInput(gameTime);
        _activeTetrominoDropController.Update(gameTime);
    }
    
    public void Render()
    {
        _renderer.Render(this);
    }

    void HandleExit()
    {
        if (KeyUpController.HasKeyReleased(Keys.Escape))
        {
            GlobalGameStateController.SetEndingGameState();
        }
    }

    void HandleHeldTetrominoInput(GameTime gameTime)
    {
        if (KeyUpController.HasKeyReleased(Keys.Space))
        {
            _gameBoard.TrySwapActiveTetromino();
            Sound.PlaySwapSoundEffect();
        }
        
        _movementController.Update(gameTime);
    }
    
}
