using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

using Asset;

namespace Quiz
{
    //Класс, который отвечает за визуализацию item
    public class ItemsView : MonoBehaviour
    {
        [SerializeField]
        private GameObject itemsPanel;
        

        public ParticleSystem starsPref;
        private ParticleSystem starsInst;

        public Sprite Circle;

        public GameObject prefItem;
        private GameObject instItem;

        //Функция рисовки следующего уровня
        public void DrawNextLevel(List<ItemAsset> Items, int level)
        {
            var seq = DOTween.Sequence();
            int start = 0;
            int end = 0;
            if(level == 1)
            {
                start = 0;
                end = 3;
            }else if (level == 2)
            {
                start = 3;
                end = 6;
            }
            else
            {
                start = 6;
                end = 9;
            }

            for (int i = start; i < end; i++)
            {
                instItem = Instantiate(prefItem, transform.Find("Items"));
                instItem.transform.localScale = new Vector3(0, 0, 0);
                instItem.name = Items[i].itemName;
                instItem.GetComponent<Image>().sprite = Circle;
                instItem.transform.GetChild(0).GetComponent<Image>().sprite = Items[i].image;
                seq.Append(instItem.transform.DOScale(1.2f, 0.25f));
                seq.Append(instItem.transform.DOScale(0.95f, 0.25f));
                seq.Append(instItem.transform.DOScale(1f, 0.25f));
            }
        }

        //При выборе правильного ответа
        public void CurrentAnswer(GameObject item)
        {
            starsInst = Instantiate(starsPref, item.transform);
            var seq = DOTween.Sequence();
            seq.Append(item.transform.DOScale(1.2f, 0.25f));
            seq.Append(item.transform.DOScale(0.95f, 0.25f));
            seq.Append(item.transform.DOScale(1f, 0.25f));
        }

        //При выборе неправильного объекта
        public void WrongAnswer(GameObject item)
        {
            item.transform.DOPunchPosition(new Vector3(item.transform.position.x + 1,
                                                                  item.transform.position.y + 1,
                                                                item.transform.position.z), 2);
        }

    }

}
