using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asset
{
	//Простой ассет для хранения картинки и названия к нему
    [CreateAssetMenu(fileName = "New Item", menuName = "Items")]
    public class ItemAsset : ScriptableObject
    {
        public Sprite image;
        public string itemName;
    }

}
