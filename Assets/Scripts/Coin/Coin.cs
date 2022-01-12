using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField]private float turnSpeed=90f;

    private void Start()
    {
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
       // transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
