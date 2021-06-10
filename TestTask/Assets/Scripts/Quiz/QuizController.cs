using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Asset;
using Core;

namespace Quiz
{
    //Класс, который хранит все темы квиза в себе
    [System.Serializable]
    public class Theme
    {
        public string themeName;
        public List<ItemAsset> list;
    }


    //Класс для обработки детальной логики игры
    //Он занимается расчётами, формированием коллекции на сессию,
    //Контролем отрисовки
    public class QuizController : MonoBehaviour
    {
        [Header("GameMaster:")]
        [SerializeField]
        private GameMaster gm;

        [Header("AllThemes:")]
        [SerializeField]
        private List<Theme> AllThemes = new List<Theme>();

        private List<ItemAsset> currentSession = new List<ItemAsset>();

        [Header("ItemView")]
        [SerializeField]
        private ItemsView itemsView;

        private void Start()
        {
            CreateListForSession();

        }

        //Создание уникальной коллекции для сессии
        private void CreateListForSession()
        {
            bool repeat = false;
            int rand = Random.Range(0, AllThemes.Count);
            for (int i = 0; i < 9; i++)
            {
                repeat = false;
                ItemAsset currentAsset = AllThemes[rand].list[Random.Range(0, AllThemes[rand].list.Count)];
                foreach(var item in currentSession)
                {
                    if(item.itemName == currentAsset.itemName)
                    {
                        i--;
                        repeat = true;
                        break;
                    }
                }
                if (repeat)
                    continue;
                currentSession.Add(currentAsset);
            }
        }


        //создание определенного уровня
        //Выбор корректного ответа и отдача команды для отрисовки
        public void CreateNextLevel()
        {
            if(gm.GameParametrs.currentLevel == 1)
            {
                string answer = currentSession[Random.Range(0, 3)].itemName;
                gm.GameParametrs.currentAnswerName = answer;
                itemsView.DrawNextLevel(currentSession, 1);
            }else if(gm.GameParametrs.currentLevel == 2)
            {
                string answer = currentSession[Random.Range(3, 6)].itemName;
                gm.GameParametrs.currentAnswerName = answer;
                itemsView.DrawNextLevel(currentSession, 2);
            }
            else if(gm.GameParametrs.currentLevel == 3)
            {
                string answer = currentSession[Random.Range(6, 9)].itemName;
                gm.GameParametrs.currentAnswerName = answer;
                itemsView.DrawNextLevel(currentSession, 3);
            }
        }

        //команда отрисовки правильного ответа
        public void CurrentAnswerDraw()
        {
            itemsView.CurrentAnswer(gm.GameParametrs.currentImageInItem);
        }

        //Команда отрисовки неправильного ответа
        public void WrongAnswerDraw()
        {
            itemsView.WrongAnswer(gm.GameParametrs.currentImageInItem);
        }


        //Функция логики для рестарта уровня. 
        //Удаление всех объектов текущей сессии
        //Создание оъектов на будущую сессию
        public void Restart()
        {
            currentSession.Clear();
            for (int i = 0; i < 9; i++)
            {
                Destroy(itemsView.transform.GetChild(0).transform.GetChild(i).gameObject);
            }

            CreateListForSession();
            gm.GameParametrs.currentLevel = 1;
            gm.GameParametrs.canSpawn = true;
        }

        public void _Restart()
        {
            Invoke("Restart", 3f);
        }

        //Выключение кликабельности кнопок после конца текущей сессии
        public void OffItems()
        {
            for(int i = 0; i < 9; i++)
            {
                itemsView.transform.GetChild(0).transform.GetChild(i).GetComponent<Button>().interactable = false; ;
            }
        }
    }

}
