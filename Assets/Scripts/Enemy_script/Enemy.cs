using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int damage;  //敌人的攻击力
    public int health;  //敌人的生命值
    public float flashtime;   //受伤后的闪烁时间

    public GameObject bloodEffect;   //受伤的粒子特效
    private SpriteRenderer spriteRenderer;   //精灵渲染器
    private Color oldcolor;         //受伤以前的颜色
    private PlayerHealth playerhealth;          //Player的方法引用
    // Start is called before the first frame update
    public void Start()
    {
        //获取tag名是player的对象的PlayerHealth组件
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();                                                                                          
        spriteRenderer = GetComponent<SpriteRenderer>();
        oldcolor = spriteRenderer.color;//获取受伤之前的颜色
    }

    // Update is called once per frame
   public void Update()
    {
        //敌人生命值为 0 销毁对象
        if (health <= 0)
        {
            Destroy(gameObject);
        }
       

    }
    public void TakeDamage(int damage)
    {
        //受到攻击后
        health -= damage;
        getAttack(flashtime);
        //实例化溅血特效到敌人的位置
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
    }
    void getAttack(float time)
    {
        //被攻击后改变颜色
        spriteRenderer.color = Color.red;
        //计时器，用来改回颜色
        Invoke("backColor", time);
    }
    void backColor()
    {
        spriteRenderer.color = oldcolor;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {//检测碰撞
       
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (playerhealth != null)
            {
                playerhealth.DamagePlayer(damage);
            }
        }
    }
}
