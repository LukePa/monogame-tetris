namespace tetris;

public static class GlobalDataController
{
    private static int _linesCleared = 0;
    
    private static int _score = 0;
    public static int Score => _score;

    public static void Reset()
    {
        _linesCleared = 0;
        _score = 0;
    }
    
    public static void NotifyLinesCleared(int numberOfLines)
    {
        _linesCleared += numberOfLines;
        if (numberOfLines > 0)
        {
            _score += numberOfLines * numberOfLines * 50;
            Sound.PlayClearSoundEffect();
        }
    }

    public static int GetLevel()
    {
        return (_linesCleared / 10) + 1;
    }
}