using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    public LayerMask groundLayer;
    public float jumpforce = 11;
    public float jumpholdforce = 0.13f;
    private Rigidbody2D rb;
    public PhysicsMaterial2D p1;    // 有摩擦力的
    public PhysicsMaterial2D p2;    // 无摩擦力的


    float horizontal;
    float jumpcd=0.3f;
    float jumptime = 0;
    float PlatRestoreTime = 0;
    public float speed = 5;
    float raycastlong = 0.8f;
    BoxCollider2D bc2d = null;
    Vector3 lscale;
    Animator anim;

    //下方是给声音判定的参数
    public bool Death;
    public bool fallWater;
    public bool dropDownGround;
    public bool walk;
    public bool isJumping;

    public Sprite walking;
    public Sprite slicing;

    void Start()
    {
        player = gameObject;
        
        rb = this.GetComponent<Rigidbody2D>();
        lscale = player.transform.localScale;
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        jumpcd -= Time.deltaTime; 
        jumptime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && Isground())
        {
            if(Input.GetKey(KeyCode.S) && Iskcground() && !bc2d)
            {
                bc2d = Physics2D.Raycast(transform.position, Vector3.down, raycastlong, groundLayer).transform.GetComponent<BoxCollider2D>();  //获取可穿地面的碰撞体组件
                Debug.Log(bc2d.name);
                bc2d.enabled = false;
                PlatRestoreTime = Time.time;
            }
            else if(jumpcd < 0)
            {
                rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                jumpcd = 0.3f;
                jumptime = 0.2f;
            }
            isJumping = true;
            anim.SetBool("isjumping", true);
        }
       
        if(PlatRestoreTime + 0.3f < Time.time && bc2d)  //0.3秒后恢复碰撞体
        {
            bc2d.enabled = true;
            bc2d = null;
        }
        
        if(Input.GetKey(KeyCode.Space)  && jumptime>0)  //0.2s内按住空格，获得持续力
        {
            rb.AddForce(new Vector2(0, jumpholdforce),ForceMode2D.Impulse);
        }

        
        if(!Isground())
        {
            rb.sharedMaterial = p2;
                if (rb.velocity.y != 0)
                    anim.SetBool("isjumping", true);
        }
        else if (Isground())
        {
            rb.sharedMaterial = p1;
            anim.SetBool("isjumping", false);
        }

        if (Input.GetKey(KeyCode.J))
        {
            transform.GetComponent<SpriteRenderer>().sprite = slicing;
            anim.SetBool("slice", true);
        }
        if(Input.GetKeyUp(KeyCode.J))
        {
            transform.GetComponent<SpriteRenderer>().sprite = walking;
            anim.SetBool("slice", false);
        }

        if (rb.velocity.x != 0 && Isground())
        {
            walk = true;
            anim.SetFloat("velocity", 1);

        }
        else
        {
            walk = false;
            anim.SetFloat("velocity", 0);
        }




    }
    private void FixedUpdate()
    {
        Move();
    }
    bool Isground()
    { 
        return Physics2D.Raycast(transform.position, Vector3.down, raycastlong, groundLayer);
    }
    bool Iskcground()  //可穿（kc）地面
    {
            return Physics2D.Raycast(transform.position, Vector3.down, raycastlong, groundLayer).transform.gameObject.CompareTag("kc");
       
    }
    private void Move()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        IsFacingRight();
    }
    private bool IsFacingRight()  //转向
    {
        if (rb.velocity.x < 0)
        {
            player.transform.localScale = new Vector3(-1 * lscale.x,lscale.y,lscale.z);
            return false;
        }
        else if(rb.velocity.x > 0)
        {
            player.transform.localScale = lscale;
            return true;
        }
        return true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (isJumping && collision.gameObject.layer == 9 && rb.velocity.y<=0.1)
        {
            Debug.Log(1);
            isJumping = false;
            
            StartCoroutine(dropdown());
        }
    }

    IEnumerator dropdown()
    {
        dropDownGround = true;
        float time = Time.time;
        while(Time.time - time<0.3f)
        {
            yield return null;
        }
        dropDownGround = false; 

    }













}
