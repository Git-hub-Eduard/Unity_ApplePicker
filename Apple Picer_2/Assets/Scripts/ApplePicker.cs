using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject basketPrefab;// ������ ������� 
    public static bool gameStop;// ������� ���������� ��� ����������� ����������� ���������� ��� ���
    public int numBaskets = 3;//���������� ������� ���������� ���������� ����������� �������
    public float basketBottomY = -14f;// ���������� ������� ���������� ��������� ��������� Y ��� ����� ��������� ������ ��������� ������� 
    public float basketSpacingY = 2f;// ���������� ������� ���������� ��������� ��������� ��������� ������� ����� ���� �����������
    public List<GameObject> basketList;// ����� ������ ��� ����� ����
    public GameObject gameOver;// ������� ������ �������� �� ��������� ����� ���������
    void Start()
    {
        gameStop = false;
        basketList = new List<GameObject>();// ������������ ��� ����� ������  ���� List<GameObject>()
        for (int i =0; i<numBaskets;i++)//���� ��� ������� ���������� �������
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);//��������� ���������� tBasketGO �������� ������������� �������� ���������� basketPrefab 
            Vector3 pos = Vector3.zero;//��������� ���������� pos ���� Vector3 �������� ������������� ��������� (0;0;0)
            pos.y = basketBottomY + (basketSpacingY * i);//������������� ��������� ������� ������� �������� � ���������� i, ������ ����������� ��������� ����� ���� �����������
            tBasketGO.transform.position = pos;//������������� �������� pos
            basketList.Add(tBasketGO);// ��������� ������ ����� �������� ������� � ������ basketList
        }
    }
    public void AppleDestroyed()// ���� ��������� ������� ��� ���������� ��� ���������� �����
    {
        GameObject[] AppleArray = GameObject.FindGameObjectsWithTag("Apple");// ���������� ����� ���� ������������ ������� �������� Apple
        foreach (GameObject tGo in AppleArray)// ����� ���� �������� �������� 
        {
            Destroy(tGo); // ����������� �������
        }
        //������� ���� ������� 
        // �������� ������ ��������� ������� � basketList
        int basketIndex = basketList.Count - 1;
        //�������� ������ �� ���� ������� ������ Basket
        GameObject tBasketGO = basketList[basketIndex];
        // ��������� ������� �� ������ � ������� ��� ������� ������
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
        //���� ������� �� ��������� ������������� ����
        if(basketList.Count == 0)
        {
            //SceneManager.LoadScene("SampleScene");// ������������� ����� 
            gameOver.SetActive(true);//������������ ����� ���������
            Time.timeScale = 0f;// ���������� ��� �������
            gameStop = true;// ���� ����������� 

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
