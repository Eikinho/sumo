using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerupEffect powerupEffect;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1")|| collision.gameObject.CompareTag("Player2")){
            Destroy(gameObject);
            powerupEffect.Aplly(collision.gameObject);
        }
        
    }


}
