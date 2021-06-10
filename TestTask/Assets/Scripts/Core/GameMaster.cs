using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
	//Класс для управления общими данными
	//В дальнейшем можно расширить его, добавив, например, параметры игрока (рекорды, деньги и т.п)
    public class GameMaster : MonoBehaviour
    {
        private GameParametrs gameParametrs = new GameParametrs();

        public GameParametrs GameParametrs { get => gameParametrs; set => gameParametrs = value; }
    }

}
