using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

using Core;

namespace Quiz
{
    //Класс обработки клика по item
    public class CickOn : MonoBehaviour, IPointerClickHandler
    {   
        private GameMaster gm;

        private void Start()
        {
            gm = transform.GetComponentInParent<GameMaster>();
        }

        //При нажатии запоминаю имя объекта и беру его картинку
        public void OnPointerClick(PointerEventData eventData)
        {
            if (transform.GetComponent<Button>().interactable == false)
                return;
            gm.GameParametrs.clickName = transform.name;
            gm.GameParametrs.currentImageInItem = eventData.selectedObject.transform.GetChild(0).gameObject;
        }
    }

}
