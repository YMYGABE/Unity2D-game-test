using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera camera;
    public Transform player;
    public float smooth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        if(player != null)
        {
            if(player.position != transform.position)
            {
                Vector3 playerPo = player.position;
                transform.position = Vector3.Lerp(transform.position, playerPo, smooth);
            }
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
