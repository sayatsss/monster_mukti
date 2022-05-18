using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalHandle : MonoBehaviour
{

    public GameObject Firework;

    private void Start()
    {
        Firework.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            StartCoroutine(SceneChangeToCosert());
        }
    }


    private IEnumerator SceneChangeToCosert()
    {
        Firework.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadSceneAsync(2);
    }
}
