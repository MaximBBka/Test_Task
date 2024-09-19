using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class AudioManager : MonoBehaviour
    {
        [field:SerializeField] public AudioSource Sound { get; private set;}

        public AudioClip Pickup;
        public AudioClip Gate;
        public AudioClip Upgrade;
    }
}
