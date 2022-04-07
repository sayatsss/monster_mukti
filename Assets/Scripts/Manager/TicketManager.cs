using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TicketManager : MonoBehaviour
{
    public static TicketManager instance; 
    [HideInInspector]public int ticketCount;
    public List<GameObject> Tickets = new List<GameObject>();
    public GameObject TicketBoard;



    private void Awake()
    {
        instance = this;
        TicketBoard.transform.DOMoveY(Screen.height+300f,0.5f);
    }
    private void Start()
    {
        TicketHandlerSetAplaLow();
    }


    private void TicketHandlerSetAplaLow()
    {
        for(int i=0;i<Tickets.Count;i++)
        {
            Tickets[i].SetActive(false);
        }
    }

    public  IEnumerator TicketActive()
    {
        
        TicketBoard.transform.DOMoveY(Screen.height, 1f);
        yield return new WaitForSeconds(0.8f);
        Tickets[ticketCount - 1].SetActive(true);
        yield return new WaitForSeconds(2f);
        TicketBoard.transform.DOMoveY(Screen.height + 300f, 2f);
    }
}
