using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject basketPrefab;// шаблон корзины 
    public static bool gameStop;// булевою переменна€ дл€ определени€ остановлена переменна€ или нет
    public int numBaskets = 3;//переменна€ котора€ обозначает количество экземпл€ров корзины
    public float basketBottomY = -14f;// переменна€ котора€ обозначает начальную кординату Y где будет находитса первый экземпл€р корзины 
    public float basketSpacingY = 2f;// переменна€ котора€ обозначает насколько следующий экземпл€р корзины будет выше предыдущего
    public List<GameObject> basketList;// масив корзин дл€ ловли м€ча
    public GameObject gameOver;// игровой объект отвечает за по€вление сцены проигрыша
    void Start()
    {
        gameStop = false;
        basketList = new List<GameObject>();// определ€етса как новый список  типа List<GameObject>()
        for (int i =0; i<numBaskets;i++)//цикл что создает экземпл€ры корзины
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);//создаетса переменна€ tBasketGO которому присваиваетса значение экземпл€ра basketPrefab 
            Vector3 pos = Vector3.zero;//создаетса переменна€ pos типа Vector3 которому присваиваетса кординаты (0;0;0)
            pos.y = basketBottomY + (basketSpacingY * i);//присваиваетса кордината корзины котора€ мен€етса с изменением i, каждый последующий экземпл€р будет выше предыдущего
            tBasketGO.transform.position = pos;//присваиваетса значение pos
            basketList.Add(tBasketGO);// ƒобавл€ет каждую вновь созданую корзину в список basketList
        }
    }
    public void AppleDestroyed()// обще доступна€ функци€ что уничтожает все екземпл€ры €блок
    {
        GameObject[] AppleArray = GameObject.FindGameObjectsWithTag("Apple");// возвращает масив всех существующих игровых объектов Apple
        foreach (GameObject tGo in AppleArray)// обход всех найденых объектов 
        {
            Destroy(tGo); // уничтожени€ объекта
        }
        //удалить одну корзину 
        // ѕолучить индекс последней корзины в basketList
        int basketIndex = basketList.Count - 1;
        //ѕолучить ссылку на этот игровой объект Basket
        GameObject tBasketGO = basketList[basketIndex];
        // »сключить корзину из списка и удалить сам игровой объект
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
        //≈сли корзины не осталосьб перезапустить игру
        if(basketList.Count == 0)
        {
            //SceneManager.LoadScene("SampleScene");// перезапустить сцену 
            gameOver.SetActive(true);//активировать экран проигрыша
            Time.timeScale = 0f;// остановить все процесы
            gameStop = true;// игра остановлена 

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
