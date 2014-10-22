using System;
using System.Collections;
using UnityEngine;

namespace zerog
{
    public class Thruster : MonoBehaviour
    {
        public Transform pos { get; protected set; }

        public Placement placement;
        public Alignment alignment;

        public float power;

        ParticleSystem thruster;
        Light glow;

        float intensity;

        void Start()
        {
            pos = transform;
        }

        void Thrust(float power)
        {

        }
    }
}