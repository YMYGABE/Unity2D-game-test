using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public Animator animator;
    public float time;
    public int numblink;
    public float blinktime;


    public Renderer renderer;
    public CapsuleCollider2D capsule;
    public BoxCollider2D box; 
    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider2D>();
        box = GetComponent<BoxCollider2D>();
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamagePlayer(int damage)
    {
        health -= damage;
        if(health <= 0.0f)
        {
            animator.SetBool("death", true);
            capsule.enabled = false;
            box.enabled = false;
            Destroy(gameObject,time);
        }
        Playerblink(numblink, blinktime);
    }

     void Playerblink(int blinks,float time)
    {
        StartCoroutine(Blink(blinks, time));
    }
    IEnumerator Blink(int blinks,float time)
    {
        for (int i = 0; i < blinks; i++) //控制闪烁次数
        {
            renderer.enabled = !renderer.enabled;
            yield return new WaitForSeconds(time);
        }
        renderer.enabled = true;
    }
    
}
