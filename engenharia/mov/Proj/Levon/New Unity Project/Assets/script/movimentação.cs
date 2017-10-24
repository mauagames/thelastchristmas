using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentação : MonoBehaviour {

    public float velocidade = 7f;
    public float thrust;
    private Rigidbody2D rb;
    public bool podePular = false;
    private int count = 2;              //numero de pulso possiveis
    public Transform parent;
    // Use this for initialization
    void Start () {
        rb = this.GetComponentInParent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if ( Input.GetKey(KeyCode.RightArrow) )
        {
            transform.Translate(new Vector3(velocidade * Time.deltaTime, 0, 0));
            print("direita");
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-velocidade * Time.deltaTime, 0, 0));
            print("esquerda");
        }
        */

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // transform.Translate(new Vector3(h*velocidade * Time.deltaTime, v * velocidade * Time.deltaTime, 0));
        //transform.Translate(new Vector3(h * velocidade * Time.deltaTime, 0, 0));
        

        if (Input.GetKeyDown(KeyCode.Space) && (count > 0))
        {
            print("É PRA PULAR");
            rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
            count--;

        }

    }


 

    void OnCollisionEnter2D(Collision2D objeto)
    {
        if (objeto.gameObject.CompareTag("plataforma"))
           count = 2;


    }

   
    void OnCollisionExit2D(Collision2D objeto)
    {
        if (objeto.gameObject.CompareTag("plataforma"))
            podePular = false;
    }


}
