using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour
{
    public Animator transistor;
    public float transitionTime = 1;

    private void Start()
    {
        StartCoroutine(loadSceneTrans(1));
        
    }
    private IEnumerator loadSceneTrans(int level)
    {
        yield return new WaitForSeconds(3f);
        transistor.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        Debug.Log("its afetr time");
        SceneManager.LoadSceneAsync(level);
    }
}
