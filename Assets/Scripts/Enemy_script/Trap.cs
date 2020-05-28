using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Trap : MonoBehaviour
{
    public Tilemap tilemap;
    public PlayerHealth phealth;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        phealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            phealth.DamagePlayer(5);
        }
    }
}
