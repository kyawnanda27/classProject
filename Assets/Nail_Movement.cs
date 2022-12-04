using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nail_Movement : MonoBehaviour
{
    [SerializeField] GameObject controller;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] AudioSource audio;
    [SerializeField] bool balloonPop;
    
    // Start is called before the first frame update
    
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if(controller == null){
            controller = GameObject.FindGameObjectWithTag("Gamecontroller");
        }
        if(audio == null)
        {
            audio = GetComponent<AudioSource>();
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rigid.position.y >= 10.0f)
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        
        
        transform.Translate(Vector3.up * Time.deltaTime * 4);
        
    }

    private void OnTriggerEnter2D (Collider2D collider)
    {
        //transform.Translate(Vector3.up * Time.deltaTime *2);
        
        if (collider.gameObject.CompareTag("Balloon"))
        {
            controller.GetComponent<Scorekeeper>().UpdateScore();
            
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            
            controller.GetComponent<Scorekeeper>().WaitNextScene();
            Destroy(collider.gameObject);
            Destroy(gameObject);
            
            
        }

        if(collider.gameObject.CompareTag("Distractor"))
        {
            controller.GetComponent<Scorekeeper>().LoseLives();
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }



}
