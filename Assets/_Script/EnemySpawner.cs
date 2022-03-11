using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    GameManager gm;

    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        // Enemy.player1 = Player1;
        // Enemy.player2 = Player2;
        Construir();
    }
    public void Construir()
    {
        if (gm.gameState == GameManager.GameState.GAME)
        {
            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }
            for(int i = 0; i < 12; i++)
            {
                for(int j = 0; j < 4; j++){
                    Vector3 posicao = new Vector3(-9 + 1.55f * i, 4 - 0.55f * j);
                    Instantiate(Enemy, posicao, Quaternion.identity, transform);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}