using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaterLevel : MonoBehaviour
{
    

    private void Update()
    {
        if ( GameManager.instance.GameStatus == GameManager.GameState.game.ToString())
        {
            this.gameObject.transform.DOMoveY(10f, 1000f);
            
        }
    }


}
