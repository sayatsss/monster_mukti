using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //[HideInInspector]public GameState gameState = new GameState();
    [HideInInspector] public string GameStatus = "";

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //Need to change once the menu is done.
        GameStateChange(GameState.game);
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

    private void GameEndAction()
    {


        Time.timeScale = 0;
    }
    public enum GameState
    {
        menu,
        game,
        pause,
        gameEnd
    };
}
