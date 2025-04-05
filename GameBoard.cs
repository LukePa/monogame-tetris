using System;
using System.Linq;

namespace tetris;

public class GameBoard
{
    GameBoardSquare[,] boardSquares;
    public int boardWidth = 10;
    public int boardHeight = 20;

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

        var block = new Block(BlockColour.Yellow);
        GetSquareAt(0, 0).SetBlock(block);
        GetSquareAt(1, 0).SetBlock(block);
        GetSquareAt(2, 0).SetBlock(block);
        GetSquareAt(1, 1).SetBlock(block);
    }

    public GameBoardSquare GetSquareAt(int x, int y)
    {
        return boardSquares[x, y];    
    }
}
