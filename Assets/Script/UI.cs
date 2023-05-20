using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text scoreDisplay;
    [SerializeField] private Text timeDisplay;
    [SerializeField] private Text livesDisplay;
    [SerializeField] private Text turnDisplay;


    // Update is called once per frame
    void Update()
    {
        timeDisplay.text = Game.time;
        scoreDisplay.text = Game.score.ToString("00");
        turnDisplay.text = Game.turn.ToString("00");
        livesDisplay.text = Game.live.ToString("00");
    }
}
