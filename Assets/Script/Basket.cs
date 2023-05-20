using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public static float speed = 10f;

    public void FixedUpdate() 
    {
        float movement = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * movement * speed;
    }
}
