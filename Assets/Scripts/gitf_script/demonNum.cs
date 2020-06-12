using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class demonNum : MonoBehaviour
{
    public Text numtext;
    public static int num;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numtext.text = num.ToString();
    }
}
