using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Orbiter:MonoBehaviour
    {
        public Transform orbitee;
        Transform orbiter;
        public float vel;
        public bool inOrbit;

        void Start()
        {
            orbiter = transform;
            orbitee = orbiter.parent;
        }

        void Update()
        {
            if (inOrbit)
            {
                orbitee.Rotate(orbitee.up,  vel * Time.deltaTime);
            }
        }

        public void EnterOrbit(Transform t)
        {
            orbiter.parent = null;
            orbitee.parent = t;
            orbitee.localPosition = Vector3.zero;
            orbitee.parent = null;
            orbiter.parent = orbitee;
            inOrbit = true;
        }
    }
}
