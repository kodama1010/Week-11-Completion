using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;   

public class GameManager : MonoBehaviour
{
    public static GameManager instance;     
    public int score = 0;                   
    public TextMeshProUGUI scoreText;       

    public GameObject enemyOnePrefab;       

    void Awake()
    {
        // GameManager instace check
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // spawn enemies
        InvokeRepeating("CreateEnemyOne", 1, 2);

        // initialize score display
        UpdateScoreUI();
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }

    // increases score and updates text
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    // refreshes the on screen text
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
