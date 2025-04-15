using System;
using System.Collections.Generic;
using tetris.Tetrominos;

namespace tetris;

public class TetrominoQueue
{
    List<Tetromino> _list = new List<Tetromino>();
    
    public TetrominoQueue()
    {
        PopulateList();
    }

    private void PopulateList()
    {
        Tetromino[] newTetrominos = new Tetromino[]
        {
            new JTetromino(),
            new JTetromino(),
            new JTetromino(),
            new LineTetromino(),
            new LineTetromino(),
            new LineTetromino(),
            new LTetromino(),
            new LTetromino(),
            new LTetromino(),
            new SquareTetromino(),
            new SquareTetromino(),
            new SquareTetromino(),
            new STetromino(),
            new STetromino(),
            new STetromino(),
            new TTetromino(),
            new TTetromino(),
            new TTetromino(),
            new ZTetromino(),
            new ZTetromino(),
            new ZTetromino(),
        };

        var random = new Random();
        random.Shuffle(newTetrominos);
        _list.AddRange(newTetrominos);
    }

    public Tetromino Pop()
    {
        if (_list.Count == 0)
        {
            throw new Exception("Queue is empty");
        }
        
        var nextTetromino = _list[0];
        _list.RemoveAt(0);
        if (_list.Count <= 5) PopulateList(); 
        
        return nextTetromino;
    }

    public Tetromino NextTetromino()
    {
        if (_list.Count == 0)
        {
            throw new Exception("Queue is empty");
        }

        return _list[0];
    }

    public List<Tetromino> GetNextXTetrominoes(int amount)
    {
        return _list.Slice(0, amount);
    }
}