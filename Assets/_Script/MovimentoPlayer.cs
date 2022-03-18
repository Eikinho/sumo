using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{

    public GameManager gm;

    public Animator animator;

    [Range(1,2)]
    public int number_player;

    Rigidbody2D m_Rigidbody;
    [Range(1,15)]
    float m_Speed;
    private GameObject montanha;
    bool is_inside;
    float montanha_radius;
    private Vector3 start_point;
    public int levelPlayer;
    public int levelPlayer_fragment;

    public int level;


    bool PointInsideSphere(Vector3 point, Vector3 center, float radius) {
        return Vector3.Distance(point, center) < radius;
     }

    // Start is called before the first frame update
    void Start()
    {
        levelPlayer_fragment = 0;
        levelPlayer = 1;
        gm = GameManager.GetInstance();
        start_point = transform.position;
        m_Rigidbody = GetComponent<Rigidbody2D>();
        animator =  GetComponent<Animator>();

        montanha = GameObject.FindGameObjectWithTag("Mountain");
        m_Speed = 5.75f;
        is_inside = true;
        montanha_radius = montanha.transform.localScale.x / 2;
        
    }

     //moves this object to the origin, waits for 2 seconds, then moves it to (10,10,10)
    IEnumerator WaitSeconds(float seconds)
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(seconds);
        reset_position();
    }

    public void reset_position(){
        transform.position = start_point;
        m_Rigidbody.velocity = new Vector3(0,0,0);
        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }


    void Reset()
        {
            
            if (number_player == 1)
            {
                if (gm.vidasPlayer1 <= 1)
                {
                    gm.vidasPlayer1--;
                    gm.changeState(GameManager.GameState.ENDGAME);
                    // Destroy(this.gameObject);
                } else 
                {
                    gm.vidasPlayer1--;
                    StartCoroutine(WaitSeconds(1f));
                }
                
            }
            else if (number_player == 2)
            {
                if (gm.vidasPlayer2 <= 1)
                {
                    gm.vidasPlayer2--;
                    // Destroy(this.gameObject);
                    gm.changeState(GameManager.GameState.ENDGAME);
                } else 
                {
                    gm.vidasPlayer2--;
                    StartCoroutine(WaitSeconds(1f));
                    // yield return new WaitForSeconds(2f);
                }
            }
            
            
            
        }


    
    public void changeSizeLevelUp(int mass, float size_x,float size_y, float speed){
        m_Rigidbody.mass += mass;
        transform.localScale += new Vector3(size_x,size_y,0);
        m_Speed+=speed;

    }
    public void levelUp(int amount_level){
        levelPlayer_fragment++;
        if (levelPlayer_fragment>=6 && levelPlayer <3){
            print("level3");
            levelPlayer = 3;
            changeSizeLevelUp(1,0.5f,0.5f,2f);
        }
        else if (levelPlayer_fragment>=3 && levelPlayer <2){
            print("level2");
            levelPlayer = 2;
            changeSizeLevelUp(1,0.5f,0.5f,1f);
        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {

        if (gm.gameState == GameManager.GameState.ENDGAME)
        {
            gm.p1PokemonId = 0;
            gm.p2PokemonId = 0;
            gm.pChoosing = 1;
        }

        else if (gm.gameState != GameManager.GameState.GAME){
            m_Rigidbody.velocity = new Vector3(0,0,0);
            return;  
        } 
        Time.timeScale = 1f;
        
        is_inside = PointInsideSphere(transform.position, montanha.transform.position, montanha_radius);

        if(number_player ==1){

            animator.SetInteger("pokeId", gm.p1PokemonId);

            if (Input.GetKey(KeyCode.RightArrow))
            {

                //rotate the sprite about the Z axis in the positive direction
                // transform.Rotate(new Vector3(0, 0, -1) * horizontal_speed * Time.deltaTime, Space.World);
                m_Rigidbody.AddForce(transform.right * -m_Speed);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //rotate the sprite about the Z axis in the positive direction
                // transform.Rotate(new Vector3(0, 0, 1) * horizontal_speed * Time.deltaTime, Space.World);
                m_Rigidbody.AddForce(transform.right * m_Speed);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                m_Rigidbody.AddForce(transform.up * m_Speed);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                //Move the Rigidbody to the left constantly at the speed you define (the red arrow axis in Scene view)
                m_Rigidbody.AddForce(transform.up * -m_Speed);
            }
        }

        else if(number_player ==2){

            animator.SetInteger("pokeId", gm.p2PokemonId);

            if (Input.GetKey(KeyCode.D))
            {

                //rotate the sprite about the Z axis in the positive direction
                m_Rigidbody.AddForce(transform.right * m_Speed);
                // transform.Rotate(new Vector3(0, 0, -1) * horizontal_speed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.A))
            {
                //rotate the sprite about the Z axis in the positive direction
                m_Rigidbody.AddForce(transform.right * -m_Speed);
                // transform.Rotate(new Vector3(0, 0, 1) * horizontal_speed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.W))
            {
                m_Rigidbody.AddForce(transform.up * m_Speed);
            }

            if (Input.GetKey(KeyCode.S))
            {
                //Move the Rigidbody to the left constantly at the speed you define (the red arrow axis in Scene view)
                m_Rigidbody.AddForce(transform.up * -m_Speed);
            }

        }

        
        

        if (is_inside == false) {
            transform.position = start_point;
            m_Rigidbody.velocity = new Vector3(0,0,0);
            Reset();
            
        }
        
    }


}
