using Microsoft.Xna.Framework.Media;

namespace tetris;

public static class Sound
{
    public static void StopMusic()
    {
        if (MediaPlayer.State != MediaState.Stopped)
        {
            MediaPlayer.Stop();
        }
    }

    public static void PlayGameMusic()
    {
        StopMusic();
        MediaPlayer.IsRepeating = true;
        MediaPlayer.Play(Assets.ThemeSong);
    }

    public static void PlayPlaceSoundEffect()
    {
        Assets.PlaceSoundEffect.Play();
    }

    public static void PlayClearSoundEffect()
    {
        Assets.ClearSoundEffect.Play();
    }

    public static void PlaySwapSoundEffect()
    {
        Assets.SwapSoundEffect.Play();
    }
}