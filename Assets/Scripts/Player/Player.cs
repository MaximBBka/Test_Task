using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Player : MonoBehaviour, ITake
    {
        [SerializeField] private PlayerController controller;

        private void Start()
        {
            controller.Init(this);
        }
        private void FixedUpdate()
        {
            controller.OnFixedUpdate();
        }
        public void Up(int value)
        {
            controller._modelPlayer.TotalMoney += value;
        }

        public void MultiplieUp(int value)
        {
            controller._modelPlayer.TotalMoney *= value;
        }
    }
}
