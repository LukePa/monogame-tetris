using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using tetris.Tetrominos;

namespace tetris;

public class GameBoard
{
    GameBoardSquare[,] boardSquares;
    public int boardWidth = 10;
    public int boardHeight = 20;
    
    private ActiveTetromino activeTetromino;
    private Point? activeTetrominoLocation;

    public GameBoard()
    {
        boardSquares = new GameBoardSquare[boardWidth, boardHeight];

        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                boardSquares[x, y] = new GameBoardSquare();
            }
        }
        
        
        // FOR TESTING RENDERING
        var block = new Block(BlockColour.Yellow);
        GetSquareAt(0, 0).SetBlock(block);
        GetSquareAt(1, 0).SetBlock(block);
        GetSquareAt(2, 0).SetBlock(block);
        GetSquareAt(1, 1).SetBlock(block);

        var linePiece = new LineTetromino();
        activeTetromino = new ActiveTetromino(linePiece);
        
        activeTetrominoLocation = new Point(3, 6);
    }

    public GameBoardSquare GetSquareAt(int x, int y)
    {
        return boardSquares[x, y];    
    }

    public List<Point> GetPointsCoveredByActiveTetromino()
    {
        var points = new List<Point>();
        if (activeTetromino != null && activeTetrominoLocation != null)
        {
            points = activeTetromino.GetRelativeCurrentlyCoveredSquares((Point)activeTetrominoLocation);
        } 
        return points;
    }

    public BlockColour? GetActiveTetrominoColour()
    {
        if (activeTetromino?.Tetromino != null) return activeTetromino.Tetromino.GetColour();
        return null;
    }

    public void TryRotateActiveTetromino()
    {
        if (activeTetromino == null || activeTetrominoLocation == null) return;
        
        List<Point> squaresCoveredByNextRotation = activeTetromino.GetRelativeCoveredSquaresOfNextRotation((Point)activeTetrominoLocation);
        if (CheckAllAreEmptyValidSpaces(squaresCoveredByNextRotation))
        {
            activeTetromino.IncrementRotation();
        }
    }

    private bool CheckAllAreEmptyValidSpaces(List<Point> points)
    {
        foreach (var point in points)
        {
            if (point.X < 0 || point.X >= boardWidth || point.Y < 0 || point.Y >= boardHeight) return false;
            var square = GetSquareAt(point.X, point.Y);
            if (!square.IsEmpty()) return false;
        }

        return true;
    }
}
