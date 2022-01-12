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
    private float _yvelocity=0.0f;

    private float P_X_Value=0;
    private Touch touch;

    //private Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        characterAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        //velocity for the character.
       // Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, 1);
        Vector3 velocity = Vector3.forward * speed;

        if(controller.isGrounded)
        {

            //Need to check this once all rest done.
           /* if(Input.GetKeyDown(KeyCode.A))
            {
                velocity.x = -30;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                velocity.x = 30;
            }
            */
            characterAnimator.SetBool("IsJump", false);

           // velocity = 
           // velocity = transform.TransformDirection(velocity);
           // velocity *= speed;

            if (Input.GetKeyDown(KeyCode.Space)||SwipeManager.swipeUp)
            {
                characterAnimator.SetBool("IsJump", true);
                _yvelocity = jumpValue;
            }
          
        }
        else
        {
             //characterAnimator.SetBool("IsJump", false);
            _yvelocity -= gravity;
        }


        velocity.y = _yvelocity;
        //movement for the character.
        controller.Move(velocity * Time.deltaTime);


        
        
    }
}
