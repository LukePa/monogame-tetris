using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using tetris.GameStates;

namespace tetris;

public class MainMenuGameStateRenderer
{
    private GraphicsDevice _graphicsDevice;
    private SpriteBatch _spriteBatch;
    private Vector2 _enterTextPosition;
    private Vector2 _controlsTextPosition;
    
    public MainMenuGameStateRenderer(GraphicsDevice gDevice)
    {
        _graphicsDevice = gDevice;
        _spriteBatch = new SpriteBatch(gDevice);
        _enterTextPosition = new Vector2(gDevice.Viewport.Width / 2, 400);
        _controlsTextPosition = new Vector2(gDevice.Viewport.Width / 2, 600);
    }

    public void Render(MainMenuGameState gameState)
    {
        _graphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin();
        
        var enterText = "Press enter to start";
        Vector2 fontOrigin = Assets.GameFont.MeasureString(enterText) / 2;
        _spriteBatch.DrawString(Assets.GameFont, enterText, _enterTextPosition, Color.White, 0, fontOrigin, 1.0f, SpriteEffects.None, 0.5f);

        var controlsText = "Move: Arrow Keys                Swap: Spacebar";
        Vector2 controlsOrigin = Assets.GameFont.MeasureString(controlsText) / 2;
        _spriteBatch.DrawString(Assets.GameFont, controlsText, _controlsTextPosition, Color.Gray, 0, controlsOrigin, 0.9f, SpriteEffects.None, 0.5f);
        
        _spriteBatch.End();
    }
}