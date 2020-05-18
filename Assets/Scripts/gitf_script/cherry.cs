using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cherry : MonoBehaviour
{
    public Animator cherry_item;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        cherry_item = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cherry_item.SetTrigger("dis");
            Destroy(gameObject,time);
        }
    }
}
