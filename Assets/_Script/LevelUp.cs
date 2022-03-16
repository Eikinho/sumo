using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Powerups/LevelUpBuff")]
public class LevelUp : PowerupEffect
{
    public int amount_level;
    public override void Aplly(GameObject target)
    {
            target.GetComponent<MovimentoPlayer>().levelUp(amount_level);
    }
}
