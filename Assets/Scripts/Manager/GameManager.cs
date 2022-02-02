using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //[HideInInspector]public GameState gameState = new GameState();
    [HideInInspector] public string GameStatus = "";

    private bool FogChange = false;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //Need to change once the menu is done.
        //GameStateChange(GameState.game);
        StartCoroutine(GameStartAction());
    }

    private void Update()
    {
        

    }
    IEnumerator GameStartAction()
    {
        GameStateChange(GameState.menu);
        //RenderSettings.fogDensity = 0.004f;
        yield return new WaitForSeconds(3f);
        UIManager.instance.MenuPanel.SetActive(true);
    }
   
    public void GameStateChange(GameState gameState)
    {
        

        switch (gameState)
        {
            case GameState.menu:
                GameStatus = GameState.menu.ToString();
                break;
            case GameState.game:
                GameStatus = GameState.game.ToString();
                break;
            case GameState.pause:
                GameStatus = GameState.pause.ToString();
                break;
            case GameState.gameEnd:
                GameStatus = GameState.gameEnd.ToString();
                break;
            default:
                break;
        }
    }
    
    public IEnumerator GameEndAction()
    {

        GameStateChange(GameManager.GameState.gameEnd);
        UIManager.instance.GameEndPanel.SetActive(true);
        UIManager.instance.GamePanel.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 0;
        
    }
    public void GameStart()
    {
        StartCoroutine(GameStartMotion());
    }
   

   IEnumerator GameStartMotion()
    {
        AssetAnimation.Instance.DoorAnimation();
        UIManager.instance.GameUIPanel.SetActive(true);
        UIManager.instance.MenuPanel.SetActive(false);
        GameStateChange(GameState.game);
        CinemachineCameraManager.instance.MenuCamera.SetActive(false);
        CinemachineCameraManager.instance.CameraTransition.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        CinemachineCameraManager.instance.CameraTransition.SetActive(false);
        CinemachineCameraManager.instance.GamePlayCamera.SetActive(true);

        //RenderSettings.fogDensity = 0.005f;
        //RenderSettings.fogDensity = 0.006f;
        //RenderSettings.fogDensity = 0.008f;
        //RenderSettings.fogDensity = 0.009f;
        //RenderSettings.fogDensity = 0.010f;
        //RenderSettings.fogDensity = 0.011f;
        //RenderSettings.fogDensity = 0.012f;
        //RenderSettings.fogDensity = 0.013f;
        //RenderSettings.fogDensity = 0.014f;
        //RenderSettings.fogDensity = 0.015f;
        //RenderSettings.fogDensity = 0.018f;
        //RenderSettings.fogDensity = 0.020f;
        //RenderSettings.fogDensity = 0.023f;



    }
    public enum GameState
    {
        menu,
        game,
        pause,
        gameEnd
    };
}
