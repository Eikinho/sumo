using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoEnemy : MonoBehaviour
{

    GameManager gm;

    Rigidbody2D m_Rigidbody;
    private GameObject montanha;
    private GameObject player;
    bool is_inside;
    bool player_alive;
    Vector3 direction_player;
    float distance_player;
    public int follow_player;
    bool PointInsideSphere(Vector3 point, Vector3 center, float radius) {
        return Vector3.Distance(point, center) < radius;
    }

    bool check_is_alive(GameObject player){
        if (player == null){
            return false;
        }
        else{
            return true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        if(follow_player == 1){
            player = GameObject.FindGameObjectWithTag("Player1");    
        }
        else{
            player = GameObject.FindGameObjectWithTag("Player2");
            
        }
        m_Rigidbody = GetComponent<Rigidbody2D>();
        montanha = GameObject.FindGameObjectWithTag("Mountain");
        player_alive = check_is_alive(player);
    }

    //moves this object to the origin, waits for 2 seconds, then moves it to (10,10,10)
    IEnumerator WaitSeconds(float seconds)
    {
        Vector3 direction =return_direction();
        yield return new WaitForSeconds(seconds);
        m_Rigidbody.AddForce(direction.normalized*1.2f);
    }

    Vector3 return_direction(){
        player_alive = check_is_alive(player);
        // player2_alive = check_is_alive(player2);

        if (player_alive){
            Vector3 player_position = player.transform.position;
            direction_player = player_position - transform.position;
            distance_player = Vector3.Distance(transform.position, player_position);
            return direction_player;
        }
        else{
            return new Vector3(0,0,0);
        }
        // if(player2_alive){
        //     Vector3 player2_position = player2.transform.position;
        //     direction_player2 = player2_position - transform.position;
        //     distance_player2 = Vector3.Distance(transform.position, player2_position);
        // }
        // if((player1_alive == true) && (player2_alive == true)){
        //     if(distance_player1 < distance_player2){
        //         return direction_player1;
        //         // m_Rigidbody.AddForce(direction_player1.normalized*0.5f);
        //     }
        //     else{
        //         return direction_player2;
        //         // m_Rigidbody.AddForce(direction_player2.normalized*0.5f);
        //     }
        // }
        // else if(player1_alive == true){
        //     return direction_player1;
        //     // m_Rigidbody.AddForce(direction_player1.normalized*0.5f);
        // }
        // else if(player2_alive == true)
        // {
        //     return direction_player2;
        //     // m_Rigidbody.AddForce(direction_player2.normalized*0.5f);
        // }
        // else{
        //     return new Vector3(0,0,0);
        // }
}

    // Update is called once per frame
    void Update()
    {

        if (gm.gameState != GameManager.GameState.GAME) return;
        StartCoroutine(WaitSeconds(0.25f));
        // player1_alive = check_is_alive(player1);
        // player2_alive = check_is_alive(player2);

        // if (player1_alive){
        //     Vector3 player1_position = player1.transform.position;
        //     direction_player1 = player1_position - transform.position;
        //     distance_player1 = Vector3.Distance(transform.position, player1_position);
        // }
        // if(player2_alive){
        //     Vector3 player2_position = player2.transform.position;
        //     direction_player2 = player2_position - transform.position;
        //     distance_player2 = Vector3.Distance(transform.position, player2_position);
        // }
        // if((player1_alive == true) && (player2_alive == true)){
        //     if(distance_player1 < distance_player2){
        //         m_Rigidbody.AddForce(direction_player1.normalized*0.5f);
        //     }
        //     else{
        //         m_Rigidbody.AddForce(direction_player2.normalized*0.5f);
        //     }
        // }
        // else if(player1_alive == true){
        //     m_Rigidbody.AddForce(direction_player1.normalized*0.5f);
        // }
        // else if(player2_alive == true){
        //     m_Rigidbody.AddForce(direction_player2.normalized*0.5f);
        // }

        
        
    }
}
