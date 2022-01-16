using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Animator characterAnimator;
    private CharacterController controller;
    [SerializeField] private float speed;
    [SerializeField] private float jumpValue;
    [SerializeField] private float gravity;
    [SerializeField] private float sensitivity = 3f;
    [SerializeField] float dead = 0.001f;
    private float _xvelocity = 0.0f;
    private float _yvelocity = 0.0f;
    private Vector3 velocity;
    private float target;
    private float moveValue;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
