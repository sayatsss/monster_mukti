using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
   // private Transform _camera;
    private float turnSpeed=2f;

    private void Start()
    {
        //_camera = GetComponent<Camera>().transform;
        turnSpeed = Random.Range(60f, 90f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            //return;
            this.gameObject.SetActive(false);
            ScoreManager.instance.AddCoin();
        }
        
    }
  

    // Update is called once per frame
    void Update()
    {
       // transform.DOMoveY(Mathf.PingPong(0, 1),0.5f);
        transform.Rotate(0, 0, turnSpeed*Time.deltaTime);
    }
}
