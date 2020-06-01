using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Trap : MonoBehaviour
{
    public Tilemap tilemap;
    public PlayerHealth phealth;
    public TilemapCollider2D capsule;
    public float times;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        phealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        capsule = GetComponent<TilemapCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
                phealth.DamagePlayer(damage);          
                capsule.enabled = false;
                StartCoroutine(finish());
            
        }
    }
    IEnumerator finish()
    {
        yield return new WaitForSeconds(times);
        capsule.enabled = true;
    }
}
