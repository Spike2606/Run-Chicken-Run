using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
   public TMP_Text ScoreText;
   private float score;

   public TMP_Text highScore;


   void Start()
   {

    highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

   }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Chicken") != null)
        {
            score += 1 * Time.deltaTime;
            ScoreText.text = ((int)score).ToString();

            if (score>PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", (int)score);
                highScore.text = ((int)score).ToString("0");
            }

        }



    }
}
