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
        if(Input.GetKeyDown(KeyCode.B))
        {
           // Debug.Log("Garuda Is been activated");
           // StartCoroutine(CharacterStateManager.Instance.Character_Garuda_Transition());
            
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
           // Debug.Log("Garuda Is been activated");
            StartCoroutine(CharacterStateManager.Instance.Garuda_Character_Transition());

        }

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
        AudioManager.Instance.PlayerKilled.Play();
        PlayerController.instance.characterAnimator.SetBool("IsJump", false);
        PlayerController.instance.characterAnimator.SetBool("IsDead", true);
        GameStateChange(GameManager.GameState.gameEnd);
        yield return new WaitForSeconds(2f);
        UIManager.instance.GamePanel.SetActive(false);
        UIManager.instance.GameEndPanel.SetActive(true);
        Time.timeScale = 0;
        
    }
    public void GameStart()
    {
        StartCoroutine(GameStartMotion());
    }
   

   IEnumerator GameStartMotion()
    {
        AudioManager.Instance.Door.Play();
        AssetAnimation.Instance.DoorAnimation();
        UIManager.instance.GameUIPanel.SetActive(true);
        UIManager.instance.MenuPanel.SetActive(false);
        GameStateChange(GameState.game);
        CinemachineCameraManager.instance.MenuCamera.SetActive(false);
        CinemachineCameraManager.instance.CameraTransition.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        CinemachineCameraManager.instance.CameraTransition.SetActive(false);
        CinemachineCameraManager.instance.GamePlayCamera.SetActive(true);

    }
    public enum GameState
    {
        menu,
        game,
        pause,
        gameEnd
    };
}
