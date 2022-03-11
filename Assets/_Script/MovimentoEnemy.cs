using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoEnemy : MonoBehaviour
{

    Rigidbody2D m_Rigidbody;
    private GameObject montanha;
    public GameObject player1;
    public GameObject player2;
    bool is_inside;
    bool player1_alive;
    bool player2_alive;
    Vector3 direction_player1;
    Vector3 direction_player2;
    float distance_player1;
    float distance_player2;
    
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
        m_Rigidbody = GetComponent<Rigidbody2D>();
        montanha = GameObject.FindGameObjectWithTag("Mountain");
        player1_alive = check_is_alive(player1);
        player2_alive = check_is_alive(player2);
        
    }

    // Update is called once per frame
    void Update()
    {
        player1_alive = check_is_alive(player1);
        player2_alive = check_is_alive(player2);

        if (player1_alive){
            Vector3 player1_position = player1.transform.position;
            direction_player1 = player1_position - transform.position;
            distance_player1 = Vector3.Distance(transform.position, player1_position);
        }
        if(player2_alive){
            Vector3 player2_position = player2.transform.position;
            direction_player2 = player2_position - transform.position;
            distance_player2 = Vector3.Distance(transform.position, player2_position);
        }
        if((player1_alive == true) && (player2_alive == true)){
            if(distance_player1 < distance_player2){
                m_Rigidbody.AddForce(direction_player1.normalized*0.5f);
            }
            else{
                m_Rigidbody.AddForce(direction_player2.normalized*0.5f);
            }
        }
        else if(player1_alive == true){
            m_Rigidbody.AddForce(direction_player1.normalized*0.5f);
        }
        else if(player2_alive == true){
            m_Rigidbody.AddForce(direction_player2.normalized*0.5f);
        }

        
        
    }
}
