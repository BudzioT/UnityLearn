using UnityEngine;

public class DestroyOutOfBonds : MonoBehaviour
{
    public float topBound = 30f;
    public float bottomBound = -10f;
    public float leftBound = -32f;
    public float rightBound = 20f;
    public GameUI gameUi;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameUi = GameObject.Find("GameUI").GetComponent<GameUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (
            transform.position.z < bottomBound || 
            transform.position.x < leftBound || 
            transform.position.x > rightBound
            )
        {
            if (gameUi.lives < 0)
            {
                Debug.Log("Game Over!");
            }
            else
            {
                gameUi.lives -= 1;
                Debug.Log($"{gameUi.lives} lives left!");
            }
            
            Destroy(gameObject);
        }
    }
}
