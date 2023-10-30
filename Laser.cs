using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject player;
    public Transform rebirth1;
    public Transform rebirth2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            if(player.transform.position.x-transform.position.x<=0)
            player.transform.position = rebirth1.position;
            else
                player.transform.position = rebirth2.position;
        }
    }
}
