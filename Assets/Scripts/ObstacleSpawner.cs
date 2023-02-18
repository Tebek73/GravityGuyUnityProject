using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] platformPrefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    public Text scoreText;
    private int score = 0;
    private int l = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlatformSpawn());
    }

    IEnumerator PlatformSpawn()
    {
        while (true)
        {
            score = int.Parse(scoreText.text.Substring(6));
            if (score > 10)
            {
                l = 1;
            }
            if (score > 50) l = 2;
            if (score > 100) l = platformPrefab.Length - 1 ;
            

            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);

            
            GameObject gameObject = Instantiate(platformPrefab[Random.Range(0, l+1)], position, Quaternion.identity);

            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 10f);

        }
    }

    void Update()
    {
       

    }

   

    //apoi trebuie sa pun if-uri cu in functie de scor gameObject-ul care sa primeasca instantiate acolo la platformPrefab[randonRange] punem sa creasca random range-ul la 10,50,100,250,500,100

}
