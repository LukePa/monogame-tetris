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
    private ActiveTetrominoFactory activeTetrominoFactory;

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

        activeTetrominoFactory = new ActiveTetrominoFactory(boardWidth, boardHeight);
        GetNewActiveTetromino();
    }

    public GameBoardSquare GetSquareAt(int x, int y)
    {
        return boardSquares[x, y];    
    }

    public List<Point> GetPointsCoveredByActiveTetromino()
    {
        var points = new List<Point>();
        if (activeTetromino != null)
        {
            points = activeTetromino.GetRelativeCurrentlyCoveredSquares();
        } 
        return points;
    }

    public BlockColour? GetActiveTetrominoColour()
    {
        return activeTetromino.Tetromino.GetColour();
    }

    public void TryRotateActiveTetromino()
    {
        if (activeTetromino == null) return;
        
        List<Point> nextCoveredSquares = activeTetromino.GetRelativeCoveredSquaresOfNextRotation();
        if (CheckAllAreEmptyValidSpaces(nextCoveredSquares))
        {
            activeTetromino.IncrementRotation();
        }
    }

    public void TryMoveActiveTetrominoLeft()
    {
        if (activeTetromino == null) return;
        List<Point> nextCoveredSquares = activeTetromino.GetRelativeCoveredSquaresOfNextLeft();
        if (CheckAllAreEmptyValidSpaces(nextCoveredSquares))
        {
            activeTetromino.MoveLeft();
        }
    }
    
    public void TryMoveActiveTetrominoRight()
    {
        if (activeTetromino == null) return;
        List<Point> nextCoveredSquares = activeTetromino.GetRelativeCoveredSquaresOfNextRight();
        if (CheckAllAreEmptyValidSpaces(nextCoveredSquares))
        {
            activeTetromino.MoveRight();
        }
    }

    public void TryMoveActiveTetrominoDown()
    {
        if (activeTetromino == null) return;
        List<Point> nextCoveredSquares = activeTetromino.GetRelativeCoveredSquaresOfNextDown();
        if (CheckAllAreEmptyValidSpaces(nextCoveredSquares))
        {
            activeTetromino.MoveDown();
        }
        else
        {
            PlaceActiveTetromino();
            GetNewActiveTetromino();
        }
    }

    private void PlaceActiveTetromino()
    {
        var coveredPoints = GetPointsCoveredByActiveTetromino();

        if (!CheckAllAreEmptyValidSpaces(coveredPoints))
        {

            throw new Exception("Should end the game here");
        }
        
        foreach (var coveredPoint in coveredPoints)
        {
            var square = GetSquareAt(coveredPoint.X, coveredPoint.Y);
            square.SetBlock(new Block(activeTetromino.Tetromino.GetColour()));
        }
    }

    private void GetNewActiveTetromino()
    {
        activeTetromino = activeTetrominoFactory.GetNewActiveTetromino();
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
