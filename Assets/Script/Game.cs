using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject blockParent;
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject basket;

    public static int score = 0;
    public static int turn = 1;
    public static int live = 3;
    public static string time = "00:00";

    private readonly string[,] COLOR_STRING = new string[6, 4] 
    {
        {"#4871E8", "#B175FF", "#AB729F", "#2D1674"},
        {"#778A35", "#B4FEE7", "#A16AE8", "#FD49A0"},
        {"#C55FFC", "#EFDCF9", "#323E42", "#7954A1"},
        {"#050A30", "#000C66", "#0000FF", "#7EC8E3"},
        {"#FF5765", "#FFDB15", "#8A6FDF", "#A8E10C"},
        {"#AA381E", "#F5BD02", "#E0DDDD", "#42B89A"}
    };

    void Start()
    {
        SpawnRandom();
    }

    void Update()
    {
        //End Level
        if(blockParent.transform.childCount == 0)
        {
            Instantiate(ballPrefab, new Vector3(0f, -6.5f, 10f), Quaternion.identity, basket.transform);
            SpawnRandom();
        
            turn++;
            live = live + 2;
            Ball.speed = 10f + (float) 0.75 * Mathf.Sqrt(2 * turn) + (turn / 40);
            Basket.speed = 10f + (float) 0.75 * Mathf.Sqrt(4 * turn) + (turn / 30);
        }

        //Out of Ball
        if(basket.transform.childCount == 0)
        {
            basket.transform.position = new Vector3(0f, -7f, 10f);
            Instantiate(ballPrefab, new Vector3(0f, -6.5f, 10f), Quaternion.identity, basket.transform);
            ChangeColor();
            live--;
        }

        //GameOver
        if(live == -1)
        {
            GameOver.score = score.ToString();
            GameOver.turn = turn.ToString("00");
            GameOver.time = time;
            SceneManager.LoadScene(2);
        }

        time = GetTimeString(Time.timeSinceLevelLoad);
    }



    //Spawn block
    private void SpawnRandom()
    {
        float blockRadius = 0.49f;
        int numberOfBlock = UnityEngine.Random.Range(30, 81);

        for(int i = 0; i < numberOfBlock; i++)
        {
            int count = 0;
            while(true)
            {
                int x = UnityEngine.Random.Range(-4, 5);
                int y = UnityEngine.Random.Range(-3, 6); 
                Vector3 position = new Vector3(x, y, 10);

                if(IsEmptyPosition(blockRadius, "Block", position))
                {
                    Instantiate(blockPrefab, position, Quaternion.identity, blockParent.transform);
                    break;
                }

                count++;

                if(count > 1000) break;
            }
        }

        ChangeColor();
    }

    private bool IsEmptyPosition(float radius, string layer, Vector3 position)
    {
        Collider2D collision = Physics2D.OverlapCircle(position, radius, LayerMask.GetMask(layer));

        if(collision == false)
        {
            return true;
        }

        return false;
    }



    //Change Color of Game
    private void ChangeColor()
    {
        string[] color = new string[5];
        color = GetColor();

        basket.GetComponent<SpriteRenderer>().color = GetColorFromHex(color[0]);
        //border.color = GetColorFromHex(color[1]);

        for(int i = 0; i < blockParent.transform.childCount; i++)
        {
            blockParent.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = GetColorFromHex(color[2]);
        }

        for(int i = 0; i < basket.transform.childCount; i++)
        {
            basket.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = GetColorFromHex(color[3]);
        }
    }

    private string[] GetColor()
    {
        string[] color = new string[4];
        int colorGroup = UnityEngine.Random.Range(0, 6);

        for(int i = 0; i < 4; i++)
        {
            color[i] = COLOR_STRING[colorGroup, i];
        }

        System.Random random = new System.Random();
        color = color.OrderBy(x => random.Next()).ToArray();

        return color;
    }

    private Color GetColorFromHex(string colorCode)
    {
        Color color = Color.white;
        ColorUtility.TryParseHtmlString(colorCode, out color);
        return color;
    }

    private double CalcLuminance(Color color)
    {
        return 0.2126 * color.r + 0.7152 * color.g + 0.0722 * color.b;
    }

    private string GetTimeString(float timeInSec)
    {
        int minute = (int) timeInSec / 60;
        int second = (int) timeInSec % 60;
        return minute.ToString("00") + ":" + second.ToString("00");
    }
}
