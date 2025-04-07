

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

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
                
                var textureToRender = BlockColourToTexture(board.GetSquareAt(x, y).GetBlock()?.BlockColour);
                foreach (var point in board.GetPointsCoveredByActiveTetromino())
                {
                    if (point.X == x && point.Y == y)
                    {
                        textureToRender = BlockColourToTexture(board.GetActiveTetrominoColour());
                    }
                }
                
                DrawGameboardSquare(blockX, blockY, blockDimensions, textureToRender);
            }
        }
    }

    void DrawGameboardSquare(int x, int y, int dimensions, Texture2D texture)
    {
        var placementSquare = new Rectangle(x, y, dimensions, dimensions);
        _spriteBatch.Draw(texture, placementSquare, Color.White);
    }

    private Texture2D BlockColourToTexture(BlockColour? blockColour)
    {
        return blockColour switch
        {
            BlockColour.DarkBlue => textures.DarkBlueBlockTexture,
            BlockColour.Green => textures.GreenBlockTexture,
            BlockColour.LightBlue => textures.LightBlueBlockTexture,
            BlockColour.Orange => textures.OrangeBlockTexture,
            BlockColour.Purple => textures.PurpleBlockTexture,
            BlockColour.Red => textures.RedBlockTexture,
            BlockColour.Yellow => textures.YellowBlockTexture,
            _ => textures.EmptyBlockTexture
        };
    }
}
