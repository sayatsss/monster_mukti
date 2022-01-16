using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator characterAnimator;
    private Rigidbody _rigidbody;

    [SerializeField]private float speed;
    [SerializeField] private float jumpValue;
    [SerializeField] private float gravity;
    [SerializeField] private float sensitivity= 3f;
   // [SerializeField]float dead = 0.001f;
    private float _xvelocity = 0.0f;
    private float _yvelocity=0.0f;
    private Vector3 velocity;
    private CapsuleCollider col;
    public LayerMask groundLayers;


    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        characterAnimator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(GameManager.instance.GameStatus==GameManager.GameState.game.ToString())
        {

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0, 1);

            _rigidbody.velocity = movement * speed * Time.deltaTime;
           
            if (IsGrounded() )
            {
                characterAnimator.SetBool("IsJump", false);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    characterAnimator.SetBool("IsJump", true);
                    _rigidbody.AddForce(Vector3.up * jumpValue, ForceMode.Impulse);
                }
               
            }
            
               
                

           
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }
}
