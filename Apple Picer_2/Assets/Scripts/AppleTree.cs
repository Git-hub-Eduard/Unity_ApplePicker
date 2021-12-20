using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;// шаблон дл€ создани€ €блок
    public float speed = 1f;// скорость €блуни 
    public float leftAndRightEdge = 10f;// расто€ние на котором должно измен€тса направление €блуни
    public float changeToChangeDirection = 0.1f;// веро€тность случайного изменени€ направлени€ 
    public float secondsBetweenDrops = 1f;// частота создание экземпл€ров €блок 
    // Start is called before the first frame update
    void Start()
    {
        //сбрасывать €блоки раз в секунду 
        Invoke("DropApple", 2f);//‘ункци€ Invoke вызывает функцию, заданную именем, через указанное число секунд
    }
    void DropApple()//‘ункци€ что создает экземпл€р apple где находитса AppleTree
    {
        GameObject apple = Instantiate(applePrefab);// создает екземпл€р applePrefab и присваивает его переменной apple типа GameObject
        apple.transform.position = transform.position;// ћестоположение этого нового игрового объекта apple устанавливаем равным местоположению €блони   AppleTree
        Invoke("DropApple", secondsBetweenDrops);//‘ункци€ Invoke вызывает функцию DropApple через каждую секунду 
    }

    // Update is called once per frame
    void Update()
    {
        // простое перемещение
        Vector3 pos = transform.position;//определение локальной переменной pos дл€ хранение текущей позиции €блони 
        pos.x += speed * Time.deltaTime;//х увеличиваетса на произведении скорости speed на промежуток времени Time.deltaTime
        transform.position = pos;// измененное значение  pos присваиваетса обратно свойству transform.position (вызывает перемещение в новое место)
        // изменение направлени€ 
        if(pos.x < -leftAndRightEdge)//проверка  не оказалось ли значение pos.x  меньше отрицательного значени€ leftAndRightEdge
        {
            speed = Mathf.Abs(speed);// speed присваиваетса  результат Mathf.Abs(speed) которое возвращает абсолютно положительное speed
        }
        else if(pos.x > leftAndRightEdge)//проверка  не оказалось ли значение pos.x больше за положительное значение leftAndRightEdge
        {
            speed = -Mathf.Abs(speed);//speed присваиваетса  результат -Mathf.Abs(speed), что б изменить направление движени€ в лево
        }
        
    }
    void FixedUpdate()
    {
        if (Random.value < changeToChangeDirection)//проверка если случайное число (Random.value) окажетса меньше за значение changeToChangeDirection
        {
            speed *= -1;// изменить направление путьом умножение на -1, что в свою очередь изменит направление 
        }
    }
}
