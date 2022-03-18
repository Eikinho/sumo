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
        m_Rigidbody.AddForce(direction.normalized*6.2f);
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
}

    // Update is called once per frame
    void FixedUpdate()
    {

        if (gm.gameState != GameManager.GameState.GAME){
            m_Rigidbody.velocity = new Vector3(0,0,0);
            return;
        } 
        StartCoroutine(WaitSeconds(0.25f));

        
        
    }
}
