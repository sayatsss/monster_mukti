using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCustomisation : MonoBehaviour
{

    public static PlayerCustomisation instance;

    private void Awake()
    {
        instance = this;
    }

    public Animator transistor;
    public float transitionTime = 1;


    public void BacktoGame()
    {
        StartCoroutine(loadSceneTrans(1));
    }


    public IEnumerator loadSceneTrans(int level)
    {
        // Debug.Log("its trigger");
        Time.timeScale = 1;
        transistor.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        //  Debug.Log("its afetr time");
        SceneManager.LoadSceneAsync(level);
    }
}
