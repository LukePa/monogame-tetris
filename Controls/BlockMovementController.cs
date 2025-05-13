using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace tetris;

public class BlockMovementController
{
    private Keys _leftKey = Keys.Left;
    private Keys _rightKey = Keys.Right;
    private Keys _upKey = Keys.Up;
    private GameBoard _gameBoard;
    
    private double _leftCooldown = 0;
    private double _rightCooldown = 0;
    private float _movementCooldownPeriod = 0.1f;
    
    public BlockMovementController(GameBoard gameBoard)
    {
        _gameBoard = gameBoard;
    }

    public void Update(GameTime gameTime)
    {
        if (KeyUpController.HasKeyReleased(_upKey))
        {
            _gameBoard.TryRotateActiveTetromino();
        }
        
        if (IsLeftPressed())
        {
            if (_leftCooldown <= 0)
            {
                _gameBoard.TryMoveActiveTetrominoLeft();
                _leftCooldown = _movementCooldownPeriod;
            }
            else
            {
                _leftCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
        else
        {
            _leftCooldown = 0;
        }

        if (IsRightPressed())
        {
            if (_rightCooldown <= 0)
            {
                _gameBoard.TryMoveActiveTetrominoRight();
                _rightCooldown = _movementCooldownPeriod;
            }
            else
            {
                _rightCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
        else
        {
            _rightCooldown = 0;
        }
    }

    private bool IsLeftPressed()
    {
        return Keyboard.GetState().IsKeyDown(_leftKey);
    }

    private bool IsRightPressed()
    {
        return Keyboard.GetState().IsKeyDown(_rightKey);
    }
}