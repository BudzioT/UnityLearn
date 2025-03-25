using System;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private Hunger _hunger;
    public GameUI gameUi;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameUi = GameObject.Find("GameUI").GetComponent<GameUI>();
        _hunger = GetComponent<Hunger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameUi.lives -= 1;
            if (gameUi.lives < 0)
            {
                Debug.Log("Game Over!");
            }
            else
            {
                Debug.Log($"{gameUi.lives} lives left!");
            }
        }
        else if (_hunger != null)
        {
            _hunger.Feed();
            Destroy(other.gameObject);

            if (_hunger.timesToFeed <= 0)
            {
                gameUi.score += 1;
                Destroy(gameObject);
                Debug.Log($"Score = {gameUi.score}");
            }
        }
    }
}
