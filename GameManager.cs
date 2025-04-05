using System;

namespace tetris;

public class GameManager
{
    GameBoard _gameBoard = new GameBoard();
    public GameBoard gameBoard => _gameBoard;

    public GameManager()
    {
    
    }
}
