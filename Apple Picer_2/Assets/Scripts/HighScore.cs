using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 1000;// общедоступная переменная дает возможность обращатса к ней через другие класи
    // Start is called before the first frame update
    void Awake()
    {
        // если значение HighScore уже существует  в PlayerPrefs, прочитать его
        if(PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");// прочитать значение из PlayerPrefs 
        }
        //сохранить текущее значение HighScore в хранилище 
        PlayerPrefs.SetInt("HighScore", score);
    }

    // Update is called once per frame
    void Update()// отобразить High Score: 1000
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;
        //Обновить HighScore в PlayerPrefsб если необходимо
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score); //сохранить  значение HighScore в хранилище 
        }

    }
}
