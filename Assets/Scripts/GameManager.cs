using ButchersGames;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        [field: SerializeField] public Transform _windowWin { get; private set; }
        [field: SerializeField] public Transform _windowLose { get; private set; }
        [field: SerializeField] public Transform _windowTutorial { get; private set; }
        [SerializeField] private TextMeshProUGUI _numberLevel;
        [SerializeField] private Player _player;
        private void Start()
        {
            if(_windowTutorial != null)
                StartCoroutine(Tutorial());
        }
        public void Retry()
        {
            _player.controller._modelPlayer.TotalMoney = 40;
            _windowLose.gameObject.SetActive(false);
            LevelManager.Default.RestartLevel();
        }

        public void NextLevel()
        {
            _windowWin.gameObject.SetActive(false);
            LevelManager.Default.NextLevel();
            _numberLevel.text = $"Уровень: {LevelManager.CurrentLevel.ToString()}";
        }

        private IEnumerator Tutorial()
        {
            _windowTutorial.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            _windowTutorial.gameObject.SetActive(false );
        }
    }
}
