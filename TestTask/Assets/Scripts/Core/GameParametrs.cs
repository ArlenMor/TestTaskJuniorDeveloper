using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    //Класс с основными параметрами
    public class GameParametrs
    {
        //текущий уровень. когда равен 4 - всё обновляется
        public int currentLevel;

        //Текущий ответ для уровня
        public string currentAnswerName;
        //Имя объекта, на который мы кликнули
        public string clickName;
        //можно ли создать следующий ряд
        public bool canSpawn = true;

        //объект, который находится в item. Нужен чтобы его трясти
        public GameObject currentImageInItem;
        
        public GameParametrs()
        {
            currentLevel = 1;
            currentAnswerName = "";
            clickName = "-1";
        }
    }

}
