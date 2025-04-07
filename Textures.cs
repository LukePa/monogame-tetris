using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace tetris;

public class Textures
{
    public Texture2D EmptyBlockTexture;
    public Texture2D DarkBlueBlockTexture;
    public Texture2D GreenBlockTexture;
    public Texture2D LightBlueBlockTexture;
    public Texture2D OrangeBlockTexture;
    public Texture2D PurpleBlockTexture;
    public Texture2D RedBlockTexture;
    public Texture2D YellowBlockTexture;

    public Textures(GraphicsDevice gDevice, ContentManager content)
    {
        EmptyBlockTexture = content.Load<Texture2D>("EmptyBlock");
        DarkBlueBlockTexture = content.Load<Texture2D>("DarkBlueBlock");
        GreenBlockTexture = content.Load<Texture2D>("GreenBlock");
        LightBlueBlockTexture = content.Load<Texture2D>("LightBlueBlock");
        OrangeBlockTexture = content.Load<Texture2D>("OrangeBlock");
        PurpleBlockTexture = content.Load<Texture2D>("PurpleBlock");
        RedBlockTexture = content.Load<Texture2D>("RedBlock");
        YellowBlockTexture = content.Load<Texture2D>("YellowBlock");
    }
}
