using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded = true;
    [SerializeField] bool shootAllowed = true;
    [SerializeField] bool shoot = false;
    [SerializeField] GameObject nail;
    [SerializeField] Animator animator;

    const int IDLE = 0;
    const int RUN = 1;
    const int JUMP = 2;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if (speed == 0)
            speed = 10;
        
        if(animator == null)
            animator = GetComponent<Animator>();

        if(jumpForce == 0.0f)
            jumpForce = 250.0f;

        animator.SetInteger("motion", IDLE);
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;

        if (Input.GetButton("Fire1")){
            
            shoot = true;
            
        }
        
    }

    //called potentially multiple times per frame
    //used for physics & movement
    void FixedUpdate()
    { 
        rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
        if(!jumpPressed && isGrounded)
        {
            if(movement > 0 || movement < 0)
                animator.SetInteger("motion", RUN);
            else
                animator.SetInteger("motion", IDLE);
        }
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();
        if (jumpPressed && isGrounded){
            Jump();
            jumpPressed = false;
        }
        if (shootAllowed && shoot){
            Invoke("ChangeStateOfShoot", 1);
            Spawn();
        }

            
            
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        isGrounded = false;
        jumpPressed = false;
        animator.SetInteger("motion", JUMP);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void Spawn(){
        shootAllowed = false;
        shoot = false;
        Vector2 position = new Vector2(rigid.position.x, rigid.position.y);
        Instantiate(nail, position, Quaternion.identity);
    }
//For original shooting state
    void ChangeStateOfShoot(){
        shootAllowed = true;
        shoot = false;
    }

   
}
