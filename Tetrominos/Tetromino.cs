using System;

namespace tetris.Tetrominos;

public abstract class Tetromino
{
    public bool[,] Rotation0;
    public bool[,] Rotation90;
    public bool[,] Rotation180;
    public bool[,] Rotation270;

    protected BlockColour Colour;

    public BlockColour GetColour()
    {
        return Colour;
    }
}
