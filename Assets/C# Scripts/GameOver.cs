using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverPannel;



    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Chicken") == null)
        {
            GameOverPannel.SetActive(true);
        }
    }

    public void Restart()
    {

        SceneManager.LoadScene(0);
    }
}
