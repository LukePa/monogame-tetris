using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace tetris;

public class Textures
{
    public Texture2D boardBackgroundTexture;
    
    public Texture2D emptyBlockTexture;
    public Texture2D yellowBlockTexture;

    public Textures(GraphicsDevice gDevice, ContentManager content)
    {
        emptyBlockTexture = content.Load<Texture2D>("EmptyBlock");
        yellowBlockTexture = content.Load<Texture2D>("YellowBlock");

        boardBackgroundTexture = new Texture2D(gDevice, 1, 1);
        boardBackgroundTexture.SetData(new[] {Color.Black});
    }
}
