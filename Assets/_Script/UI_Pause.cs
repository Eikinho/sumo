using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pause : MonoBehaviour
{
   
    GameManager gm;
    // Start is called before the first frame update
    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    public void Retornar()
    {

        Time.timeScale = 1f;
        gm.changeState(GameManager.GameState.GAME);
        
    }

    public void Inicio()
    {
        Time.timeScale = 1f;
        gm.pChoosing = 1;
        gm.changeState(GameManager.GameState.MENU);
        
    }
}