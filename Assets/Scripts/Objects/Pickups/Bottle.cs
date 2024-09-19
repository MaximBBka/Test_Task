using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Bottle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player player))
            {
                player.Up(Random.Range(-6, -15));
                Destroy(gameObject);
            }
        }
    }
}
