using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketManager : MonoBehaviour
{
    public List<Image> Tickets = new List<Image>();

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
}
