using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;
    float moveSpeed = 3f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    public Transform PlayerT;
    public GameObject bulletPre;
    public TextMeshProUGUI TextLevel;
    public float HP = 60f;
    public float MP = 100f;
    public float EXP = 100f;
    [SerializeField]public static int Level;
    private Bullets bullet;
    float timer = 0;
    private AudioSource theAS;
    Scene scene;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        scene = SceneManager.GetActiveScene();
        theAS = GetComponent<AudioSource>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (scene.name == "MonsterScene_1")
        {
            Attack();
        }
        Upgrade();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    void Attack()
    {
        timer += Time.deltaTime;
        if (timer>=0.7f)
        {
            theAS.Play();
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 pos = transform.position;
            Vector2 direction = (mousePos - pos).normalized;
            //GameObject bullet = Instantiate(bulletPre, pos, Quaternion.LookRotation(direction));
            GameObject bullet = MyObjectPool.Instance.Get(bulletPre);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Bullets>().SetSpeed(direction);
            timer = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            TakeDamage();
            collision.GetComponent<Enemy>().TakeDamage(20);
        }
    }
    private void TakeDamage()
    {
        HP -= 20;
        animator.SetTrigger("Attacked");
        
    }
    private void Upgrade()
    {
        if(EXP >99.5)
        {
            EXP = 0;
            Level += 1;
            HP += Level * 20;
            Bullets.attackHP += Level * 5;
            TextLevel.text = Level.ToString();
        }
        
    }
    
}
