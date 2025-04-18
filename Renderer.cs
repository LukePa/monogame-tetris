

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using tetris.Tetrominos;

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
        DrawHeldTetromino(gameManager.gameBoard.HeldTetromino);
        DrawTetrominoQueue(gameManager.gameBoard.GetNextTetrominos());
        _spriteBatch.End();
    }

    void DrawGameboard(GameBoard board)
    {
        var boardDimensions = new Rectangle(600, 50, 400, 800);
        var blockDimensions = 40;

        for (int x = 0; x < board.BoardWidth; x++)
        {
            var blockX = boardDimensions.Left + (blockDimensions * x);
            
            for (int y = 0; y < board.BoardHeight; y++)
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

    void DrawHeldTetromino(Tetromino heldTetromino)
    {
        var heldTetrominoDisplayRectangle = new Rectangle(350, 50, 80, 80);
        DrawTetrominoIconInContainingBox(heldTetromino, heldTetrominoDisplayRectangle);
    }

    void DrawTetrominoQueue(Tetromino[] tetrominos)
    {
        var tetrominoQueueBoxStartPoint = new Point(350, 160);
        var queueBoxWidth = 60;
        var iconDimensions = 40;
        var queueBoxHeight = (tetrominos.Length * iconDimensions) + 40;

        var queueBoxRectangle = new Rectangle(
            tetrominoQueueBoxStartPoint.X, 
            tetrominoQueueBoxStartPoint.Y, 
            queueBoxWidth, 
            queueBoxHeight
            );
        _spriteBatch.Draw(textures.EmptyBlockTexture, queueBoxRectangle, Color.White);
        
        var iconsStartPoint = new Point(queueBoxRectangle.X + 10, queueBoxRectangle.Y + 20);
        for (int i = 0; i < tetrominos.Length; i++)
        {
            var tetromino = tetrominos[i];
            var yPosition = iconsStartPoint.Y + (iconDimensions * i);
            var iconRectangle = new Rectangle(iconsStartPoint.X, yPosition, iconDimensions, iconDimensions);
            DrawTetrominoIcon(tetromino, iconRectangle);
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

    void DrawTetrominoIconInContainingBox(Tetromino tetromino, Rectangle placementSquare)
    {
        var innerTetrominoRectangle = new Rectangle(
            placementSquare.X + 10, 
            placementSquare.Y + 10, 
            placementSquare.Width - 20, 
            placementSquare.Height - 20);
        
        _spriteBatch.Draw(textures.EmptyBlockTexture, placementSquare, Color.White);

        if (tetromino != null)
        {
            DrawTetrominoIcon(tetromino, innerTetrominoRectangle);
        }
    }
    
    void DrawTetrominoIcon(Tetromino tetromino, Rectangle placementSquare)
    {
        var blockWidthPixel = placementSquare.Width / 4;
        var blockHeightPixel = placementSquare.Height / 4;

        var tetrominoWidth = tetromino.GetWidthOfRotation(ActiveTetrominoRotation.Zero);
        var tetrominoHeight = tetromino.GetHeightOfRotation(ActiveTetrominoRotation.Zero);

        var iconWidth = blockWidthPixel * tetrominoWidth;
        var iconHeight = blockHeightPixel * tetrominoHeight;
        
        var iconStartX = (placementSquare.X + (placementSquare.Width - iconWidth) / 2);
        var iconStartY = (placementSquare.Y + (placementSquare.Height - iconHeight) / 2);

        var points = tetromino.GetPointsFromRotation(ActiveTetrominoRotation.Zero);
        Texture2D blockTexture = BlockColourToTexture(tetromino.GetColour());

        var xOffset = tetromino.GetLowestXPoint(ActiveTetrominoRotation.Zero);
        var yOffset = tetromino.GetLowestYPoint(ActiveTetrominoRotation.Zero);
        
        foreach (var point in points)
        {
            var blockX = iconStartX + ((point.X - xOffset) * blockWidthPixel);
            var blockY = iconStartY + ((point.Y - yOffset) * blockHeightPixel);
            _spriteBatch.Draw(blockTexture, new Rectangle(blockX, blockY, blockWidthPixel, blockHeightPixel), Color.White);
        }
    }
}
