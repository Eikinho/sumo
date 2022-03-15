using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UI_MenuPrincipal : MonoBehaviour
{

    GameManager gm;
    // Start is called before the first frame update
    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    public void StartButton()
    {
        gm.changeState(GameManager.GameState.SELECT);
    }

}
