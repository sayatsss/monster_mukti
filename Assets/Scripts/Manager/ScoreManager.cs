using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField]private Text _coinText;
    [SerializeField]private Text _scoreText;
    [SerializeField] private Text _finalScoreText;
    [HideInInspector]public float _coinCount, _scoreCount;
    private int _tempScore = 0;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        _coinText.text = _coinCount.ToString();
        _scoreText.text = _scoreCount.ToString();
    }
    private void Update()
    {
        if(GameManager.instance.GameStatus==GameManager.GameState.game.ToString())
        {
            _tempScore++;
            if (_tempScore > 20)
            {
                _scoreCount++;
                _scoreText.text = (_scoreCount).ToString("00");
                _finalScoreText.text= (_scoreCount).ToString("00");
                _tempScore = 0;
            }
        }
        
        
    }

    public void AddCoin()
    {
        _coinCount += 1;
        _coinText.text = _coinCount.ToString();
    }
}
