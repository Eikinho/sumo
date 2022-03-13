using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    GameManager gm;
    public List<Vector3> listOfPosition;
    public List<Color> listOfColors;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        listOfPosition = new List<Vector3>{
            new Vector3(0,3,0),new Vector3(0,-3,0)
        };
        listOfColors = new List<Color>{
            Color.blue, Color.yellow
        };


        // listOfPosition.Add(new Vector3(0,3,0));
        // listOfPosition.Add(new Vector3(0,-3,0));
        gm = GameManager.GetInstance();
        Construir();
    }
    public void Construir()
    {
        if (gm.gameState == GameManager.GameState.GAME)
        {
            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }
            for(int i = 0; i < listOfPosition.Count; i++)
            {
                
                var enemy =  (GameObject)Instantiate(Enemy, listOfPosition[i], Quaternion.identity, transform);
                enemy.GetComponent<MovimentoEnemy>().follow_player = i+1;
                enemy.GetComponent<Renderer>().material.color = listOfColors[i];
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
