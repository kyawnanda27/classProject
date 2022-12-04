using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Balloon_Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool isFacingRight = true;
    float maxRight = 24.29f;
    float maxLeft = -12.05f;
    [SerializeField] float movement;
    Vector3 scaleIncre = new Vector3(0.3f, 0.3f, 0.3f);
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] Animator animator;

    const int IDLE = 0;
    const int POP = 1;

    // Start is called before the first frame update
    void Start()
    {
        float levelMultiplier = (SceneManager.GetActiveScene().buildIndex - 2.0f);
        Debug.Log("level is " + levelMultiplier);
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        
        if (speed == 0.0f)
            speed = 3 * levelMultiplier;

        if(animator == null)
            animator = GetComponent<Animator>();


        InvokeRepeating("SizeOverTime", 0.5f, 0.5f);

        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), );
       
    }

    void Update()
    {
        //transform.localScale = new Vector3 (1.1f, 1.1f, 1.1f);
        if(transform.localScale.x > 9.5f)
        {
            animator.SetInteger("pop", POP);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        movement = transform.position.x;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        switch(isFacingRight){
            case true:
                if (movement > 0 && !isFacingRight)
                    Flip();
                if(transform.position.x <= maxRight){
                    transform.Translate(Vector3.right * Time.deltaTime * speed);
                }
                else
                {
                    isFacingRight = false;
                }
                break;
                
            
            case false:
                if (movement < 0 && isFacingRight)
                    Flip();
                if(transform.position.x >= maxLeft)
                    transform.Translate(Vector3.left * Time.deltaTime * speed);
                else
                {
                    //transform.Rotate(0, 180, 0);
                    isFacingRight = true;
                }
                break;
                
        }
        /*if(transform.position.x <= 20.1f)
        transform.Translate(Vector2.right * Time.deltaTime);
        else
        transform.Translate(Vector2.left * Time.deltaTime);*/
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
        
    }

    void SizeOverTime()
    {
        transform.localScale += scaleIncre;
    }

    public void PopBalloon()
    {
        Destroy(gameObject);
    }

    /*void OnCollisionStay2D (Collision2D collid)
    {
        Debug.Log("insidethefun");
        if(collid.gameObject.CompareTag("Player"))
        {
            Debug.Log("Body hit");
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collid.collider);
        }
    }*/

   /* void OnTriggerEnter2D (Collider2D collid)
    {
        if(collid.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collid);
        }
    }*/
}
