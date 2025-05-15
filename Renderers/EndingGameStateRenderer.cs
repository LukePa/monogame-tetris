using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using tetris.GameStates;

namespace tetris;

public class EndingGameStateRenderer
{
    GraphicsDevice _graphicsDevice;
    SpriteBatch _spriteBatch;
    
    Vector2 _playAgainPosition;
    Vector2 _levelPosition;
    Vector2 _scorePosition;
    
    public EndingGameStateRenderer(GraphicsDevice gDevice)
    {
        _graphicsDevice = gDevice;
        _spriteBatch = new SpriteBatch(gDevice);
        _playAgainPosition = new Vector2(gDevice.Viewport.Width / 2, 600);
        _scorePosition  = new Vector2(gDevice.Viewport.Width / 2, 400);
        _levelPosition = new Vector2(gDevice.Viewport.Width / 2, 450);
    }

    public void Render(EndingGameState gameState)
    {
       _graphicsDevice.Clear(Color.CornflowerBlue);
       _spriteBatch.Begin();
       
       string playAgainText = "Play Again? (enter)";
       Vector2 playAgainfontOrigin = Assets.GameFont.MeasureString(playAgainText) / 2;
       _spriteBatch.DrawString(Assets.GameFont, "Play Again? (enter)", _playAgainPosition, Color.White, 0f, playAgainfontOrigin, 1f, SpriteEffects.None, 0f);

       string scoreText = "Score: " + GlobalDataController.Score;
       if (GlobalDataController.Score >= 4000)
       {
           scoreText += "!";
       }
       Vector2 scoreFontOrigin = Assets.GameFont.MeasureString(scoreText) / 2;
       _spriteBatch.DrawString(Assets.GameFont, scoreText, _scorePosition, Color.White, 0f, scoreFontOrigin, 1f, SpriteEffects.None, 0f);
       
       string levelText = "Level: " + GlobalDataController.GetLevel();
       Vector2 levelTextOrigin = Assets.GameFont.MeasureString(levelText) / 2;
       _spriteBatch.DrawString(Assets.GameFont, levelText, _levelPosition, Color.Gray, 0f, levelTextOrigin, 1f, SpriteEffects.None, 0f);
       
       _spriteBatch.End();
    }
}