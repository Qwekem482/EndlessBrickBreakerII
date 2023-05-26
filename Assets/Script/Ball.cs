using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static float speed = 10f;
    
    [SerializeField] private AudioSource borderBounce;
    [SerializeField] private AudioSource blockBounce;
    [SerializeField] private AudioSource basketBounce;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Push();
    }

    public void Push()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    private float CalcDirection(Vector2 ballPosition, Vector2 basketPosition, float basketWidth)
    {
        return (ballPosition.x - basketPosition.x) / basketWidth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Basket") || collision.gameObject.CompareTag("Ball"))
        {
            float directionFactor = CalcDirection(transform.position, collision.transform.position, collision.collider.bounds.size.x);
            Vector2 direction = new Vector2(directionFactor, 1).normalized;

            GetComponent<Rigidbody2D>().velocity = direction * speed;
            basketBounce.Play();
        }

        if(collision.gameObject.CompareTag("DeathLine"))
        {
            gameObject.transform.parent = null;
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Block"))
        {
            blockBounce.Play();
        }

        if(collision.gameObject.CompareTag("Border"))
        {
            borderBounce.Play();
        }
    }
}
