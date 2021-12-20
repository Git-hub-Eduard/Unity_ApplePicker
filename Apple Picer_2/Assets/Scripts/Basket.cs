using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;// ���������� ����� ��� ����������� ����������������� � ���������� ���������� � �����

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreGT;// ��������� ���� ����� ���������� ����
    public static bool newRecord;// ������� ���������� ��� ����������� ������ ��� ���� ������ �� ����� ����� ������.
    public static int scoreOver;// ����������� ���������� ��� �������� ���������� ����� ���������
    void Start()
    {
        newRecord = false;
        //�������� ������ �� ������� ������ ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");//���������� � ����� ������� ������  � ������ ScoreCounter � ���������� ������ �� ���� ������� ������������� scoreGO
        // �������� ��������� Text ����� �������� ������� 
        scoreGT = scoreGO.GetComponent<Text>();
        // ������������� ��������� ����� ����� ������ 0
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //�������� ������� ���������� ��������� ���� �� ������ �� Input 
        Vector3 mousePos2D = Input.mousePosition;

        //����������  Z ������ ����������, ��� ������ � ���������� ������������ ��������� ��������� ���� 
        mousePos2D.z = -Camera.main.transform.position.z;
        // ������������� ����� �� ��������� ��������� � ���������� ��������� ���� 

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //����������� ������� ����� ��� � � ��������� � ��������� ����
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter(Collision coll)// ����� OnCollisionEnter �������� ������ ��� ����� ������� ������ ������ ������������ � ���� ��������
    {
        //���������� ������, �������� � ��� ������� 
        GameObject collideWith = coll.gameObject;// ��� ������ ����������� ��������� ��������� collideWith  ������ �� ������� ������ ������������ � ��������
        if (collideWith.tag == "Apple")// �������� ��� collideWith �������� ������� ��� ����� ���� tag ������������ � ����� Apple, ���� ��� ������, ��� �����������
        {
            Destroy(collideWith);
            // ������������� ����� scoreGT � ����� ����� 
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreOver = score;// �������� ���������.
            // ������������� ����� ����� ������� � ������� �� �� �����
            scoreGT.text = score.ToString();
            if(score > HighScore.score)// ������� �������� ���� ������� ��������� ����� ������ �� ������.
            {
                newRecord = true;// ����� ��������� ����� ������
                HighScore.score = score;// �������� ����� ������ 
            }
        }
    }
}
