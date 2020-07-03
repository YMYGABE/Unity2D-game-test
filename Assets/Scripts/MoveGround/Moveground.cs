using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveground : MonoBehaviour
{
    public Transform moveTo;
    public Transform LeftPos;   //设置平台左右移动的范围
    public Transform RightPos;
    public float waittime; //设置等待时间
    public float startwaittime;
    public float speed;
    private Transform playerDef;
    // Start is called before the first frame update
    void Start()
    {
        moveTo.position = LeftPos.position;
        waittime = startwaittime;
        playerDef = GameObject.FindGameObjectWithTag("Player").transform.parent; //获取player的层级
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveTo.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, LeftPos.position) < 0.1f)
        {
            moveTo.position = RightPos.position;
            
        }
        if (Vector2.Distance(transform.position, RightPos.position) < 0.1f)
        {
            moveTo.position = LeftPos.position;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.BoxCollider2D") ;
        {
            collision.gameObject.transform.parent = gameObject.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = playerDef;
        }
    }
}
