using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator Player;
    public Animator Bhamasura;
    public Animator garuda;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Player.SetBool("IsRun", true);
            Bhamasura.SetBool("IsRun", true);
            garuda.SetBool("IsRun", true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Player.SetBool("IsRun", false);
            Bhamasura.SetBool("IsRun", false);
            garuda.SetBool("IsRun", false);
            Player.SetBool("IsSpecial", true);
            Bhamasura.SetBool("IsSpecial", true);
            garuda.SetBool("IsSpecial", true);
        }
    }
}
