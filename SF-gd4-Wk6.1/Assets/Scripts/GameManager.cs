using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{

    public int score, lives;

    //a collection of objects to spawn
    //public GameObject[] targets;
    public List<GameObject> targets;
    public Vector2 spawnRate;

    public bool isGameOver;
    public UnityEvent gameOver;


    [Header("User Interface Elements")]
    public GameObject gameOverScreen;

    public TMP_Text scoreText, livesText, scoreTextGameOver, highscoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnObjects());
        Debug.Log(targets.Count);


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateUI(int scoreChange, int livesChanged)
    {
       
        score += scoreChange;
        lives += livesChanged;

        scoreText.text = "Score: " + score;
        livesText.text = "lives: " + lives;

        if (lives <= 0)
        {
            gameOverState();
        }

    }

    void gameOverState() 
    {
        isGameOver = true;
        gameOverScreen.SetActive(true);

        gameOver.Invoke();
        scoreTextGameOver.text = "SCORE : " + score;
        highscoreText.text = "HIGHSCORE : " + PlayerPrefs.GetInt("Highscore");

        if (PlayerPrefs.GetInt("Highscore") < score)
        {
            highscoreText.text = "OLD SCORE : " + PlayerPrefs.GetInt("Highscore");
            PlayerPrefs.SetInt("Highscore", score);
            

            scoreTextGameOver.text = "HIGHSCORE : " + score;

        }

    }

    public void restartLevel()
    {
        SceneManager.LoadScene(0);

    }

    IEnumerator spawnObjects()
    {
        while (!isGameOver)
        {
            //pick and object to spawn
            int spawnIndex = Random.Range(0, targets.Count);

            //Spawn an object
            Instantiate(targets[spawnIndex]);

            float randomWaitTime = Random.Range(0.5f, 3f);
            //wait for x seconds
            yield return new WaitForSeconds(randomWaitTime);
        }

    }
}
