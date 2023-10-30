using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    Animator animator;
    public bool HandleIsDone = false;
    int i = 0;
    AudioSource audioSource;
    public AudioClip audioClip;
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            animator.SetBool("switch", true);
            HandleIsDone = true;
            if(i==0)
            {
                audioSource.clip = audioClip;
                audioSource.Play();i++;
            }

        }
    }
}
