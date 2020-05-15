using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    public float Playtime;
    public 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Playtime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
