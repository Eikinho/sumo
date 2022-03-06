using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{

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
    }

    // Update is called once per frame
    void Update()
    {
        is_inside = PointInsideSphere(transform.position, montanha.transform.position, montanha_radius);
        Debug.Log(is_inside);


        if (Input.GetKey(KeyCode.RightArrow))
        {

            //rotate the sprite about the Z axis in the positive direction
            transform.Rotate(new Vector3(0, 0, -1) * horizontal_speed * Time.deltaTime, Space.World);

            //Move the Rigidbody to the right constantly at speed you define (the red arrow axis in Scene view)
            // m_Rigidbody.velocity = transform.right * m_Speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //rotate the sprite about the Z axis in the positive direction
            transform.Rotate(new Vector3(0, 0, 1) * horizontal_speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {

            m_Rigidbody.AddForce(transform.right * 1.0f);


            //Move the Rigidbody to the right constantly at speed you define (the red arrow axis in Scene view)
            // m_Rigidbody.velocity = transform.right * m_Speed;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //Move the Rigidbody to the left constantly at the speed you define (the red arrow axis in Scene view)
            m_Rigidbody.velocity = -transform.right * m_Speed;
        }
        // else{
        //     m_Rigidbody.velocity = transform.right * 0;
        // }
    }


}
