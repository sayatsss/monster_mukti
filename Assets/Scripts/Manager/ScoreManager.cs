using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField]private Text _coinText;
    [SerializeField]private Text _scoreText;
    [SerializeField] private Text _finalScoreText;
    [HideInInspector]public float _coinCount, _scoreCount;
    [SerializeField] private Slider coinIndicator;

    private float _tempSliderValue = 0;
    private int _tempScore = 0;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        coinIndicator.value = _tempSliderValue;
        _coinText.text = _coinCount.ToString();
        _scoreText.text = _scoreCount.ToString();
    }
    private void Update()
    {
        if(GameManager.instance.GameStatus==GameManager.GameState.game.ToString())
        {
            _tempScore++;
            if (_tempScore > 25)
            {
                _scoreCount++;
                _scoreText.text = (_scoreCount).ToString("00") + " m";
                _finalScoreText.text= (_scoreCount).ToString("00")+" m";
                _tempScore = 0;
            }
        }
    }

    public void AddCoin(GameObject coinGameobject)
    {
        _coinCount += 1;
        _tempSliderValue = _coinCount;
        coinIndicator.value = _tempSliderValue;
        _coinText.text = _coinCount.ToString();
        if(_tempSliderValue>coinIndicator.maxValue)
        {
            coinIndicator.value = 0;
            _tempSliderValue = 0;
            _coinCount = 0;
            StartCoroutine(TicketAddition());
        }

    }

    private IEnumerator TicketAddition()
    {
        yield return new WaitForSeconds(0f);
        TicketManager.instance.ticketCount+=1;

        if(TicketManager.instance.ticketCount==TicketManager.instance.Tickets.Count && CharacterStateManager.Instance.IsPlayerActive)
        {
            StartCoroutine(PortalFollow.instance.ActivatePortal());
        }

        StartCoroutine(TicketManager.instance.TicketActive());
        
        StopCoroutine(TicketAddition());
    }
}
