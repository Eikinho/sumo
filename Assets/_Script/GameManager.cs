using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public enum GameState { MENU, SELECT, GAME, PAUSE, ENDGAME };
    public GameState gameState { get; private set; }

    public int vidasPlayer1;
    public int vidasPlayer2;

    private static GameManager _instance;

    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;
    public int p1PokemonId = 1;
    public int p2PokemonId = 1;

    private GameManager()
    {
        vidasPlayer1 = 3;
        vidasPlayer2 = 3;
        gameState = GameState.MENU;
    }

    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }

    public void changeState(GameState nextState)
    {

        if (nextState == GameState.GAME && gameState != GameState.PAUSE) Reset();

        gameState = nextState;
        changeStateDelegate();
    }

    public void Reset()
    {
        vidasPlayer1 = 3;
        vidasPlayer2 = 3;
    }

}
