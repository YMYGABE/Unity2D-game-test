using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  //get the player
    public float smooth;    //set the camera move speed

    public Vector2 minPostion;
    public Vector2 maxPostion;


    // Start is called before the first frame update
    void Start()
    {
        GameCamera.cameraShake = GameObject.FindGameObjectWithTag("ShakeCamera").GetComponent<CameraShake>();
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            if (player.position != transform.position)
            {
                Vector3 playerPo = player.position;
                playerPo.x = Mathf.Clamp(playerPo.x, minPostion.x, maxPostion.x);
                playerPo.y = Mathf.Clamp(playerPo.y, minPostion.y, maxPostion.y);
                transform.position = Vector3.Lerp(transform.position, playerPo, smooth);
            }
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
