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

    public bool[,] GetGridFromRotation(ActiveTetrominoRotation rotation)
    {
        switch (rotation)
        {
            case ActiveTetrominoRotation.Zero:
                return Rotation0;
            case ActiveTetrominoRotation.Ninety:
                return Rotation90;
            case ActiveTetrominoRotation.OneEighty:
                return Rotation180;
            case ActiveTetrominoRotation.TwoSeventy:
                return Rotation270;
            default:
                return Rotation0;
        }
    }
}
