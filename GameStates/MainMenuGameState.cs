using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tetris.GameStates;

public class MainMenuGameState: IGameState
{
    private MainMenuGameStateRenderer _renderer;
    
    public MainMenuGameState(GraphicsDevice gDevice)
    {
        _renderer = new MainMenuGameStateRenderer(gDevice);
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