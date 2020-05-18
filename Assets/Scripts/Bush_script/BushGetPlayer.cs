using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushGetPlayer : MonoBehaviour
{
    public SpriteRenderer bush;
    
    public Color BushColor;
    // Start is called before the first frame update
    void Start()
    {
        BushColor = bush.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
                bush.color = new Color(255, 255, 255, 0.5f);
                bush.sortingOrder = 2;
           
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            
                bush.color = BushColor;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
