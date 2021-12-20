using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;// ������ ��� �������� �����
    public float speed = 1f;// �������� ������ 
    public float leftAndRightEdge = 10f;// ��������� �� ������� ������ ��������� ����������� ������
    public float changeToChangeDirection = 0.1f;// ����������� ���������� ��������� ����������� 
    public float secondsBetweenDrops = 1f;// ������� �������� ����������� ����� 
    // Start is called before the first frame update
    void Start()
    {
        //���������� ������ ��� � ������� 
        Invoke("DropApple", 2f);//������� Invoke �������� �������, �������� ������, ����� ��������� ����� ������
    }
    void DropApple()//������� ��� ������� ��������� apple ��� ��������� AppleTree
    {
        GameObject apple = Instantiate(applePrefab);// ������� ��������� applePrefab � ����������� ��� ���������� apple ���� GameObject
        apple.transform.position = transform.position;// �������������� ����� ������ �������� ������� apple ������������� ������ �������������� ������   AppleTree
        Invoke("DropApple", secondsBetweenDrops);//������� Invoke �������� ������� DropApple ����� ������ ������� 
    }

    // Update is called once per frame
    void Update()
    {
        // ������� �����������
        Vector3 pos = transform.position;//����������� ��������� ���������� pos ��� �������� ������� ������� ������ 
        pos.x += speed * Time.deltaTime;//� ������������� �� ������������ �������� speed �� ���������� ������� Time.deltaTime
        transform.position = pos;// ���������� ��������  pos ������������� ������� �������� transform.position (�������� ����������� � ����� �����)
        // ��������� ����������� 
        if(pos.x < -leftAndRightEdge)//��������  �� ��������� �� �������� pos.x  ������ �������������� �������� leftAndRightEdge
        {
            speed = Mathf.Abs(speed);// speed �������������  ��������� Mathf.Abs(speed) ������� ���������� ��������� ������������� speed
        }
        else if(pos.x > leftAndRightEdge)//��������  �� ��������� �� �������� pos.x ������ �� ������������� �������� leftAndRightEdge
        {
            speed = -Mathf.Abs(speed);//speed �������������  ��������� -Mathf.Abs(speed), ��� � �������� ����������� �������� � ����
        }
        
    }
    void FixedUpdate()
    {
        if (Random.value < changeToChangeDirection)//�������� ���� ��������� ����� (Random.value) �������� ������ �� �������� changeToChangeDirection
        {
            speed *= -1;// �������� ����������� ������ ��������� �� -1, ��� � ���� ������� ������� ����������� 
        }
    }
}
