using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sequenceManager : MonoBehaviour
{
    public List<GameObject> papers = new List<GameObject>();
    public Vector3 point;
    public GameObject kuang;
    public GameObject mesh;
    private bool isDragging = false;
    private Vector3 offset;
    private Transform currentDraggedObject;
    [SerializeField]private Vector3 startposition;
    public GameObject yulan;
    public GameObject finalpic;
    public GameObject acamera;
    public GameObject circle;
    public Collider2D area;

    int sortinglayer = 0;

    private void Awake()
    {
       circle.GetComponent<Animator>().enabled = true;
    }
    
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, Vector2.up); // 框也是一个碰撞体，避免射线只会一直检测框而无法检测到纸张。
            if (hits[0].collider != null && hits[0].transform.tag!="kuang")  
            {
                Debug.Log(hits[0].transform.name);
                currentDraggedObject = hits[0].transform;
                offset = currentDraggedObject.position - mousePosition;
                isDragging = true;
                startposition = currentDraggedObject.position;
            }
            else if (hits[1].collider != null && hits[1].transform.tag != "kuang")
            {
                Debug.Log(hits[1].transform.name);
                currentDraggedObject = hits[1].transform;
                offset = currentDraggedObject.position - mousePosition;
                isDragging = true;
                startposition = currentDraggedObject.position;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            // 鼠标释放，停止拖拽
            
            Vector2 mousePosition2d = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (isDragging && area.OverlapPoint(mousePosition2d))
            {
                currentDraggedObject.position = point;
                currentDraggedObject.GetComponent<SpriteRenderer>().sortingOrder = ++sortinglayer;
            }
            isDragging = false;
            currentDraggedObject = null;
            

        }
        if (isDragging)
        {
            // 根据鼠标位置更新物体位置
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentDraggedObject.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, currentDraggedObject.position.z);
        }

        if (Vector3.Distance(papers[0].transform.position,point)<0.1f && Vector3.Distance(papers[1].transform.position, point) < 0.1f&&Vector3.Distance(papers[2].transform.position, point) < 0.1f)
        {
            if (papers[0].GetComponent<SpriteRenderer>().sortingOrder - papers[1].GetComponent<SpriteRenderer>().sortingOrder == -1 && papers[1].GetComponent<SpriteRenderer>().sortingOrder - papers[2].GetComponent<SpriteRenderer>().sortingOrder == -1 && papers[0].GetComponent<SpriteRenderer>().sortingOrder - papers[1].GetComponent<SpriteRenderer>().sortingOrder == -1 )
            {
                kuang.SetActive(false);
                foreach(GameObject paper in papers)
                {
                    paper.GetComponent<BoxCollider2D>().enabled = false;
                    paper.GetComponent<Animator>().enabled = true;
                }
                StartCoroutine(ChangeScene());
            }
        }
    }

    IEnumerator des()
    {
        float time = Time.time;
        while(Time.time -time<2f)
        {
            yield return null;
        }
        Destroy(circle);
    }

    IEnumerator ChangeScene()
    {
        float time = Time.time;
        Color startcolor = acamera.GetComponent<Camera>().backgroundColor;
        while (Time.time -time <2f)
        {
            yield return null;
        }
       time = 0;    
        while(time<2f)
        {
            foreach (GameObject paper in papers)
            {
                paper.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1-time / 2);
            }
            yulan.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, time / 2);
            time += Time.deltaTime;
            yield return null;
        }
        
        time = 0;
        while(time<2f)
        {
            finalpic.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, time / 2);
            yulan.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1 - time / 2);
            acamera.GetComponent<Camera>().backgroundColor = Color.Lerp(startcolor, Color.white, time/2);
            time += Time.deltaTime/5;
            yield return null;
        }
        
       
    }
}
