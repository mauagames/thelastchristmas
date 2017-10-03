using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Movimentacao : MonoBehaviour {

    public float velocidade = 9f;
    public float fpulo = 3;
    private Rigidbody2D rb;
    private Animator anim;
    public bool podePular = false;
    public bool duploPulo = true;

    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

       /* if(Input.GetKey( KeyCode.RightArrow))
        {
            this.transform.Translate(new Vector3(velocidade * Time.deltaTime, 0, 0));
            print("Direita");
        }
        */

        float h = Input.GetAxis("Horizontal");
     //   float v = Input.GetAxis("Vertical");
            this.transform.Translate(new Vector3(h * velocidade * Time.deltaTime,0.0f, 0));

       
        if(h > 0.0f)
        {
            anim.ResetTrigger("idle");
            anim.SetTrigger("correndo");
        }
        
        else if(h< 0.0f)
        {
            anim.ResetTrigger("idle");
            this.GetComponent("Sprite Render");
            anim.SetTrigger("correndo");
        }
        else
        {
            //this.gameObject.GetComponent<SpriteRenderer>.;
            anim.ResetTrigger("idle");
            // anim.SetTrigger("correndo");
        }

        if ((Input.GetKeyDown(KeyCode.Space)) && (podePular))
        {
            rb.AddForce(new Vector2(0.0f, fpulo), ForceMode2D.Impulse);
            anim.SetTrigger("pulo");
        }

        if ((Input.GetKeyDown(KeyCode.Space)) && (duploPulo) && (!podePular))
        {
            rb.AddForce(new Vector2(0.0f, fpulo), ForceMode2D.Impulse);
            duploPulo = false;
            anim.ResetTrigger("idle");
            anim.SetTrigger("planando");
        }

        if(Input.GetKey(KeyCode.Space))
        {
            rb.
            rb.AddForce(new Vector2(0.0f, 0.5f), ForceMode2D.Impulse);

        }
        // this.transform.Rotate(new Vector3(0, 0, this.velocidade));
    }

    void OnCollisionEnter2D(Collision2D outro)s
    {
        if (outro.gameObject.CompareTag("chao"))
        {
            podePular = true;
            duploPulo = true;
         }


        anim.SetTrigger("idle");
        anim.ResetTrigger("planando");
        print(outro.gameObject.tag);

    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("caixa"))
        {
            outro.gameObject.SetActive(false);
        }
    }

    void OnCollisionExit2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("chao"))
        {
            podePular = false;

        }



    }
}
