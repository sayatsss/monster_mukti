using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]private Animator characterAnimator;

    private void Start()
    {
        characterAnimator.SetBool("IsIdle", true);
    }
    public void LoadGame()
    {
        SceneManager.LoadSceneAsync(1,LoadSceneMode.Single);
    }
}
