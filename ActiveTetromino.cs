using System.Collections.Generic;
using Microsoft.Xna.Framework;
using tetris.Tetrominos;

namespace tetris;

public class ActiveTetromino
{
    public Tetromino Tetromino;
    private ActiveTetrominoRotation _rotation = ActiveTetrominoRotation.Zero;

    public ActiveTetromino(Tetromino tetromino)
    {
        Tetromino = tetromino;
    }

    private bool[,] CurrentRotation()
    {
        switch (_rotation)
        {
            case ActiveTetrominoRotation.Zero:
                return Tetromino.Rotation0;
            case ActiveTetrominoRotation.Ninety:
                return Tetromino.Rotation90;
            case ActiveTetrominoRotation.OneEighty:
                return Tetromino.Rotation180;
            case ActiveTetrominoRotation.TwoSeventy:
                return Tetromino.Rotation270;
            default:
                return Tetromino.Rotation0;
        }
    }
    
    public List<Point> GetCoveredSquaresFromPoint(Point point)
    {
        var points = new List<Point>();
        
        for (int x = 0; x < CurrentRotation().GetLength(0); x += 1)
        {
            for (int y = 0; y < CurrentRotation().GetLength(1); y += 1)
            {
                if (CurrentRotation()[x, y] == true)
                {
                    points.Add(new Point(point.X + x, point.Y - y));
                }
            }
        }
        
        return points;
    }
}