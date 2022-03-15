using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff : PowerupEffect
{
    public int amount;
    public override void Aplly(GameObject target)
    {
        if(target.GetComponent<MovimentoPlayer>().number_player == 1){
            target.GetComponent<MovimentoPlayer>().gm.vidasPlayer1 += amount;
        }
        else{
            target.GetComponent<MovimentoPlayer>().gm.vidasPlayer2 += amount;
        }
    }
}
