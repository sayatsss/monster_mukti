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
        //direction for the character.
        Vector3 direction = new Vector3(Mathf.Clamp(Input.GetAxis("Horizontal"),-1.3f,1.3f), 0, 1);
        //velocity for the character.
        Vector3 velocity = direction * speed;

        if(controller.isGrounded)
        {
            characterAnimator.SetBool("IsJump", false);

           // velocity = 
           // velocity = transform.TransformDirection(velocity);
           // velocity *= speed;

            if (Input.GetKeyDown(KeyCode.Space))
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
