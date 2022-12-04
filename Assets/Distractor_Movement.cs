using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distractor_Movement : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    [SerializeField] bool isFacingRight = true;
    float maxRight = 25.35f;
    float maxLeft = -12.84f;
    [SerializeField] float movement;
    [SerializeField] Vector3 scaleIncre = new Vector3(0.01f, 0.01f, 0.01f);
    [SerializeField] Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        
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
       
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
        
    }


    
}
