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
        if(transform.position.y<bottomY)//проверка если кордината Y экземпл€ра Apple меньше за значение bottomY
        {
            Destroy(this.gameObject);// Destroy() используетса дл€ удалени€ указаных объектов в данном случае удал€етса игровой объект Apple
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();// получить ссылку на коипонент ApplePicker главной камеры Main Camera
            apScript.AppleDestroyed();// вызвать общедоступный метод AppleDestroyed()
        }
    }
}
