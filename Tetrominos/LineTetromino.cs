using System;

namespace tetris.Tetrominos;

public class LineTetromino : Tetromino
{
    public LineTetromino()
    {
        Colour = BlockColour.LightBlue;
        
        Rotation0 = new bool[4,4]
        {
            {false, false, false, false},
            {true, true, true, true},
            {false, false, false, false},
            {false, false, false, false},
        };
        Rotation90 = new bool[4,4]
        {
            {false, true, false, false},
            {false, true, false, false},
            {false, true, false, false},
            {false, true, false, false},
        };
        Rotation180 = Rotation0;
        Rotation270 = Rotation90;
    }
}