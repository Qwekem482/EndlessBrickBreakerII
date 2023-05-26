using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    private int stiffness = Game.turn;
    private SpriteRenderer spriteRenderer;
    public static float blockRadius;

    private void Resize()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        gameObject.transform.localScale = new Vector3(worldScreenWidth * 9.0f/87.0f / spriteRenderer.sprite.bounds.size.x, 
                                                    worldScreenWidth * 9.0f/87.0f / spriteRenderer.sprite.bounds.size.x, 1);
        
        blockRadius = gameObject.transform.localScale.x * spriteRenderer.sprite.bounds.size.x / 2;
        Debug.Log(blockRadius);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        stiffness--;

        if (stiffness == 0)
        {
            Game.score = Game.score + Game.turn;
            Destroy(gameObject);
        }
    }

}
