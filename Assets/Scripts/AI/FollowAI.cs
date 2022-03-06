using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class FollowAI : MonoBehaviour
{


    public static FollowAI Instance;
    public GameObject target; //the enemy's target
    public float moveSpeed = 5; //move speed
    public float rotationSpeed = 5; //speed of turning

    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration = 0.1f;

    private bool isAttacking = false;

    
    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InvokeRepeating("AsuraAction", 15f, 10f);
    }
    void Update()
    {
        if (GameManager.instance.GameStatus == GameManager.GameState.game.ToString()&&!isAttacking)
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

        if(Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(AsuraAttack());
        }


    }
    public IEnumerator FirstAsuraAttack()
    {
        yield return new WaitForSeconds(0.6f);
        StartCoroutine(AsuraAttack());
    }
    private void AsuraAction()
    {
        StartCoroutine(AsuraAttack());
    }
    public IEnumerator AsuraAttack()
    {
        //SimpleCameraShakeInCinemachine.Instance.VirtualCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 90f;
        this.gameObject.GetComponent<Animator>().SetBool("IsAttack", true);
        yield return new WaitForSeconds(1.8f);
        isAttacking = true;
        StartCoroutine(SimpleCameraShakeInCinemachine.Instance.cameraAction());
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;
        this.gameObject.GetComponent<Animator>().SetBool("IsAttack", false);
        
        //SimpleCameraShakeInCinemachine.Instance.VirtualCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 80f;
    }
    

}
