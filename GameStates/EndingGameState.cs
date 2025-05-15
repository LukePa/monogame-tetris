using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tetris.GameStates;

public class EndingGameState : IGameState
{
    EndingGameStateRenderer _renderer;
    
    public EndingGameState(GraphicsDevice graphicsDevice)
    {
        _renderer = new EndingGameStateRenderer(graphicsDevice);
    }

    public void Update(GameTime gameTime)
    {
        if (KeyUpController.HasKeyReleased(Keys.Enter))
        {
            GlobalGameStateController.SetPlayingGameState();
        }
        
        if (KeyUpController.HasKeyReleased(Keys.Escape))
        {
            GlobalGameStateController.CloseGame();
        }
    }
    
    public void Render()
    {
        _renderer.Render(this);
    }
    
    
}