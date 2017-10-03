using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatilho1 : MonoBehaviour {
    public bool podeRotacionar;
    public GameObject objDeRotacao;
    public float velRot = 3000;

	// Use this for initialization
	void Start () {
        podeRotacionar = false;
	}

    // Update is called once per frame
    void Update () {
        if (podeRotacionar == true)
        {        
                objDeRotacao.transform.Rotate(new Vector3 (0.0f, 0.0f, velRot * Time.deltaTime));
        }
	}

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Vascolina"))
        {
            podeRotacionar = true;
        }
    }

    void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Vascolina"))
        {
            podeRotacionar = false;
        }
    }
}
