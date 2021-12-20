using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;// библиотека юнити что пользволяет взаимодействовать з елементами интерфейса в юнити

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreGT;// перменная куда будут начислятса очки
    public static bool newRecord;// булевая переменная для определения правда или ложь достиг ли игрок новый рекорд.
    public static int scoreOver;// статическая переменная для передачи результата после проигрыша
    void Start()
    {
        newRecord = false;
        //Получить ссылку на игровой объект ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");//отыскивает в сцене игровой объект  с именем ScoreCounter и возвращает ссылку на него которая присваиваетса scoreGO
        // получить компонент Text этого игрового объекта 
        scoreGT = scoreGO.GetComponent<Text>();
        // устанавливаем начальное число очков равным 0
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //получить текущие координаты указателя мыши на экране из Input 
        Vector3 mousePos2D = Input.mousePosition;

        //Координата  Z камеры определяет, как далеко в трехмерном пространстве находитса указатель мыши 
        mousePos2D.z = -Camera.main.transform.position.z;
        // преобразовать точку на двумерной плоскости в трехмерные кординаты игры 

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //переместить корзину вдоль оси Х в кординату Х указателя мыши
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter(Collision coll)// Метод OnCollisionEnter вызывает всякий раз когда какойто другой объект сталкиваетса с этой корзиной
    {
        //Отыскивает яблоко, попавшее в эту корзину 
        GameObject collideWith = coll.gameObject;// эта строка присваивает локальной перменной collideWith  ссылку на игровой объект столкнувшись с корзиной
        if (collideWith.tag == "Apple")// проверка что collideWith являетса яблоком для этого поле tag сравниваетса с тегом Apple, если это яблоко, оно уничтожитса
        {
            Destroy(collideWith);
            // преобразовать текст scoreGT в целое число 
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreOver = score;// записать результат.
            // преобразовать число очков обратно и вывести ее на экран
            scoreGT.text = score.ToString();
            if(score > HighScore.score)// условие проверки если текущий результат будет больше за рекорд.
            {
                newRecord = true;// игрок установил новый рекорд
                HighScore.score = score;// обновить новый рекорд 
            }
        }
    }
}
