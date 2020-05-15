using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarAttack : MonoBehaviour
{
    public GameObject gameObject;
    public Transform shotPoint;

    public float StartTime;
    public float NextTime;
    public int damage;
    // Update is called once per frame
   public void Update()
    {
        
            if(NextTime <= 0) {
            if (Input.GetButtonDown("FarAttack"))
            {
                Instantiate(gameObject, shotPoint.position, transform.rotation);
                NextTime = StartTime;
            }
        }
            else
            {
                NextTime -= Time.deltaTime;
            }
        
    }
    
}
