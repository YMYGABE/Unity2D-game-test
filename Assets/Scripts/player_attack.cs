using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour
{
    public int damage;
    public float starTime;
    public float finishTime;

    private Animator animator;
    private PolygonCollider2D Collider2D;
    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        Collider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            animator.SetTrigger("Attack");
            StartCoroutine(startAttack());
        }
    }
    IEnumerator startAttack()
    {
        yield return new WaitForSeconds(starTime);
        Collider2D.enabled = true;
        StartCoroutine(finishAttack());
    }

    IEnumerator finishAttack()
    {
        yield return new WaitForSeconds(finishTime);
        Collider2D.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
