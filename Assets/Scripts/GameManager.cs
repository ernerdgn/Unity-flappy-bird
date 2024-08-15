using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text score_text;
    public GameObject play_button;
    public GameObject game_over_img;

    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;  // bound frame rate with 60
        Pause();  // pause at start
    }

    public void Play()
    {
        score = 0;
        score_text.text = score.ToString();
        
        play_button.SetActive(false);  // hide imgs
        game_over_img.SetActive(false);

        Time.timeScale = 1f;  // start the time scale
        
        player.enabled = true;  // enable player component

        Pipes[] pipes = FindObjectsOfType<Pipes>();  // get pipes
        
        for (int i = 0; i < pipes.Length; i++)  // clean if any existing pipes
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;  // set time to 0 to pause
        player.enabled = false;  // freeze player component
    }

    public void GameOver()
    {
        //Debug.Log("Game Over");  // simple log msg
        game_over_img.SetActive(true);  // show imgs
        play_button.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        score++;  // increase score
        score_text.text = score.ToString();  // write to screen
    }
}
