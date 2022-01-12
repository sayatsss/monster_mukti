using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.GameStateChange(GameManager.GameState.gameEnd);
        UIManager.instance.GameEndPanel.SetActive(true);
        UIManager.instance.GamePanel.SetActive(false);
        Time.timeScale = 0;
    }
}
