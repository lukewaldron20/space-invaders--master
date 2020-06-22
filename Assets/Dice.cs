using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dice : MonoBehaviour{

    public Text score;
    public Text highScore;

    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        
    }

    public void RollDice()
    {
        int number = Random.Range(1, 10000000);
        score.text = number.ToString();

        if (number > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", number);
            highScore.text = number.ToString();
        }
        
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = "0";
    }

}
