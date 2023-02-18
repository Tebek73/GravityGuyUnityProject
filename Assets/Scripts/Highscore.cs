using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Highscore : MonoBehaviour
{
    public Text geani;
    public float highscore;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetFloat("highscore", highscore);
    }

    // Update is called once per frame
    void Update()
    {
        geani.text = "Highscore: " + (int)highscore;
    }
}
