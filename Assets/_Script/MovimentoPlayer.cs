using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{

    GameManager gm;

    [Range(1,2)]
    public int number_player;

    Rigidbody2D m_Rigidbody;
    [Range(1,15)]
    float m_Speed;
    float horizontal_speed;
    private GameObject montanha;
    bool is_inside;
    float montanha_radius;
    bool PointInsideSphere(Vector3 point, Vector3 center, float radius) {
        return Vector3.Distance(point, center) < radius;
     }

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();

        montanha = GameObject.FindGameObjectWithTag("Mountain");
        m_Speed = 2.0f;
        is_inside = true;
        horizontal_speed = 300.0f;
        montanha_radius = montanha.transform.localScale.x / 2;
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {

        if (gm.gameState != GameManager.GameState.GAME) return;

        Debug.Log($"Vidas P1: {gm.vidasPlayer1} \t | \t Vidas P2 {gm.vidasPlayer2}");

        is_inside = PointInsideSphere(transform.position, montanha.transform.position, montanha_radius);

        if(number_player ==1){
            if (Input.GetKey(KeyCode.RightArrow))
            {

                //rotate the sprite about the Z axis in the positive direction
                transform.Rotate(new Vector3(0, 0, -1) * horizontal_speed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //rotate the sprite about the Z axis in the positive direction
                transform.Rotate(new Vector3(0, 0, 1) * horizontal_speed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                m_Rigidbody.AddForce(transform.right * 1.0f);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                //Move the Rigidbody to the left constantly at the speed you define (the red arrow axis in Scene view)
                m_Rigidbody.velocity = -transform.right * m_Speed;
            }
        }

        else if(number_player ==2){
            if (Input.GetKey(KeyCode.D))
            {

                //rotate the sprite about the Z axis in the positive direction
                transform.Rotate(new Vector3(0, 0, -1) * horizontal_speed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.A))
            {
                //rotate the sprite about the Z axis in the positive direction
                transform.Rotate(new Vector3(0, 0, 1) * horizontal_speed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.W))
            {
                m_Rigidbody.AddForce(transform.right * 1.0f);
            }

            if (Input.GetKey(KeyCode.S))
            {
                //Move the Rigidbody to the left constantly at the speed you define (the red arrow axis in Scene view)
                m_Rigidbody.velocity = -transform.right * m_Speed;
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME)
        {
            gm.changeState(GameManager.GameState.PAUSE);
        }

        if (is_inside == false) {
            Reset();
        }

        void Reset()
        {
            
            if (number_player == 1)
            {
                if (gm.vidasPlayer1 <= 1)
                {
                    gm.vidasPlayer1--;
                    Destroy(this.gameObject);
                } else 
                {
                    gm.vidasPlayer1--;
                    transform.position = new Vector3(0,0,0);
                }
                
            }
            else if (number_player == 2)
            {
                if (gm.vidasPlayer2 <= 1)
                {
                    gm.vidasPlayer2--;
                    Destroy(this.gameObject);
                } else 
                {
                    gm.vidasPlayer2--;
                    transform.position = new Vector3(0,0,0);
                }
            }
            
        }
        
    }


}
