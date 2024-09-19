using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class PlayerController
    {
        [field: SerializeField] public ModelPlayer _modelPlayer { get; private set; }
        [SerializeField] private Transform[] _points;
        private Player _player;
        private int _currentPointsIndex = 0;
        private Vector2 touchPosition;
        public float minPositionX = -1.5f;
        public float maxPositionX = 1.5f;

        public void Init(Player player)
        {
            _player = player;
        }
        public void OnFixedUpdate()
        {
            if(_currentPointsIndex >= _points.Length) 
                return;

            MoveTowardsTarget();
            //Move();
        }
        private void Move()
        {
            if (Input.touchCount == 1)
            {
                touchPosition = Input.touches[0].position;
            }
            else
            {
                touchPosition = Input.mousePosition;
            }
            Vector2 direction = touchPosition - new Vector2(_player.transform.localPosition.x, _player.transform.localPosition.y);
            float newX = Mathf.Clamp(_player.transform.localPosition.x + direction.x * _modelPlayer.Sensetivity * Time.deltaTime, minPositionX, maxPositionX);
            _player.transform.localPosition = new Vector3(newX, _player.transform.localPosition.y, _player.transform.localPosition.z);
        }
        private void MoveTowardsTarget()
        {
            Vector3 direction = (_points[_currentPointsIndex].localPosition - _player.transform.localPosition).normalized;
            Vector3 movement = direction * _modelPlayer.Speed * Time.deltaTime;

            _player.transform.localPosition += movement;

            if (Vector3.Distance(_player.transform.localPosition, _points[_currentPointsIndex].localPosition) < 0.1f)
            {
                _currentPointsIndex++;
                if (_currentPointsIndex < _points.Length)
                {
                    _player.StartCoroutine(RotateTowardsNextWaypoint());
                }          
            }
        }
        private IEnumerator RotateTowardsNextWaypoint()
        {
            yield return new WaitForSeconds(0.1f);

            Vector3 direction = (_points[_currentPointsIndex].localPosition - _player.transform.localPosition).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            while (Quaternion.Angle(_player.transform.localRotation, targetRotation) > 0.1f)
            {
                _player.transform.localRotation = Quaternion.Slerp(_player.transform.localRotation, targetRotation, Time.deltaTime * _modelPlayer.RotateSpeed);
                yield return null;
            }

            _player.transform.localRotation = targetRotation;
        }

    }

    [Serializable]
    public class ModelPlayer
    {
        public float Speed;
        public float RotateSpeed;
        public float Sensetivity;
        public int TotalMoney;
        public int[] TotalMoneyForUp;
    }
}
