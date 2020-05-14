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
        transform.Translate(transform.right * Time.deltaTime*speed);
    }
    void DestroyAttack()
    {
        Instantiate(destroyattack, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
