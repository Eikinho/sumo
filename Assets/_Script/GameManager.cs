using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public enum GameState { MENU, SELECT, GAME, PAUSE, ENDGAME };
    public GameState gameState { get; private set; }

    public int vidasPlayer1;
    public int vidasPlayer2;

    public int levelPlayer1;
    public int levelPlayer2;
    private static GameManager _instance;

    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;
    public int p1PokemonId = 1;
    public int p2PokemonId = 1;
    public int pChoosing;


        

    private GameManager()
    {
        vidasPlayer1 = 3;
        vidasPlayer2 = 3;
        levelPlayer1 = 1;
        levelPlayer2 = 1;
        pChoosing = 1;

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

        if (nextState == GameState.GAME && gameState != GameState.PAUSE){
            Reset();
            GameObject.Find("LevelUpPool").GetComponent<LevelUpSpawner>().Reset();
            GameObject.Find("Player1").GetComponent<MovimentoPlayer>().ResetPower();
            GameObject.Find("Player2").GetComponent<MovimentoPlayer>().ResetPower();

        } 

        gameState = nextState;
        changeStateDelegate();
    }

    public void Reset()
    {
        vidasPlayer1 = 3;
        vidasPlayer2 = 3;
        levelPlayer1 = 1;
        levelPlayer2 = 1;
    }

}
