using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnRate = 1.0f;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    
    public bool isGameActive;
    
    private int _score = 0;

    private void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        UpdateScore();
    }

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int additionScore = 0)
    {
        _score += additionScore;
        scoreText.text = "Score: " + _score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
}
