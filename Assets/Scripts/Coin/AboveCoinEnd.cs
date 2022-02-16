using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveCoinEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            AboveCloiudCoinAction.Instance.RecycleCoinsAboveCloud(this.gameObject.transform.parent.gameObject);
        }
        
    }
}
