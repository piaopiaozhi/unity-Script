using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject swtich;
    SpriteRenderer sr;
    Switch sw;
    public float speed = 1;
   public bool finish =false;
    int i = 0;

    AudioSource audioSource;
   public  AudioClip audioClip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
        sw = swtich.GetComponent<Switch>();
        sr=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sw.meteorstart && !finish)
        {
            sr.enabled = true;
            transform.position = Vector3.Lerp(transform.position, Vector3.zero, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, Vector3.zero) < 0.01f)
                finish = true;

            if (i == 0)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
                i++;
            }
        }
        
    }
}
