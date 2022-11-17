using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{
    public GameObject enemy;
    Vector3 createPos,createPos1;
    public float timer=0;
    private void Awake()
    {
        
    }
    void Update()
    {
        CreateEnemy();
    }
    void CreateEnemy()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            createPos = new Vector3(Player.instance.transform.position.x + Random.Range(-10.0f, -4f),
                Player.instance.transform.position.y + Random.Range(-10.0f, 10f),-1);
            createPos1 = new Vector3(Player.instance.transform.position.x + Random.Range(4f, 10f),
                Player.instance.transform.position.y + Random.Range(-10f, 10f),-1);
            enemy.transform.position = createPos;
            MyObjectPool.Instance.Get(enemy);
            enemy.transform.position = createPos1;
            MyObjectPool.Instance.Get(enemy);
            timer = 0;
        }
    }
    private Vector3 RandomPosition()
    {
        
        Vector2 vec2 = new Vector3();
        while (!(Vector2.Distance(Player.instance.transform.position, vec2) > 10 && Vector2.Distance(Player.instance.transform.position, vec2) < 15))
        {
            //创建随机点
        }
        return vec2;
    }
    
}
