

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace tetris;

public class Renderer
{
    private SpriteBatch _spriteBatch;

    GraphicsDevice graphicsDevice;
    ContentManager content;

    Textures textures;


    public Renderer(GraphicsDevice gDevice, ContentManager content)
    {
        graphicsDevice = gDevice;
        textures = new Textures(gDevice, content);
        _spriteBatch = new SpriteBatch(graphicsDevice);
    }

    public void Render(GameManager gameManager)
    {
        graphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();
        DrawGameboard(gameManager.gameBoard);
        _spriteBatch.End();
    }

    void DrawGameboard(GameBoard board)
    {
        var boardDimensions = new Rectangle(600, 50, 400, 800);
        var blockDimensions = 40;

        for (int x = 0; x < board.boardWidth; x++)
        {
            var blockX = boardDimensions.Left + (blockDimensions * x);
            
            for (int y = 0; y < board.boardHeight; y++)
            {
                var blockY = (boardDimensions.Bottom - blockDimensions) - (blockDimensions * y);
                DrawGameboardSquare(blockX, blockY, blockDimensions, board.GetSquareAt(x, y));
            }
        }
    }

    void DrawGameboardSquare(int x, int y, int dimensions, GameBoardSquare square)
    {
        var placementSquare = new Rectangle(x, y, dimensions, dimensions);
        Texture2D textureToRender;
        if (square.IsEmpty())
        {
            textureToRender = textures.emptyBlockTexture;
        }
        else
        {
            textureToRender = BlockColourToTexture(square.GetBlock().BlockColour);
        }
        _spriteBatch.Draw(textureToRender, placementSquare, Color.White);
    }

    Texture2D BlockColourToTexture(BlockColour blockColour)
    {
        if (blockColour == BlockColour.Yellow)
        {
            return textures.yellowBlockTexture;
        }
        else
        {
            return textures.emptyBlockTexture;
        }
    }
}
