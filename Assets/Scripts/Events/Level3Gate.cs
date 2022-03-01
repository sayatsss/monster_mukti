using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level3Gate : MonoBehaviour
{
    public GameObject gate;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.name.Contains("gate"))
            {
                gate = child.gameObject;
            }

        }
    }

    public void GateUp()
    {
        gate.transform.DOLocalMoveY(25f,3f,false);
    }
    public IEnumerator GateDown()
    {
        yield return new WaitForSeconds(15f);
        gate.transform.DOLocalMoveY(10f, 3f, false);
    }
}
