using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI
{
    //класс отвечающий за отрисовку всего, что связано с UI
    public class UIView : MonoBehaviour
    {
        [SerializeField]
        private Button restart;

        [SerializeField]
        private Image loadImage;

        private bool startDrawRestartImage = false;

        private void Update()
        {
            //плавное появление
            if(startDrawRestartImage)
            {
                loadImage.color = Color.Lerp(loadImage.color, new Color(0, 0, 0, 1), Time.deltaTime * 3);
                loadImage.transform.GetComponentInChildren<TextMeshProUGUI>().color = Color.Lerp(loadImage.transform.GetComponentInChildren<TextMeshProUGUI>().color, new Color(1, 1, 1, 1), Time.deltaTime * 3);
            }
            else //плавное затемнение
            {
                loadImage.color = Color.Lerp(loadImage.color, new Color(0, 0, 0, 0), Time.deltaTime * 3);
                loadImage.transform.GetComponentInChildren<TextMeshProUGUI>().color = Color.Lerp(loadImage.transform.GetComponentInChildren<TextMeshProUGUI>().color, new Color(1, 1, 1, 0), Time.deltaTime * 3);

            }
        }

        
        public void DrawRestart()
        {
            restart.gameObject.SetActive(true);
        }

        public void DrawLoadImage()
        {
            startDrawRestartImage = true;
        }

        public void CloseLoadImage()
        {
            startDrawRestartImage = false;
            restart.gameObject.SetActive(false);
        }
    }

}
