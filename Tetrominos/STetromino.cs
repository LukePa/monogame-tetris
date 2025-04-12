using Microsoft.Xna.Framework;

namespace tetris.Tetrominos;

public class STetromino: Tetromino
{
    public STetromino()
    {
        Colour = BlockColour.Red;
        
        Rotation0 = [new Point(1, 0), new Point(2, 0), new Point(0, 1), new Point(1, 1)];
        Rotation90 = [new Point(1, 0), new Point(1, 1), new Point(2, 1), new Point(2, 2)];
        Rotation180 = Rotation0;
        Rotation270 = [new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(1, 2)];
    }
}