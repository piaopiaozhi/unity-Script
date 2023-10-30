using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource paudioSource;
    public AudioSource jumpSource;
    public AudioSource fallDownSource;
    public AudioClip slice;
    public AudioClip death;
    public AudioClip dropdownground;
    public AudioClip fallwater;
    public AudioClip walk;
    public AudioClip jump;

    Player aplayer;
    // Start is called before the first frame update
    void Start()
    {
        paudioSource=GetComponent<AudioSource>();
        aplayer = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J)&&!paudioSource.isPlaying)
        {
            paudioSource.clip = slice;

            paudioSource.Play();
        }
        else if (aplayer.Death && !paudioSource.isPlaying)
        {
            paudioSource.clip = death;
            paudioSource.Play();
        }
        else if (aplayer.fallWater && !paudioSource.isPlaying)
        {
            paudioSource.clip = fallwater;
            paudioSource.Play();
        }
        else if (aplayer.dropDownGround && !fallDownSource.isPlaying)
        {
            fallDownSource.clip = dropdownground;
            fallDownSource.Play();
        }
        else if (aplayer.walk && !paudioSource.isPlaying)
        {
           
            
            paudioSource.clip = walk;
            paudioSource.Play();
           
        }
        else if (aplayer.isJumping && !jumpSource.isPlaying)
        {

            jumpSource.clip = jump;
            jumpSource.Play();
        }
       


    }
}
