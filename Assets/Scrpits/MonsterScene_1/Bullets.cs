using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    Rigidbody2D rb;
    float bulletSpeed = 10f;
    public GameObject bulletPre;
    public static float attackHP = 20;
    public static Bullets instance;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    public void SetSpeed(Vector2 direction)
    {
        rb.velocity = direction * bulletSpeed;
        StartCoroutine(DestoryObj(3f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //Destroy(gameObject);
            MyObjectPool.Instance.Push(gameObject);
            collision.GetComponent<Enemy>().TakeDamage(attackHP);
        }
    }
    IEnumerator DestoryObj(float time)
    {
        yield return new WaitForSeconds(time);
        //Destroy(gameObject);
        MyObjectPool.Instance.Push(gameObject);
    }
}
