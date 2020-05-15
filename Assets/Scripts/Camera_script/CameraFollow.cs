using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smooth;

    // Start is called before the first frame update
    void Start()
    {
        GameCamera.cameraShake = GameObject.FindGameObjectWithTag("ShakeCamera").GetComponent<CameraShake>();
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
