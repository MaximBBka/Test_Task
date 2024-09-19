
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Gate : MonoBehaviour
    {
        [SerializeField] private TypeGate gate;
        [SerializeField] private Animator _animator;
        [SerializeField] private AudioManager _audioManager;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player player))
            {
                _audioManager.Sound.PlayOneShot(_audioManager.Gate);
                _animator.SetTrigger("IsOpen");
                if (gate == TypeGate.Poor)
                {
                    player.MultiplieUp(2);
                }
                else if (gate == TypeGate.Rich)
                {
                    player.MultiplieUp(3);
                }
                else if (gate == TypeGate.SuperRich)
                {
                    player.MultiplieUp(4);
                }
            }
        }
    }
    public enum TypeGate
    {
        None,
        Poor,
        Rich,
        SuperRich
    }
}

