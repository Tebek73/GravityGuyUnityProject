using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float speed = 1f;
    public float score = 0f;

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        score = PlayerPrefs.GetFloat("score", score);
        //ce trb sa se intample cu speed in functie de scor acum...
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        col.transform.SetParent(transform);
    }
}