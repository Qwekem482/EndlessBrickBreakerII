using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public static float speed = 10f;

    private readonly int DETECTION_cONST = 20;
    private Vector3 touchStart = new Vector3(0, 0, 0);
    private Vector3 touchEnd = new Vector3(0, 0, 0);


    void Update() 
    {
        
        WindowsMove();
        AndroidMove();

    }

    private void WindowsMove()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * movement * speed;
    }

    private void AndroidMove()
    {
        if(Input.touchCount > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                touchStart = Input.touches[0].position;
            }

            if(Input.touches[0].phase == TouchPhase.Moved)
            {
                touchEnd = Input.touches[0].position;

                if(touchStart.x - touchEnd.x > DETECTION_cONST)
                {
                    GetComponent<Rigidbody2D>().velocity = Vector3.left * speed * 0.75f;
                }
                else if(touchStart.x - touchEnd.x < -DETECTION_cONST)
                {
                    GetComponent<Rigidbody2D>().velocity = Vector3.right * speed * 0.75f;
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                }
            }

            if(Input.touches[0].phase == TouchPhase.Stationary)
            {
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                touchStart = Input.touches[0].position;
            }
        }
    }
}
