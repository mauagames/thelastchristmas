using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatilho : MonoBehaviour {

    public bool podeRodar;
    public GameObject objRotacao;
    public float velRot = 10;
	// Use this for initialization
	void Start () {
        podeRodar = false;
        objRotacao = GameObject.Find("Crate");
	}
	
	// Update is called once per frame
	void Update () {
        if (podeRodar)
            objRotacao.transform.Rotate(new Vector3(0,0,velRot * Time.deltaTime));
	}

    void OnTriggerEnter2D(Collider2D objeto)
    {
        if (objeto.gameObject.CompareTag("herói"))
            podeRodar = true;
    }

    void OnTriggerExit2D(Collider2D objeto)
    {
        if (objeto.gameObject.CompareTag("herói"))
            podeRodar = false;
    }
}
