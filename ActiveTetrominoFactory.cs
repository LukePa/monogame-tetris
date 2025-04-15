using Microsoft.Xna.Framework;
using tetris.Tetrominos;

namespace tetris;

public class ActiveTetrominoFactory
{
    TetrominoQueue _tetrominoQueue = new TetrominoQueue();
    int _boardWidth;
    int _boardHeight;
    
    public ActiveTetrominoFactory(int boardWidth, int boardHeight)
    {
        _boardWidth = boardWidth;
        _boardHeight = boardHeight;
    }
    
    public ActiveTetromino GetNewActiveTetromino()
    {
        var tetromino = _tetrominoQueue.Pop();
        int startingX = (_boardWidth - tetromino.GetWidthOfRotation(ActiveTetrominoRotation.Zero)) / 2;
        return new ActiveTetromino(tetromino, new Point(startingX, _boardHeight - 1));
    }

    public Tetromino NextTetromino()
    {
        return _tetrominoQueue.NextTetromino();
    }
}