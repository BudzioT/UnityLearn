using System;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button _button;
    private GameManager _gameManager;
    
    public int difficulty = 0;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ChangeDifficulty);
    }

    private void ChangeDifficulty()
    {
        _gameManager.StartGame(difficulty);
    }
}
