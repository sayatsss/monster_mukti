using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour
{
    public Animator transistor;
    public float transitionTime = 1;

    public GameObject SplashCanvas;


    private void Awake()
    {
        CalcAspect();
    }
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
    private void CalcAspect()
    {
        Debug.Log("I am here");
        float r = Camera.main.aspect;


        
        Debug.Log(r);

        if (r > 0.6)
        {

            Debug.Log("4:3");
            SplashCanvas.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);


        }
        else
        {
            SplashCanvas.transform.localScale = new Vector3(1, 1, 1);

        }
            
       
    }
}
