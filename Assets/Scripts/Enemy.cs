using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int damage;
    public int health;
    public float flashtime;

    public GameObject bloodEffect;
    private SpriteRenderer spriteRenderer;
    private Color oldcolor;
    // Start is called before the first frame update
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        oldcolor = spriteRenderer.color;
    }

    // Update is called once per frame
   public void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
       

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        getAttack(flashtime);
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
    }
    void getAttack(float time)
    {
        spriteRenderer.color = Color.red;
        Invoke("backColor", time);
    }
    void backColor()
    {
        spriteRenderer.color = oldcolor;
    }
}
