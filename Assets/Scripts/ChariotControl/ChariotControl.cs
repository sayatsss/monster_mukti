using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChariotControl : MonoBehaviour
{

    [HideInInspector]public  CharacterController controller;
    public List<GameObject> Horses = new List<GameObject>();
    private Vector3 velocity;
    public float speed;

    private bool _isGrounded;
    public bool ChariotActivated=false;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void HorseRunAnimation()
    {
        for(int i=0;i<Horses.Count;i++)
        {
            Horses[i].GetComponent<Animator>().SetBool("IsJump", true);
        }
    }
    private void Update()
    {
      
    }
    public void FixedUpdate()
    {
        if (GameManager.instance.GameStatus == GameManager.GameState.game.ToString())
        {
            if(ChariotActivated)
            {

                velocity = new Vector3(0, 0, 1) * speed;
                controller.Move(velocity * Time.deltaTime);
            }
           
           
        }
    }
}
