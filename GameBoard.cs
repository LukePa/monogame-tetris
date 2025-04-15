using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using tetris.Tetrominos;

namespace tetris;

public class GameBoard
{
    public int BoardWidth = 10;
    public int BoardHeight = 20;
    
    GameBoardSquare[,] _boardSquares;
    private ActiveTetromino _activeTetromino;
    private ActiveTetrominoFactory _activeTetrominoFactory;

    public GameBoard()
    {
        _boardSquares = new GameBoardSquare[BoardWidth, BoardHeight];

        for (int x = 0; x < BoardWidth; x++)
        {
            for (int y = 0; y < BoardHeight; y++)
            {
                _boardSquares[x, y] = new GameBoardSquare();
            }
        }

        _activeTetrominoFactory = new ActiveTetrominoFactory(BoardWidth, BoardHeight);
        GetNewActiveTetromino();
    }

    public GameBoardSquare GetSquareAt(int x, int y)
    {
        return _boardSquares[x, y];    
    }

    public List<Point> GetPointsCoveredByActiveTetromino()
    {
        var points = new List<Point>();
        if (_activeTetromino != null)
        {
            points = _activeTetromino.GetRelativeCurrentlyCoveredSquares();
        } 
        return points;
    }

    public BlockColour? GetActiveTetrominoColour()
    {
        return _activeTetromino.Tetromino.GetColour();
    }

    public void TryRotateActiveTetromino()
    {
        if (_activeTetromino == null) return;
        
        List<Point> nextCoveredSquares = _activeTetromino.GetRelativeCoveredSquaresOfNextRotation();
        if (CheckAllAreEmptyValidSpaces(nextCoveredSquares))
        {
            _activeTetromino.IncrementRotation();
        }
    }

    public void TryMoveActiveTetrominoLeft()
    {
        if (_activeTetromino == null) return;
        List<Point> nextCoveredSquares = _activeTetromino.GetRelativeCoveredSquaresOfNextLeft();
        if (CheckAllAreEmptyValidSpaces(nextCoveredSquares))
        {
            _activeTetromino.MoveLeft();
        }
    }
    
    public void TryMoveActiveTetrominoRight()
    {
        if (_activeTetromino == null) return;
        List<Point> nextCoveredSquares = _activeTetromino.GetRelativeCoveredSquaresOfNextRight();
        if (CheckAllAreEmptyValidSpaces(nextCoveredSquares))
        {
            _activeTetromino.MoveRight();
        }
    }

    public void TryMoveActiveTetrominoDown()
    {
        if (_activeTetromino == null) return;
        List<Point> nextCoveredSquares = _activeTetromino.GetRelativeCoveredSquaresOfNextDown();
        if (CheckAllAreEmptyValidSpaces(nextCoveredSquares))
        {
            _activeTetromino.MoveDown();
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
            square.SetBlock(new Block(_activeTetromino.Tetromino.GetColour()));
            CheckForAndRemoveFullRows();
        }
    }

    private void GetNewActiveTetromino()
    {
        _activeTetromino = _activeTetrominoFactory.GetNewActiveTetromino();
    }

    private bool CheckAllAreEmptyValidSpaces(List<Point> points)
    {
        foreach (var point in points)
        {
            if (point.X < 0 || point.X >= BoardWidth || point.Y < 0 || point.Y >= BoardHeight) return false;
            var square = GetSquareAt(point.X, point.Y);
            if (!square.IsEmpty()) return false;
        }

        return true;
    }

    private void CheckForAndRemoveFullRows()
    {
        var fullRows = GetIndexesOfFullRows();
        RemoveRowsFromBoard(fullRows);
    }

    private List<int> GetIndexesOfFullRows()
    {
        var rows = new List<int>();
        
        for (int row = 0; row < BoardHeight; row++)
        {
            bool isRowFull = true;
            for (int column = 0; column < BoardWidth; column++)
            {
                var square = GetSquareAt(column, row);
                if (square.IsEmpty())
                {
                    isRowFull = false;
                    break;
                }
            }

            if (isRowFull)
            {
                rows.Add(row);
            }
        }
        
        return rows;
    }

    private void RemoveRowsFromBoard(List<int> rowIndexes)
    {
        if (rowIndexes == null || rowIndexes.Count == 0) return;

        var newBoardSquares = new GameBoardSquare[BoardWidth, BoardHeight];
        for (int y = 0; y < BoardHeight; y++)
        {
            if (rowIndexes.Contains(y)) continue;

            var removedRowsBelowY = rowIndexes.FindAll(rowIndex => rowIndex < y);
            var newY = y - removedRowsBelowY.Count;
            for (int x = 0; x < BoardWidth; x++)
            {
                newBoardSquares[x, newY] = GetSquareAt(x, y);
            }
        }

        for (int y = 0; y < BoardHeight; y++)
        {
            for (int x = 0; x < BoardWidth; x++)
            {
                if (newBoardSquares[x, y] == null)
                {
                    newBoardSquares[x, y] = new GameBoardSquare();
                }
            }
        }

        _boardSquares = newBoardSquares;
    }
}
