using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    public GameObject target; //the enemy's target
    public float moveSpeed = 5; //move speed
    public float rotationSpeed = 5; //speed of turning

    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration = 0.1f;


    void Update()
    {
        if (GameManager.instance.GameStatus == GameManager.GameState.game.ToString())
        {
           
            if (moveSpeed >= maxSpeed)
            {
                moveSpeed = maxSpeed;
            }
            else
            {
                moveSpeed += acceleration * Time.deltaTime;
            }
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), rotationSpeed * Time.deltaTime);


            //move towards the player
            transform.position += transform.forward * Time.deltaTime * moveSpeed;

        }
        //rotate to look at the player



    }

}
