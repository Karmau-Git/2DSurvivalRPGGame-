using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;
    public Rigidbody2D rb;
    Vector2 distance;
    Vector2 direction;
    float navSpeed=6f;
    public float HP = 20;
    float timer1 = 0;
    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
     }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        EnemyDestory();
    }
    private void FollowPlayer()
    {
        distance = Player.instance.rb.position - rb.position;
        direction = (Player.instance.rb.position - (Vector2)transform.position).normalized;
        if (distance.x>2||distance.x<-2||distance.y>2||distance.y<-2)
        {
            rb.MovePosition((Vector2)transform.position + direction * navSpeed * Time.deltaTime);
        }
    }
    private void EnemyDestory()
    {
        if (HP <=0.5)
        {
            MyObjectPool.Instance.Push(gameObject);
            Player.instance.EXP += 5;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Skill"))
        {
            HP -= 40;
        }    
    }
    public void TakeDamage(float damage)
    {
        //ПлбЊ
        HP -= damage;
    }
    public void TimeCourse()
    {
        timer1 += Time.deltaTime;
        if(timer1 > 30)
            HP += 20;  
    }
}
