using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    // Start is called before the first frame update
    public static float bottomY = -20f;//
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<bottomY)//�������� ���� ��������� Y ���������� Apple ������ �� �������� bottomY
        {
            Destroy(this.gameObject);// Destroy() ������������ ��� �������� �������� �������� � ������ ������ ��������� ������� ������ Apple
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();// �������� ������ �� ��������� ApplePicker ������� ������ Main Camera
            apScript.AppleDestroyed();// ������� ������������� ����� AppleDestroyed()
        }
    }
}
