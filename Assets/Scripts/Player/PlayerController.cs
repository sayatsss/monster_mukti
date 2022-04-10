using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;
    [HideInInspector]public Animator characterAnimator;
    private CharacterController controller;

    public float speed;
    public float turnSpeed;
    [SerializeField] private float jumpValue;
    [SerializeField] private float gravity;
    [SerializeField] private float acceleration = 0.1f;
    //[SerializeField] private float deccelaration = 0.1f;
    [SerializeField]private float maxSpeed;


    private bool _isGrounded;
    private float _xvelocity = 0.0f;
    private float _yvelocity=0.0f;
    private Vector3 velocity;
    private float target;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        characterAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.8f, 1.8f), transform.position.y, transform.position.z);
        _isGrounded = controller.isGrounded;

    }
    private void FixedUpdate()
    {
        if(GameManager.instance.GameStatus==GameManager.GameState.game.ToString()  )
        {
            if (_isGrounded)
            {
                characterAnimator.SetBool("IsJump", false);
                if (Input.GetKeyDown(KeyCode.Space) || SwipeManager.swipeUp)
                {
                   
                    AudioManager.Instance.Playerjump.Play();
                  
                    _yvelocity = jumpValue;
                     characterAnimator.SetBool("IsJump", true);
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
            velocity = new Vector3(0, 0, 1) * speed;//curSpeed += acceleration * Time.deltaTime;
            if (GameStart.instance.Game_Start)
            {


                
                velocity.x = Input.acceleration.x * turnSpeed;
               // velocity.x = Input.GetAxis("Horizontal") * turnSpeed;

            }


            velocity.y = _yvelocity;
            controller.Move(velocity * Time.deltaTime);
         


        }
    }
    IEnumerator SlideAnimation()
    {

        AudioManager.Instance.Slide.Play();
        characterAnimator.SetBool("IsSlide", true);
        controller.center = new Vector3(controller.center.x, 0.5f, controller.center.z);
        controller.height = 0.5f;
        yield return new WaitForSeconds(1.06f);
        characterAnimator.SetBool("IsSlide", false);
        controller.center = new Vector3(controller.center.x, 1f, controller.center.z);
        controller.height = 2f;
    }
    
}
