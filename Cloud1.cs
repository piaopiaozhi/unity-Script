using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud1 : MonoBehaviour
{
    // Start is called before the first frame update
   public  GameObject Handle;
    public Vector3 position1;
    public Vector3 position2;
    public float speed = 1f;
    bool handleisdone;

    public bool movingToEnd = true;
    Handle hd;
    void Start()
    {
        hd=Handle.GetComponent<Handle>();
    }

    // Update is called once per frame
    void Update()
    {
        handleisdone = hd.HandleIsDone;
        if(handleisdone)
        Move();
    }
    public void Move()
    {
        Vector3 targetposition = movingToEnd ? position2 : position1;
        transform.position = Vector3.MoveTowards(transform.position, targetposition, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetposition) < 0.1f)
        {
            movingToEnd = !movingToEnd;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (handleisdone&&collision.transform.tag == "Player")
        {
            if (movingToEnd)
                collision.transform.position += new Vector3(0, speed*Time.deltaTime, 0);
            else
            {
                collision.transform.position += new Vector3(0, speed * Time.deltaTime * -1, 0);
            }
        }
    }
}
