using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSpawner : MonoBehaviour
{
    GameManager gm;
    public GameObject LevelUpBuff;
    public GameObject montanha;
    float timer;

    bool inside;

    Vector3 position;

    Vector3 montanha_scale;

    float montanha_radius;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        timer = 0f;
        inside = false;
        montanha_scale = montanha.transform.localScale;

        montanha_radius = montanha_scale.x / 2;
    }
    
    public bool PointInsideSphere(Vector3 point, Vector3 center, float radius) {
        return Vector3.Distance(point, center) < radius;
     }
    

    // Update is called once per frame
    void Update()
    {
        if(gm.gameState == GameManager.GameState.GAME){
            timer += Time.deltaTime;
            if (timer >=2){

                while (inside == false){
                    float dirX = Random.Range(-montanha_radius, montanha_radius);
                    float dirY = Random.Range(-montanha_radius, montanha_radius);
                    position = new Vector3(dirX,dirY,0);
                    inside = PointInsideSphere(position, montanha.transform.position, montanha_radius);
                }
                Instantiate(LevelUpBuff, position, Quaternion.identity, transform);
                timer = 0;
                inside = false;
            }

        }
    }

    public void Reset(){
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
            }
    }
    // public void Construir()
    // {
    //     if (gm.gameState == GameManager.GameState.GAME)
    //     {
    //         foreach (Transform child in transform) {
    //             GameObject.Destroy(child.gameObject);
    //         }
    //         for(int i = 0; i < listOfPosition.Count; i++)
    //         {
                
    //             var enemy =  (GameObject)Instantiate(Enemy, listOfPosition[i], Quaternion.identity, transform);
    //             enemy.GetComponent<MovimentoEnemy>().follow_player = i+1;
    //             enemy.GetComponent<Renderer>().material.color = listOfColors[i];
                
    //         }
    //     }
    // }
}
