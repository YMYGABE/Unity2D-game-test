using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public Animator animator;
    public float time;

    public CapsuleCollider2D capsule;
    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider2D>();
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
            Destroy(gameObject,time);
        }
    }
}
