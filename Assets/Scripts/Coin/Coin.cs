using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
   // private Transform _camera;
    private float turnSpeed=2f;
    public float y;
    private float speed=1;

    private void Start()
    {
        //_camera = GetComponent<Camera>().transform;
        turnSpeed = Random.Range(45f, 60f);
        speed = Random.Range(0.2f, 0.5f);
        transform.DOMoveY(Mathf.PingPong(0f,0.5f), 0.5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            //return;
            this.gameObject.SetActive(false);
            ScoreManager.instance.AddCoin(this.gameObject);
        }
        
    }
  

    // Update is called once per frame
    void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 0.6f) * 1;
       //transform.position = new Vector3(0, y, 0);

        transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
        // transform.DOMoveY(Mathf.PingPong(0, 1),0.5f);
       // transform.Rotate(0, 0, -turnSpeed*Time.deltaTime);
    }
}
