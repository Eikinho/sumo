using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EndGame : MonoBehaviour
{


    GameManager gm;
    // Start is called before the first frame update
    public Text message;
    private void OnEnable(){
        gm = GameManager.GetInstance();
        message.text = "";
        if (gm.vidasPlayer1 <= 0){
            message.text = "VENCEDOR: PLAYER 2";
        }
        else{
            message.text = "VENCEDOR: PLAYER 1";
        }
    }

    public void Restart(){
        gm.pChoosing = 1;
        gm.changeState(GameManager.GameState.SELECT);

    }

}
