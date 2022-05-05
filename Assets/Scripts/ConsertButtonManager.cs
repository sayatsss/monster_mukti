using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConsertButtonManager : MonoBehaviour
{


    public static ConsertButtonManager instance;
    public Animator transistor;
    public float transitionTime = 1;

    public GameObject UICanvas;

    public Text HighScore;
    public Text LastScore;
    



    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UICanvas.SetActive(false);
    }

    private void Update()
    {

        //Need to change the aciton once the setup is done.
        //HighScore.text = ScoreHandler.instance.highScore.ToString();
        //LastScore.text = ScoreHandler.instance.levelScore.ToString();
    }
    public void RestartGame()
    {

        //
        StartCoroutine(loadSceneTrans(0));
        // SceneManager.LoadSceneAsync(0);

    }
    private IEnumerator loadSceneTrans(int level)
    {
        Debug.Log("its trigger");
        Time.timeScale = 1;
        transistor.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        Debug.Log("its afetr time");
        SceneManager.LoadSceneAsync(level);
    }

}
