using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    GameManager gm;
    public List<Vector3> listOfPosition;

    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        listOfPosition = new List<Vector3>();
        listOfPosition.Add(new Vector3(0,3,0));
        listOfPosition.Add(new Vector3(0,-3,0));
        gm = GameManager.GetInstance();
        // Enemy.player1 = Player1;
        // Enemy.player2 = Player2;
        Construir();
    }
    public void Construir()
    {
        if (gm.gameState == GameManager.GameState.GAME)
        {
            Instantiate(Enemy,new Vector3(0,0,0), Quaternion.identity, transform);

            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }
            for(int i = 0; i < listOfPosition.Count; i++)
            {
                
                Instantiate(Enemy, listOfPosition[i], Quaternion.identity, transform);
            
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
