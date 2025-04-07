using System;

namespace tetris;

public class GameBoardSquare
{
    private Block contents;

    public GameBoardSquare()
    {

    }

    public void SetBlock(Block block)
    {
        contents = block;
    }

    public Block GetBlock()
    {
        return contents;
    }

    public bool IsEmpty()
    {
        return contents == null;
    }
}
