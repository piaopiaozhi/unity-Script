using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // Start is called before the first frame update
    public float Deathtime = 1f;
    public GameObject player;
    public Transform rebirth;

    Player aplayer;
    private void Start()
    {
        aplayer = player.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            StartCoroutine(StartTime());
        }
    }

    IEnumerator StartTime()
    {
        aplayer.fallWater = true;   
        float time = Time.time;
        while(Time.time-time<Deathtime)
        {
            yield return null;
        }
        player.transform.position = rebirth.position;
        aplayer.fallWater = false;
    }

}
