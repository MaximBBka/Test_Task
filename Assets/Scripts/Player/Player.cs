using Game;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Player : MonoBehaviour, ITake, IUpgrade
    {
        [field: SerializeField] public PlayerController controller { get; private set; }
        [field: SerializeField] public GameManager GameManager { get; private set; }
        [SerializeField] private Slider FillUpgrade;
        [SerializeField] private GameObject[] _skins;
        [SerializeField] private TextMeshProUGUI TotalMoney;
        [SerializeField] private TextMeshProUGUI NameStatus;
        [SerializeField] private AudioManager _audioManager;

        private void Start()
        {
            controller.Init(this);
            FillUpgrade.maxValue = controller._modelPlayer.TotalMoneyForUp[controller._modelPlayer.TotalMoneyForUp.Length - 1];
            FillUpgrade.value = controller._modelPlayer.TotalMoneyForUp[1];
            NameStatus.SetText($"{controller._modelPlayer.NameStatus[1]}");
        }
        private void FixedUpdate()
        {
            controller.OnFixedUpdate();
        }
        public void Up(int value)
        {
            controller._modelPlayer.TotalMoney += value;
            TotalMoney.SetText($"{controller._modelPlayer.TotalMoney}");
            Upgrade();
            FillUpgrade.value = controller._modelPlayer.TotalMoney;
            _audioManager.Sound.PlayOneShot(_audioManager.Pickup);
            if (controller._modelPlayer.TotalMoney < 0)
            {
                GameManager._windowLose.gameObject.SetActive(true);
            }
        }

        public void MultiplieUp(int value)
        {
            controller._modelPlayer.TotalMoney *= value;
            TotalMoney.SetText($"{controller._modelPlayer.TotalMoney}");
            Upgrade();
            FillUpgrade.value = controller._modelPlayer.TotalMoney;
        }
        public void Upgrade()
        {
            for (int i = _skins.Length - 1; i >= 1; i--)
            {
                if (controller._modelPlayer.TotalMoney >= controller._modelPlayer.TotalMoneyForUp[i])
                {
                    GameObject active = _skins.FirstOrDefault<GameObject>(obj => obj.activeSelf);
                    active.SetActive(false);
                    _skins[i].gameObject.SetActive(true);
                    NameStatus.SetText($"{controller._modelPlayer.NameStatus[i]}");
                    if (_skins[i] != active)
                    {
                        _audioManager.Sound.PlayOneShot(_audioManager.Upgrade);
                    }
                    return;
                }
            }
        }
    }
}
