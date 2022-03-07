using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UI_MenuPrincipal : MonoBehaviour
{

    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    public void StartButton()
    {
        gm.changeState(GameManager.GameState.GAME);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
