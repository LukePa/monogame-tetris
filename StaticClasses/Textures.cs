using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace tetris;

public static class Textures
{
    public static Texture2D EmptyBlockTexture;
    public static Texture2D DarkBlueBlockTexture;
    public static Texture2D GreenBlockTexture;
    public static Texture2D LightBlueBlockTexture;
    public static Texture2D OrangeBlockTexture;
    public static Texture2D PurpleBlockTexture;
    public static Texture2D RedBlockTexture;
    public static Texture2D YellowBlockTexture;

    public static void LoadTextures(ContentManager content)
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
