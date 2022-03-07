using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    
    public enum GameState { MENU, GAME, PAUSE, ENDGAME };
    public GameState gameState { get; private set; }
    public int vidasPlayer1;
    public int vidasPlayer2;
    private static GameManager _instance;
    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }

    private GameManager()
    {
        vidasPlayer1 = 3;
        vidasPlayer2 = 3;
        gameState = GameState.GAME;
    }

}
