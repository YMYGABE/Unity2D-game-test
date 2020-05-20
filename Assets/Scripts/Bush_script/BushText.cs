using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushText : MonoBehaviour
{
    public GameObject Textobject;
    // Start is called before the first frame update
    void Start()
    {
        Textobject = GameObject.Find("bushtext");
        Textobject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Textobject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Textobject.SetActive(false);

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
