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
    public GameObject ChariotMeter;


    public Animator transistor;
    public float transitionTime=1;

    public GameObject StartButton,MenuBoard;


    private void Awake()
    {
        instance = this;
        StartButton.transform.DOMoveY(-500f, 0.1f);
        MenuBoard.transform.DOMoveY(3000f, 0.1f);
    }
    private void Start()
    {
        MenuPanel.SetActive(false);
        GameUIPanel.SetActive(false);
        PausePanel.SetActive(false);
        GameEndPanel.SetActive(false);
        BloodHint.SetActive(false);
        GarudaMeter.SetActive(false);
        ChariotMeter.SetActive(false);
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
        //StartCoroutine(FollowAI.Instance.FirstAsuraAttack());
        PausePanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void RestartGame()
    {
        
        //
        StartCoroutine(loadSceneTrans(1));
       // SceneManager.LoadSceneAsync(0);
        
    }
    public void Customisationpage()
    {
        Debug.Log("Customisation page is been loaded");
        StartCoroutine(loadSceneTrans(4));
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

    private IEnumerator loadSceneTrans(int level)
    {
       // Debug.Log("its trigger");
        Time.timeScale = 1;
        transistor.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
      //  Debug.Log("its afetr time");
        SceneManager.LoadSceneAsync(level);
    }
}
