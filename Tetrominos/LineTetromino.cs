using System;
using Microsoft.Xna.Framework;

namespace tetris.Tetrominos;

public class LineTetromino : Tetromino
{
    public LineTetromino()
    {
        Colour = BlockColour.LightBlue;

        Rotation0 = [new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(1, 3)];
        Rotation90 = [new Point(0, 3), new Point(1, 3), new Point(2, 3), new Point(3, 3)];
        Rotation180 = [new Point(2, 0), new Point(2, 1), new Point(2, 2), new Point(2, 3)];
        Rotation270 = Rotation90;
    }
}