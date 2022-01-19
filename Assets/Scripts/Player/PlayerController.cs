using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Animator characterAnimator;
    private CharacterController controller;

    [SerializeField]private float speed;
    [SerializeField] private float jumpValue;
    [SerializeField] private float gravity;
    [SerializeField] private float acceleration = 0.1f;
    [SerializeField]private float maxSpeed;

    private float _xvelocity = 0.0f;
    private float _yvelocity=0.0f;
    private Vector3 velocity;
    private float target;



    void Start()
    {
        controller = GetComponent<CharacterController>();
        characterAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.4f, 1.4f), transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        if(GameManager.instance.GameStatus==GameManager.GameState.game.ToString())
        {
            if (controller.isGrounded)
            {
                characterAnimator.SetBool("IsJump", false);
                if (Input.GetKeyDown(KeyCode.Space) || SwipeManager.swipeUp)
                {
                  
                     characterAnimator.SetBool("IsJump", true);
                    _yvelocity = jumpValue;
                }
                if (Input.GetKeyDown(KeyCode.S) || SwipeManager.swipeDown)
                {
                    StartCoroutine(SlideAnimation());
                }

            }
            else
            {
                _yvelocity -= gravity;
            }

            // velocity = new Vector3(Input.acceleration.x, 0, 1) * speed;
            if(speed>= maxSpeed)
            {
                speed = maxSpeed;
            }
            else
            {
                speed += acceleration * Time.deltaTime;
            }


         #if (UNITY_EDITOR && !UNITY_ANDROID)
                velocity = new Vector3(Input.GetAxis("Horizontal"), 0, 1) * speed;//curSpeed += acceleration * Time.deltaTime;
         #endif

        #if UNITY_ANDROID
            // your code
            velocity = new Vector3(Input.acceleration.x, 0, 1) * speed;
        #endif
           




            velocity.y = _yvelocity;
            controller.Move(velocity * Time.deltaTime);
         


        }
    }
    IEnumerator SlideAnimation()
    {
        characterAnimator.SetBool("IsSlide", true);
        controller.center = new Vector3(controller.center.x, 0.5f, controller.center.z);
        controller.height = 0.5f;
        yield return new WaitForSeconds(1.06f);
        characterAnimator.SetBool("IsSlide", false);
        controller.center = new Vector3(controller.center.x, 1f, controller.center.z);
        controller.height = 2f;
    }
    
}
