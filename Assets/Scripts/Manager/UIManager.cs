using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    public GameObject GameUIPanel;
    public GameObject MenuPanel;
    public GameObject GamePanel;
    public GameObject PausePanel;
    public GameObject GameEndPanel;
    public GameObject BloodHint;
    public GameObject GarudaMeter;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        MenuPanel.SetActive(false);
        GameUIPanel.SetActive(false);
        PausePanel.SetActive(false);
        GameEndPanel.SetActive(false);
        BloodHint.SetActive(false);
        GarudaMeter.SetActive(false);
    }

    public void PauseButton()
    {
        PausePanel.SetActive(true);
        GamePanel.SetActive(false);
       // PausePanel.transform.DOScale(1f, 0.5f);
        GameManager.instance.GameStateChange(GameManager.GameState.pause);
        Time.timeScale = 0;
        


    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        GameManager.instance.GameStateChange(GameManager.GameState.game);
        PausePanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        
    }

    public IEnumerator BloodScreenSplash()
    {
        if(BloodHint==true)
        {
            BloodHint.SetActive(false);
        }

        BloodHint.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        BloodHint.SetActive(false);
    }

    public void HelpForTheGame()
    {
        Debug.Log("Help panel open");
    }
}
