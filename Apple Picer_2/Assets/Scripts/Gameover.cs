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
        if(ApplePicker.gameStop == true)// ��������� ���� ���� ����������� 
        {
            oScore();
        }
    }

    public void oScore()
    {
        GameObject overScore = GameObject.Find("OverScore");//�������� ������ �� ������ OverScore
        getScore = overScore.GetComponent<Text>();// �������� ���������� �����
        if(Basket.newRecord == true)// �������� ���� ����� ��������� ����� ������
        {
            getScore.text = "New record: " + Basket.scoreOver;// ������� ��������� ����� ��������� ���� 
        }
        else
        {
            getScore.text = "Your score " + Basket.scoreOver;// ������� ��������� ����� ��������� ����
        }
        
    }
    public void Again()// ��� ������� �� ������ ��� ������� ������������� ����� 
    {
        SceneManager.LoadScene("SampleScene");// ������������� ����
        Time.timeScale = 1f;
    }
}
