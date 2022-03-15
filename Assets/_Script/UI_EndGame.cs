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
            message.text = "Vencedor: Player 2";
        }
        else{
            message.text = "Vencedor: Player 1";
        }
    }

    public void Restart(){
        gm.changeState(GameManager.GameState.SELECT);
    }

}
