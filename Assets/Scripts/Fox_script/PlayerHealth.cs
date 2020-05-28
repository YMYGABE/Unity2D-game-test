using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public Animator animator;
    public float time;
    public int numblink;
    public float blinktime;
    public ScreenFlash flash;

    public Renderer renderer;
    public CapsuleCollider2D capsule;
    public BoxCollider2D box; 
    // Start is called before the first frame update
    void Start()
    {
        Fox_Health.HealthMax = health;
        Fox_Health.HealthCurrent = health;
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        flash = GameObject.FindGameObjectWithTag("ScreenFlash").GetComponent<ScreenFlash>();
        capsule = GetComponent<CapsuleCollider2D>();
        box = GetComponent<BoxCollider2D>();
        renderer = GetComponent<Renderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamagePlayer(int damage)
    {
        flash.FlashScreen();
        health -= damage;
        Fox_Health.HealthCurrent = health;
        if(health <= 0.0f)
        {
            Fox_Health.HealthCurrent = 0;
            animator.SetBool("death", true);
            capsule.enabled = false;
            box.enabled = false;
            Destroy(gameObject,time);
        }
        
        Playerblink(numblink, blinktime);
    }
    public void BackHealth(int food)
    {
        health += food;
        Fox_Health.HealthCurrent = health;
        if (health > 10)
        {
            Fox_Health.HealthCurrent = 10;
        }
    }

     void Playerblink(int blinks,float time)
    {
        StartCoroutine(Blink(blinks, time));
    }
    IEnumerator Blink(int blinks,float time)
    {
        for (int i = 0; i < blinks; i++) //控制闪烁次数
        {
            renderer.enabled = !renderer.enabled;
            yield return new WaitForSeconds(time);
        }
        renderer.enabled = true;
    }
    
}
