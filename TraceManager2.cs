using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TraceManager2 : MonoBehaviour
{
    public GameObject player;
    public float rangeRadius = 1.0f;
    public Transform Final;
    [SerializeField] List<SpriteMask> spriteMasks = new List<SpriteMask>();
    public bool changescene =false;
    private void Start()
    {
          spriteMasks.AddRange(transform.GetComponentsInChildren<SpriteMask>());
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.J))
        {
            foreach(SpriteMask mask in spriteMasks)
            {
                float distanceToPlayer = Vector3.Distance(mask.transform.position,player.transform.position-new Vector3(0,0.486f));
                if (mask.enabled && distanceToPlayer<=rangeRadius)
                {
                    mask.gameObject.SetActive(false);
                }
            }
        }

        if(Vector3.Distance(player.transform.position,Final.position)<=1f)
        {
            int i = 0;
            foreach(SpriteMask mask in spriteMasks)
            {
                if (mask.gameObject.activeSelf)
                    i++;
            }
            if (i < spriteMasks.Count * 0.05)
                changescene = true;
        }
    }
}
