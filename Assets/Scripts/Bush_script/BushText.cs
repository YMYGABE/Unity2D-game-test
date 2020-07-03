using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushText : MonoBehaviour
{
    public GameObject Textobject;
    private bool isPlayerTouch;
    // Start is called before the first frame update
    void Start()
    {
        isPlayerTouch = false;
        Textobject = GameObject.Find("bushtext");
        Textobject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") 
            && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerTouch = true;
            Textobject.SetActive(true);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") 
            && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerTouch = false;
            Textobject.SetActive(false);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isPlayerTouch){
                Debug.Log("lalalal");
        }
    }
}
