using Microsoft.Xna.Framework;

namespace tetris.Tetrominos;

public class TTetromino: Tetromino
{
    public TTetromino()
    {
        Colour = BlockColour.Purple;
        
        Rotation0 = [new Point(1, 0), new Point(0, 1), new Point(1, 1), new Point(2, 1)];
        Rotation90 = [new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(2, 1)];
        Rotation180 = [new Point(0, 1), new Point(1, 1), new Point(2, 1), new Point(1, 2)];
        Rotation270 = [new Point(1, 0), new Point(0, 1), new Point(1, 1), new Point(1, 2)];
    }
}