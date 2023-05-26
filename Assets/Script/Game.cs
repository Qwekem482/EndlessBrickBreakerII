using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject blockParent;
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject basket;
    [SerializeField] private GameObject ballGroup;
    [SerializeField] private GameObject border;

    public static int score = 0;
    public static int turn = 1;
    public static int live = 3;
    public static string time = "00:00";

    private readonly string[,] COLOR_STRING = new string[6, 4] 
    {
        {"#79E0EE", "#98EECC", "#D0F5BE", "#FBFFDC"},
        {"#E97777", "#FF9F9F", "#FCDDB0", "#FFFAD7"},
        {"#ECF9FF", "#FFFBEB", "#FFE7CC", "#F8CBA6"},
        {"#FF55BB", "#FFD3A3", "#FCFFB2", "#B6EAFA"},
        {"#C4DFDF", "#D2E9E9", "#E3F4F4", "#F8F6F4"},
        {"#FFF3E2", "#FFE5CA", "#FA9884", "#E74646"}
    };

    private float blockRadius;

    void Start()
    {
        score = 0;
        turn = 1;
        live = 3;
        time = "00:00";

        Resize(basket, 23.0f/87.0f, "onlyX");
        //Resize(ballPrefab, 2.0f/87.0f, "equal");
        Resize(blockPrefab, 9.0f/87.0f, "equal");
        Resize(border, 1.0f, "auto");

        blockRadius = blockPrefab.transform.localScale.x * blockPrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2;
        blockRadius = (float) Math.Round(blockRadius, 2);

        SpawnRandom();
    }

    void Update()
    {
        //End Level
        if(blockParent.transform.childCount == 0)
        {
            turn++;
            live = live + 2;

            Ball.speed = 10f + (float) 0.75 * Mathf.Sqrt(3 * turn) + (turn / 40);
            Basket.speed = 10f + (float) 0.75 * Mathf.Sqrt(4 * turn) + (turn / 30);

            basket.transform.position = new Vector3(0f, -7f, 10f);
            Instantiate(ballPrefab, new Vector3(0f, -6.5f, 10f), Quaternion.identity, ballGroup.transform);
            SpawnRandom();
        }

        //Out of Ball
        if(ballGroup.transform.childCount == 0)
        {
            basket.transform.position = new Vector3(0f, -7f, 10f);
            Instantiate(ballPrefab, new Vector3(0f, -6.5f, 10f), Quaternion.identity, ballGroup.transform);
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
        int numberOfBlock = UnityEngine.Random.Range(30, 90);
        int yMax = CalcMaxY();

        for(int i = 0; i < numberOfBlock; i++)
        {
            int count = 0;
            do
            {
                int x = UnityEngine.Random.Range(-4, 5);
                int y = UnityEngine.Random.Range(yMax - 9, yMax + 1);
                Vector3 position = new Vector3(blockRadius * 2 * x, blockRadius * 2 * y, 10);

                if(IsEmptyPosition(blockRadius - 0.01f, "Block", position))
                {
                    Instantiate(blockPrefab, position, Quaternion.identity, blockParent.transform);
                    break;
                }

                count++;
            }
            while(count < 1000);
        }

        ChangeColor();
    }

    private bool IsEmptyPosition(float radius, string layer, Vector3 position)
    {
        Collider2D collision = Physics2D.OverlapCircle(position, radius, LayerMask.GetMask(layer));

        if(collision == null)
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

    private void Resize(GameObject gameObject, float ratio, string mode) 
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        float scaleX = worldScreenWidth * ratio / spriteRenderer.sprite.bounds.size.x;
        float scaleY;

        if (mode.Equals("auto"))
        {
            scaleY = worldScreenHeight * ratio / spriteRenderer.sprite.bounds.size.y;
        }
        else if (mode.Equals("equal"))
        {
            scaleY = scaleX;
        }
        else if (mode.Equals("onlyX"))
        {
            scaleY = 1f;
        }
        else
        {
            throw new System.ArgumentException("Invalid mode");
        }

        gameObject.transform.localScale = new Vector3(scaleX, scaleY, 1);
    }

    private int CalcMaxY()
    {
        Vector3 position = new Vector3(0, 0, 10);
        int yMax = 0;

        do
        {
            yMax++;
            position.y = blockRadius * 2 * yMax;
            Debug.Log(IsEmptyPosition(blockRadius - 0.01f, "Border", position) + " " + position.y  + " " + yMax);
        }
        while(IsEmptyPosition(blockRadius, "Border", position));
        yMax--;

        return yMax;
    }
}
