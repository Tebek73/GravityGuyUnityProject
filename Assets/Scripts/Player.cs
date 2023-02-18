using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public Text scoreText;
    float score;
    float pointIncreasePerSecond;
    bool gameStarted = false;
    public Text healthText;
    public int maxHealth = 100;
    public int health;
    private bool alive = true;
    public GameObject finishText;
    public Text showGravity;

    public ParticleSystem plyr;
    public ParticleSystem enmy;

    public Text tutorial;

    public static float highscore;

 

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        score = 0f;
        PlayerPrefs.SetFloat("score", score);
        pointIncreasePerSecond = 1f;
        health = maxHealth;
        highscore = PlayerPrefs.GetFloat("highscore", highscore);
        
    }

    
    
    public void ReverseGravity()
    {
        rb.gravityScale = rb.gravityScale * -1;
        transform.Rotate(0, 0, 180);
        if (showGravity.text == "<") showGravity.text = ">";
        else showGravity.text = "<";
        Destroy(GameObject.FindWithTag("StartPlatform"));
        tutorial.text = "";
        gameStarted = true;
        if (alive == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            //animation for dying for now we have color change
        }
    }

    void Update()
    {
        if(gameStarted && alive)
        {
            scoreText.text = "Score: " + (int)score;
            score += pointIncreasePerSecond * Time.deltaTime;
            if (health < 0) health = 0;
            healthText.text = "HP: " + health;
        }
        if (health <= 0 && score > 5)
        {
            alive = false;
            finishText.SetActive(true);
            GetComponent<Renderer>().enabled = false;
        }
        if (health <= 0 && score <= 5) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (score > highscore)
        {
            highscore = score;
            tutorial.text = "new highscore!";
        }
        PlayerPrefs.SetFloat("highscore", highscore);
        PlayerPrefs.SetFloat("score", score);

        

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            health -= 10;
            plyr.Play();
        }
    }
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if(collision.gameObject.tag == "Finish")
        {
            health -= 100;
        }
        
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            enmy.Play();
            score += 20;
        }
        if(collision.gameObject.tag == "HealthPotion")
        {
            health += 25;
        }
    }
}
