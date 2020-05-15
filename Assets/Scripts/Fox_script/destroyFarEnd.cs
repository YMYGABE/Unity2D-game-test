using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyFarEnd : MonoBehaviour
{
    public float lifetime;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
        
    }
}
