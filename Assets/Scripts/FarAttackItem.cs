using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarAttackItem : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float EndlifeTime;

    public GameObject destroyattack;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyAttack", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.eulerAngles.y == 0)
        {
            transform.Translate(transform.right * Time.deltaTime * speed);
        }
       else if(transform.eulerAngles.y == 180)
        {
            transform.Translate(-transform.right * Time.deltaTime * speed);
        }
       
        
    }
    void DestroyAttack()
    {
        Destroy(gameObject);
        Instantiate(destroyattack, transform.position, Quaternion.identity);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DestroyAttack();
        }
        else if (other.gameObject.CompareTag("Building") || other.gameObject.CompareTag("Ground"))
        {
            DestroyAttack();
        }
    }
}
