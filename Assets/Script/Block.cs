using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private int stiffness = Game.turn;

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
