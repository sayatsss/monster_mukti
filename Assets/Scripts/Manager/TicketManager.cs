using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketManager : MonoBehaviour
{
    public static TicketManager instance; 
    [HideInInspector]public int ticketCount;
    public List<Image> Tickets = new List<Image>();


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        TicketHandlerSetAplaLow();
    }


    private void TicketHandlerSetAplaLow()
    {
        for(int i=0;i<Tickets.Count;i++)
        {
            Tickets[i].color = new Color(Tickets[i].color.r, Tickets[i].color.g, Tickets[i].color.b, 0.2f);
        }
    }

    public  void TicketActive()
    {
        //TicketHandlerSetAplaLow();
        Tickets[ticketCount-1].color= new Color(Tickets[ticketCount-1].color.r, Tickets[ticketCount-1].color.g, Tickets[ticketCount-1].color.b, 1f);
    }
}
