using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEagle : Enemy
{
    public float speed;
    public float startwaittime;
    private float waittime;
    public PlayerHealth playerHealth;
    public player_controller controller;

    public Transform Player;
    public Transform moveto;
    public Transform leftDown;
    public Transform rightUp;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        waittime = startwaittime;
        moveto.position = GetRandomPosition();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<player_controller>();
    }

    // Update is called once per frame
    void Update()
    {
        Trun();
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position, moveto.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position,moveto.position) < 0.1f) 
        {
            if(waittime <= 0)
            {
                moveto.position = GetRandomPosition();
                waittime = startwaittime;
            }
            else
            {
                waittime--;
            }
        }
        if(Player != null) {
            if (Vector2.Distance(transform.position, Player.position) < 5.0f && playerHealth.health != 0)
            {
                if (controller.cansee)
                {
                    moveto.position = Player.position;
                }
            }
        }
        



    }
    Vector2 GetRandomPosition()
    {
        Vector2 vectorPo = new Vector2(Random.Range(leftDown.position.x, rightUp.position.x), Random.Range(leftDown.position.y, rightUp.position.y));
        return vectorPo;
    }
    void Trun()
    {
        if(transform.position.x < moveto.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if(transform.position.x > moveto.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
