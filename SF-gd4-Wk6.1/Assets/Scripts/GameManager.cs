using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using Unity.VisualScripting;


public class GameManager : MonoBehaviour
{

    public int score, lives;

    //a collection of objects to spawn
    //public GameObject[] targets;
    public List<GameObject> targets;

    public bool isGameOver;

    public TMP_Text scoreText, livesText;

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
            isGameOver = true;
        }

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
