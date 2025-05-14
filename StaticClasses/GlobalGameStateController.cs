using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using tetris.GameStates;

namespace tetris;

public static class GlobalGameStateController
{
    private static Game _game;

    public static void SetGame(Game game)
    {
        if (_game != null)
        {
            throw new Exception("Tried to set game property of GlobalState twice");
        }
        _game = game;
    }
    

    private static IGameState _currentGameState;
    public static IGameState GetCurrentGameState()
    {
        return _currentGameState;
    }

    public static void SetStartingGameState()
    {
        SetMainMenuGameState();
    }

    public static void SetMainMenuGameState()
    {
        _currentGameState = new MainMenuGameState(_game.GraphicsDevice);
        Sound.StopMusic();
    }

    public static void SetPlayingGameState()
    {
        _currentGameState = new PlayingGameState(_game.GraphicsDevice);
        Sound.PlayGameMusic();
    }

    public static void SetEndingGameState()
    {
        CloseGame();
        Sound.StopMusic();
    }

    public static void CloseGame()
    {
        _game.Exit();
    }
}