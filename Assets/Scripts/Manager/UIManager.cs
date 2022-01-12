using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public GameObject PausePanel;

    private void Start()
    {
        PausePanel.SetActive(false);
    }

    public void PauseButton()
    {
        PausePanel.SetActive(true);
       // PausePanel.transform.DOScale(1f, 0.5f);
        GameManager.instance.GameStateChange(GameManager.GameState.pause);
        Time.timeScale = 0;
        


    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        GameManager.instance.GameStateChange(GameManager.GameState.game);
        PausePanel.SetActive(false);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        
    }
    public void HelpForTheGame()
    {
        Debug.Log("Help panel open");
    }
}
