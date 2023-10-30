using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 position1;
    public Vector3 position2;
    public float speed = 1f;

    public bool movingToEnd= true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        if(collision.transform.tag == "Player")
        {
            if(movingToEnd)
            collision.transform.position += new Vector3(speed * Time.deltaTime * -1, 0, 0);
            else
            {
                collision.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }
        
    }
    

}
