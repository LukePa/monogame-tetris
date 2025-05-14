using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using tetris.GameStates;

namespace tetris;

public class MainMenuGameStateRenderer
{
    private GraphicsDevice _graphicsDevice;
    private SpriteBatch _spriteBatch;
    private Vector2 _enterTextPosition;
    
    public MainMenuGameStateRenderer(GraphicsDevice gDevice)
    {
        _graphicsDevice = gDevice;
        _spriteBatch = new SpriteBatch(gDevice);
        _enterTextPosition = new Vector2(gDevice.Viewport.Width / 2, gDevice.Viewport.Height / 2);
    }

    public void Render(MainMenuGameState gameState)
    {
        _graphicsDevice.Clear(Color.CornflowerBlue);
        
        var enterText = "Press enter to start";
        _spriteBatch.Begin();
        
        Vector2 fontOrigin = Assets.GameFont.MeasureString(enterText) / 2;
        _spriteBatch.DrawString(Assets.GameFont, enterText, _enterTextPosition, Color.White, 0, fontOrigin, 1.0f, SpriteEffects.None, 0.5f);
        
        _spriteBatch.End();
    }
}