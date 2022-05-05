using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsertAnimationController : MonoBehaviour
{

    public GameObject  Ishita, Caanu ;

    private void Start()
    {
        StartCoroutine(playAnimation());
    }
    IEnumerator playAnimation()
    {
        yield return new WaitForSeconds(6f);
        //Player.GetComponent<Animator>().SetBool("IsDance", true);
        Ishita.GetComponent<Animator>().SetBool("IsDance", true);
        Caanu.GetComponent<Animator>().SetBool("IsDance", true);
        //Bhasmasura.GetComponent<Animator>().SetBool("IsDance", true);
    }
}
