using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    public Transform PlayerT;
    // Start is called before the first frame update
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

        if(PlayerT.transform.position.x>=22 && PlayerT.transform.position.x <= 26 
            && PlayerT.transform.position.y <= 0&& PlayerT.transform.position.x >= -5)
        {
            SceneManager.LoadScene("MonsterScene_1");
        }

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position +movement*moveSpeed*Time.fixedDeltaTime);
    }
}
