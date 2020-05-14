using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarAttack : MonoBehaviour
{
    public GameObject gameObject;
    public Transform shotPoint;
    
    public int damage;
    // Update is called once per frame
   public void Update()
    {
        if (Input.GetButtonDown("FarAttack"))
        {
            Instantiate(gameObject, shotPoint.position, Quaternion.identity);

        }
    }
    
}
