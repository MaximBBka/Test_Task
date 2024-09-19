
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Gate : MonoBehaviour
    {
        [SerializeField] private TypeGate gate;
        [SerializeField] private Animator _animator;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player player))
            {
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
        Poor,
        Rich,
        SuperRich
    }
}

