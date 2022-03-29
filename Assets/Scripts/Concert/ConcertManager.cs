using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ConcertManager : MonoBehaviour
{
   [SerializeField] private Vector3 FinalPosition;
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        character.transform.DOMove(FinalPosition, 15f);
    }

   
}
