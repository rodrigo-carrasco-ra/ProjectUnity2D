using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLifes=3;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] TextMeshProUGUI scoreText;
    SceneLoader sceneLoader;


    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        sceneLoader = FindObjectOfType<SceneLoader>();

    }

    void Start() 
    {
        lifeText.text = playerLifes.ToString();
        scoreText.text = score.ToString();

    }

    public void ProcessPlayerDeath()
    {
        if(playerLifes>1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    void TakeLife()
    {
        playerLifes = playerLifes - 1;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        lifeText.text = playerLifes.ToString();
        if (playerLifes==0)
        {
            SceneManager.LoadScene(7);
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();

    }

    void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(7);
        Destroy(gameObject);
    }
    
}
