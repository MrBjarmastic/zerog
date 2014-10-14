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

        void Start()
        {
            pos = transform;
        }

        public Vector3 Thrust(Vector3 direction, float power = 0f)
        {
            return direction.normalized * power * this.power;
        }

        public Vector3 Thrust(float power = 0f)
        {
            return pos.forward * power * this.power;
        }
    }
}