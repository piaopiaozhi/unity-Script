using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trone : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Transform rebirth;
    Player aplayer;
    float deathtime = 0.3f;
    private void Start()
    {
        aplayer = player.GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            player.transform.position = rebirth.position;
            aplayer.Death = true;
            StartCoroutine(ResetDeathState());
        }
    }
    IEnumerator ResetDeathState()
    {
        yield return new WaitForSeconds(deathtime);
        aplayer.Death = false;
    }
}
