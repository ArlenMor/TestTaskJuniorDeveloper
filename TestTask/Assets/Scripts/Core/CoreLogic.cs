using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using Quiz;
using UI;

namespace Core
{
    //Класс отвечающий за всю корневую логику игры
    public class CoreLogic : MonoBehaviour
    {
        [Header("GameMaster:")]
        [SerializeField]
        private GameMaster gm;

        [Header("QuizController:")]
        [SerializeField]
        private QuizController quizController;

        [Header("UIController")]
        [SerializeField]
        private UIController uiController;

        private void Update()
        {
            //проверка на спавн очередного ряда
            if (gm.GameParametrs.canSpawn)
            {
                quizController.CreateNextLevel();
                gm.GameParametrs.canSpawn = false;
            }

            //Если выбран правильный ответ
            if (gm.GameParametrs.currentAnswerName == gm.GameParametrs.clickName)
            {
                quizController.CurrentAnswerDraw();
                gm.GameParametrs.canSpawn = true;
                gm.GameParametrs.currentLevel++;
                gm.GameParametrs.clickName = "";
                gm.GameParametrs.currentImageInItem = null;
            }
            //если выбран неправильный ответ
            else if (gm.GameParametrs.currentImageInItem != null)
            {
                quizController.WrongAnswerDraw();
                gm.GameParametrs.currentImageInItem = null;
            }

            //Если конец игры
            if (gm.GameParametrs.currentLevel == 4)
            {
                quizController.OffItems();
                uiController.Restart();
            }
        }
    }

}
