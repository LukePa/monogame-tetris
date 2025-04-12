using Microsoft.Xna.Framework;

namespace tetris.Tetrominos;

public class ZTetromino: Tetromino
{
    public ZTetromino()
    {
        Colour = BlockColour.Green;
        
        Rotation0 = [new Point(0, 0), new Point(1, 0), new Point(1, 1), new Point(2, 1)];
        Rotation90 = [new Point(2, 0), new Point(2, 1), new Point(1, 1), new Point(1, 2)];
        Rotation180 = [new Point(0, 0), new Point(1, 0), new Point(1, 1), new Point(2, 1)];
        Rotation270 = [new Point(1, 0), new Point(1, 1), new Point(0, 1), new Point(0, 2)];
    }
}