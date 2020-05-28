using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cherry : MonoBehaviour
{
    public Animator cherry_item;
    public float time;
    public int food;
    public PlayerHealth phealth;
    // Start is called before the first frame update
    void Start()
    {
        phealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
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
            phealth.BackHealth(food);
            cherry_item.SetTrigger("dis");
            Destroy(gameObject);

        }
    }
}
