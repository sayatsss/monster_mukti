using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover : MonoBehaviour
{

    [SerializeField] private float _rotationSpeed = 30.0f;
    [SerializeField] private float _bopHeight = 0.03f;
    [SerializeField] private float _bopSpeed = 1.0f;

    void Update()
    {
        //transform.Rotate(Vector3.up, (_rotationSpeed * Time.deltaTime));
        //if (transform.rotation.eulerAngles.y > 180) _rotationSpeed *= -1;

        transform.Translate(new Vector3(0, Mathf.Sin(Time.time) * _bopHeight, 0) * _bopSpeed * Time.deltaTime);
    }
}
