using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    private bool a = false;
    private bool b = true;

    void Start()
    {
        InvokeRepeating("Activation", 2.0f, 2.0f);
    }

    void Activation()
    {
        bool aux = a;
        a = b;
        b = aux;
        fire1.SetActive(a);
        fire2.SetActive(a);
        fire3.SetActive(a);
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
}
