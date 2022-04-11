using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConsertButtonManager : MonoBehaviour
{


    public static ConsertButtonManager instance;
    public Animator transistor;
    public float transitionTime = 1;



    public GameObject UICanvas;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UICanvas.SetActive(false);
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
