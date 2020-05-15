using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float speed;
    public float jumpspeed;
    public float doublejump;

    private bool isGround;
    private bool candoubleJump;
    private Rigidbody2D rdb2;
    private Animator anim;
    private BoxCollider2D myfeet;
    // Start is called before the first frame update
    void Start()
    {
        rdb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        myfeet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Trun();
        Jump();
        checkGround();
        changeAnimation();
        
    }
    void checkGround()
    {
        isGround = myfeet.IsTouchingLayers(LayerMask.GetMask("Ground"));//获取是否接触图层Ground 
       // Debug.Log(isGround);
    }
    void Move()
    {
        float getmove = Input.GetAxis("Horizontal");  //获取水平轴的变量
        Vector2 vector = new Vector2(getmove * speed, rdb2.velocity.y);//设置二维向量x,y上的值
        rdb2.velocity = vector;  //设置刚体的速度
        bool RUN = Mathf.Abs(rdb2.velocity.x) > 0;
        anim.SetBool("run", RUN);  //动作切换，这里来改变引擎里设置的bool变量。
    }

    void Trun()
    {
        bool player = Mathf.Abs(rdb2.velocity.x) > 0;
        if (player)
        {
            if(rdb2.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0,0,0);  //改变这个物体的角度，Quaternion都用来弄角度相关的东西
            }
            if(rdb2.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);  //翻转180 （x,y,z）
                
            }
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump")) //只要摁空格就触发
        {
            if (isGround) {
                Vector2 vector = new Vector2(0.0f, jumpspeed);  //这里单独设置跳跃的速度，其实就是能跳多高
                rdb2.velocity = Vector2.up * vector;   //改变刚体速度    
                anim.SetBool("jump", true);
                candoubleJump = true;  //跳起的时候同时赋予可以二段跳 true
            }
            else
            {
                if (candoubleJump)  //通过这个来判断能不能二段跳
                {
                    Vector2 vector2 = new Vector2(0.0f, doublejump);
                    rdb2.velocity = Vector2.up*vector2;
                    candoubleJump = false;  //已经二段跳了，所以不能再跳了
                    anim.SetBool("doubleJump", true);
                }
            }
        }
        
    }
   
    void changeAnimation()
    {
        anim.SetBool("Idle", false);
        if (rdb2.velocity.x == 0.0f)
        {
            anim.SetBool("Idle", true);
        }
        
        if (anim.GetBool("jump"))
        {
            if(rdb2.velocity.y < 0.0f)
            {
                anim.SetBool("jump", false);
                anim.SetBool("Fall", true);
            }
        }
        if (anim.GetBool("Fall"))
        {
            
            if (isGround)
            {
                anim.SetBool("Fall", false);
                anim.SetBool("Idle", true);
            }
        }
        if (anim.GetBool("doubleJump"))
        {
            if(rdb2.velocity.y < 0.0f)
            {
                anim.SetBool("doubleJump", false);

            }
        }
    }
   
}
