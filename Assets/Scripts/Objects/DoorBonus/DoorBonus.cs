using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class DoorBonus : MonoBehaviour
    {
        [SerializeField] private DoorType type;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player player))
            {
                if (type == DoorType.Positive)
                {
                    player.Up(20);
                    return;
                }
                player.Up(-20);
            }
        }
    }
    public enum DoorType
    {
        Negative,
        Positive
    }
}
