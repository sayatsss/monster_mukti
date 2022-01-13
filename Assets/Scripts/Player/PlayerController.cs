using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator characterAnimator;
    private CharacterController controller;
    [SerializeField]private float speed;
    [SerializeField] private float jumpValue;
    [SerializeField] private float gravity;
    [SerializeField] private float sensitivity= 3f;
    [SerializeField]float dead = 0.001f;
    private float _xvelocity = 0.0f;
    private float _yvelocity=0.0f;
    private Vector3 velocity;
    private float target;
    private float moveValue;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        characterAnimator = GetComponent<Animator>();
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
                     moveValue = 0;
                     characterAnimator.SetBool("IsJump", true);
                    _yvelocity = jumpValue;
                }
                if (Input.touchCount > 0)
                {
                    if (SwipeManager.swipeRight)
                    {
                        target = 1;
                    }
                    if (SwipeManager.swipeLeft)
                    {
                        target = -1;
                    }
                    moveValue = Mathf.MoveTowards(moveValue, target, sensitivity * Time.deltaTime);
                }
                else
                {
                    moveValue = (moveValue < dead) ? 0 : Mathf.MoveTowards(moveValue, 0, sensitivity * Time.deltaTime);
                }
            }
            else
            {
                _yvelocity -= gravity;
            }

           // velocity = new Vector3(moveValue, 0, 1) * speed;
            velocity = new Vector3(Input.GetAxis("Horizontal"), 0, 1) * speed;

            velocity.y = _yvelocity;
            controller.Move(velocity * Time.deltaTime);

        }
    }
}
