using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    public Text getScore;
    // Start is called before the first frame update
    void Update()
    {
        if(ApplePicker.gameStop == true)// проверять если игра остановлена 
        {
            oScore();
        }
    }

    public void oScore()
    {
        GameObject overScore = GameObject.Find("OverScore");//получить ссылку на объект OverScore
        getScore = overScore.GetComponent<Text>();// получить компнонент текст
        if(Basket.newRecord == true)// проверка если игрок установил новый рекорд
        {
            getScore.text = "New record: " + Basket.scoreOver;// вывести результат после остановки игры 
        }
        else
        {
            getScore.text = "Your score " + Basket.scoreOver;// вывести результат после остановки игры
        }
        
    }
    public void Again()// при нажатии на кнопку эта функция перезагружает сцену 
    {
        SceneManager.LoadScene("SampleScene");// перезагрузить игру
        Time.timeScale = 1f;
    }
}
