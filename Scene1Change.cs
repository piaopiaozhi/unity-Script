using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1Change : MonoBehaviour
{
    // Start is called before the first frame update
    TraceManager2 traceManager2;
    public GameObject masks;
    float time1=0;
    void Start()
    {
        traceManager2 = masks.GetComponent<TraceManager2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(traceManager2.changescene)
        {
            transform.GetComponent<Animator>().enabled = true;
            time1 += Time.deltaTime;
            if(time1>2)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
