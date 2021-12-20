using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 1000;// ������������� ���������� ���� ����������� ��������� � ��� ����� ������ �����
    // Start is called before the first frame update
    void Awake()
    {
        // ���� �������� HighScore ��� ����������  � PlayerPrefs, ��������� ���
        if(PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");// ��������� �������� �� PlayerPrefs 
        }
        //��������� ������� �������� HighScore � ��������� 
        PlayerPrefs.SetInt("HighScore", score);
    }

    // Update is called once per frame
    void Update()// ���������� High Score: 1000
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;
        //�������� HighScore � PlayerPrefs� ���� ����������
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score); //���������  �������� HighScore � ��������� 
        }

    }
}
