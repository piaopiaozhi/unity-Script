using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    Transform targetphoto;
    public GameObject Player;
    public Transform all;
    public List<GameObject> Clouds =new List<GameObject>();
    List<Transform> alls = new List<Transform>();
    SpriteRenderer sprite;
    void Start()
    {
        targetphoto = transform.GetChild(0);
        alls.AddRange(all.GetComponentsInChildren<Transform>());
    }

    // Update is called once per frame
    void Update()
    {
        if(targetphoto.gameObject.activeSelf && Input.GetMouseButtonDown(0))
        {
            targetphoto.gameObject.SetActive(false);
            Player.GetComponent<Player>().enabled = true ;
            foreach (Transform t in alls)
            {
                if (t.GetComponent<SpriteRenderer>())
                {
                    sprite = t.GetComponent<SpriteRenderer>();
                    Debug.Log(sprite.color);
                    sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
                }
            }
            foreach (GameObject Cloud in Clouds)
            {
                if (Cloud.GetComponent<Cloud>())
                {
                    Cloud.GetComponent<Cloud>().enabled = true;
                }
                else if (Cloud.GetComponent<Cloud1>())
                {
                    Cloud.GetComponent<Cloud1>().enabled = true;
                }
            }




        }
    }
    public void clicktip()
    {
        targetphoto.gameObject.SetActive(true);
        Player.GetComponent<Player>().enabled = false;

        foreach (Transform t in alls)
        {
            if (t.GetComponent<SpriteRenderer>())
            {
                sprite = t.GetComponent<SpriteRenderer>();
                Debug.Log(sprite.color);
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
            }
        }
        foreach (GameObject Cloud in Clouds)
        {
            if (Cloud.GetComponent<Cloud>())
            {
                Cloud.GetComponent<Cloud>().enabled = false;
            }
            else if (Cloud.GetComponent<Cloud1>())
            {
                Cloud.GetComponent<Cloud1>().enabled = false;
            }
        }
    }
}
