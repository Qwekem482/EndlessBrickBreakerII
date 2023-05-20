using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Text scoreDisplay;
    [SerializeField] private Text timeDisplay;
    [SerializeField] private Text turnDisplay;

    public static string score;
    public static string time;
    public static string turn;

    void Start()
    {
        scoreDisplay.text = score;
        timeDisplay.text = time;
        turnDisplay.text = turn;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
