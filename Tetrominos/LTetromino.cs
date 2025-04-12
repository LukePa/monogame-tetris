using Microsoft.Xna.Framework;

namespace tetris.Tetrominos;

public class LTetromino: Tetromino
{
    public LTetromino()
    {
        Colour = BlockColour.Orange;
        
        Rotation0 = [new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(2, 2)];
        Rotation90 = [new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(0, 1)];
        Rotation180 = [new Point(0, 0), new Point(1, 0), new Point(1, 1), new Point(1, 2)];
        Rotation270 = [new Point(0, 1), new Point(1, 1), new Point(2, 1), new Point(2, 0)];
    }
}