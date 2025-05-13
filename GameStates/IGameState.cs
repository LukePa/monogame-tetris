using Microsoft.Xna.Framework;

namespace tetris.GameStates;

public interface IGameState
{
    void Update(GameTime gameTime);
    void Render();
}