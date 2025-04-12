using Microsoft.Xna.Framework;

namespace tetris.Tetrominos;

public class SquareTetromino: Tetromino
{
    public SquareTetromino()
    {
        Colour = BlockColour.Yellow;
        
        Rotation0 = [new Point(0, 0), new Point(0, 1), new Point(1, 0), new Point(1, 1)];
        Rotation90 = Rotation0;
        Rotation180 = Rotation0;
        Rotation270 = Rotation0;
    }
}