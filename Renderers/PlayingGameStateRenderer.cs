

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using tetris.Tetrominos;

namespace tetris;

public class PlayingGameStateRenderer
{
    private SpriteBatch _spriteBatch;

    private GraphicsDevice _graphicsDevice;
    private ContentManager _content;
    
    


    public PlayingGameStateRenderer(GraphicsDevice gDevice)
    {
        _graphicsDevice = gDevice;
        _spriteBatch = new SpriteBatch(_graphicsDevice);
    }

    public void Render(PlayingGameState state)
    {
        _graphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();
        DrawGameboard(state.GameBoard);
        DrawHeldTetromino(state.GameBoard.HeldTetromino);
        DrawTetrominoQueue(state.GameBoard.GetNextTetrominos());
        DrawStats();
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
        var textPosition = new Vector2(350, 90);
        var text = "Held:";
        var textOrigin = new Vector2(Assets.GameFont.MeasureString(text).X, Assets.GameFont.MeasureString(text).Y / 2);
        _spriteBatch.DrawString(Assets.GameFont, text, textPosition, Color.White, 0f, textOrigin, 0.8f, SpriteEffects.None, 0f);
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
        _spriteBatch.Draw(Assets.EmptyBlockTexture, queueBoxRectangle, Color.White);
        
        var iconsStartPoint = new Point(queueBoxRectangle.X + 10, queueBoxRectangle.Y + 20);
        for (int i = 0; i < tetrominos.Length; i++)
        {
            var tetromino = tetrominos[i];
            var yPosition = iconsStartPoint.Y + (iconDimensions * i);
            var iconRectangle = new Rectangle(iconsStartPoint.X, yPosition, iconDimensions, iconDimensions);
            DrawTetrominoIcon(tetromino, iconRectangle);
        }
    }

    void DrawStats()
    {
        var levelTextPosition = new Vector2(1100, 200);
        var levelText = "Level: " + GlobalDataController.GetLevel();
        var levelTextOrigin = new Vector2(0, 0);
        _spriteBatch.DrawString(Assets.GameFont, levelText, levelTextPosition, Color.White, 0f, levelTextOrigin, 1f, SpriteEffects.None, 0f);
        
       var scoreTextPosition = new Vector2(1100, 220);
       var scoreText = "Score: " + GlobalDataController.Score;
       var scoreTextOrigin = new Vector2(0, 0);
       _spriteBatch.DrawString(Assets.GameFont, scoreText, scoreTextPosition, Color.Gray, 0f, scoreTextOrigin, 0.8f, SpriteEffects.None, 0f);
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
            BlockColour.DarkBlue => Assets.DarkBlueBlockTexture,
            BlockColour.Green => Assets.GreenBlockTexture,
            BlockColour.LightBlue => Assets.LightBlueBlockTexture,
            BlockColour.Orange => Assets.OrangeBlockTexture,
            BlockColour.Purple => Assets.PurpleBlockTexture,
            BlockColour.Red => Assets.RedBlockTexture,
            BlockColour.Yellow => Assets.YellowBlockTexture,
            _ => Assets.EmptyBlockTexture
        };
    }

    void DrawTetrominoIconInContainingBox(Tetromino tetromino, Rectangle placementSquare)
    {
        var innerTetrominoRectangle = new Rectangle(
            placementSquare.X + 10, 
            placementSquare.Y + 10, 
            placementSquare.Width - 20, 
            placementSquare.Height - 20);
        
        _spriteBatch.Draw(Assets.EmptyBlockTexture, placementSquare, Color.White);

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
