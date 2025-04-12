using System.Collections.Generic;
using Microsoft.Xna.Framework;
using tetris.Tetrominos;

namespace tetris;

public class ActiveTetromino
{
    public Tetromino Tetromino;
    private ActiveTetrominoRotation _rotation = ActiveTetrominoRotation.Zero;
    private Point _location;

    public ActiveTetromino(Tetromino tetromino, Point startLocation)
    {
        Tetromino = tetromino;
        _location = startLocation;
    }

    private bool[,] CurrentRotationGrid()
    {
        return Tetromino.GetGridFromRotation(_rotation);
    }

    public void IncrementRotation()
    {
        switch (_rotation)
        {
            case ActiveTetrominoRotation.Zero:
                _rotation = ActiveTetrominoRotation.Ninety;
                return;
            case ActiveTetrominoRotation.Ninety:
                _rotation = ActiveTetrominoRotation.OneEighty;
                return;
            case ActiveTetrominoRotation.OneEighty:
                _rotation = ActiveTetrominoRotation.TwoSeventy;
                return;
            case ActiveTetrominoRotation.TwoSeventy:
                _rotation = ActiveTetrominoRotation.Zero;
                return;
            default:
                _rotation = ActiveTetrominoRotation.Zero;
                return;
        }
    }

    public void MoveLeft()
    {
        _location.X--;
    }

    public void MoveRight()
    {
        _location.X++;
    }

    public void MoveDown()
    {
        _location.Y--;
    }

    private ActiveTetrominoRotation GetNextRotation()
    {
        switch (_rotation)
        {
            case ActiveTetrominoRotation.Zero:
                return ActiveTetrominoRotation.Ninety;
            case ActiveTetrominoRotation.Ninety:
                return ActiveTetrominoRotation.OneEighty;
            case ActiveTetrominoRotation.OneEighty:
                return ActiveTetrominoRotation.TwoSeventy;
            case ActiveTetrominoRotation.TwoSeventy:
                return ActiveTetrominoRotation.Zero;
            default:
                return ActiveTetrominoRotation.Zero;
        }
    }
    
    

    public List<Point> GetRelativeCurrentlyCoveredSquares()
    {
        return GetCoveredSquaresFromPointAndRotation(_location, _rotation);
    }

    public List<Point> GetRelativeCoveredSquaresOfNextRotation()
    {
        return GetCoveredSquaresFromPointAndRotation(_location, GetNextRotation());
    }

    public List<Point> GetRelativeCoveredSquaresOfNextLeft()
    {
        return GetCoveredSquaresFromPointAndRotation(new Point(_location.X - 1, _location.Y), _rotation);
    }
    
    public List<Point> GetRelativeCoveredSquaresOfNextRight()
    {
        return GetCoveredSquaresFromPointAndRotation(new Point(_location.X + 1, _location.Y), _rotation);
    }

    public List<Point> GetRelativeCoveredSquaresOfNextDown()
    {
        return GetCoveredSquaresFromPointAndRotation(new Point(_location.X, _location.Y - 1), _rotation);
    }
    
    
    private List<Point> GetCoveredSquaresFromPointAndRotation(Point point, ActiveTetrominoRotation rotation)
    {
        var points = new List<Point>();
        
        for (int x = 0; x < Tetromino.GetGridFromRotation(rotation).GetLength(0); x += 1)
        {
            for (int y = 0; y < Tetromino.GetGridFromRotation(rotation).GetLength(1); y += 1)
            {
                if (Tetromino.GetGridFromRotation(rotation)[x, y] == true)
                {
                    points.Add(new Point(point.X + x, point.Y - y));
                }
            }
        }
        
        return points;
    }
}