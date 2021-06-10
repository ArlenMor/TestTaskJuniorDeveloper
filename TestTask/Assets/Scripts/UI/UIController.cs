using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using Core;

namespace UI
{
    //Класс отвечает за детальную логику работы UI
    public class UIController : MonoBehaviour
    {
        [Header("GameMaster:")]
        [SerializeField]
        private GameMaster gm;

        [Header("UIView")]
        [SerializeField]
        private UIView uiView;

        public GameObject textWithAnswer;

        private void Start()
        {
            textWithAnswer = transform.Find("Text").gameObject;
        }

        private void Update()
        {
            //Обнавление отрисоввки текста задания
            if(gm.GameParametrs.currentAnswerName != "")
               textWithAnswer.GetComponent<TextMeshProUGUI>().text = "Find " + gm.GameParametrs.currentAnswerName;
            //плавное затемнение загрузочного экрана
            if(gm.GameParametrs.currentLevel == 1)
            {
                uiView.CloseLoadImage();
            }
        }

        //команда отрисовки кнопки
        private void ShowRestartButton()
        {
            uiView.DrawRestart();
        }

        //команда отрисовки загрузочного окна
        private void ShowLoadImage()
        {
            uiView.DrawLoadImage();
        }

        public void Restart()
        {
            ShowRestartButton();

        }
    }

}

