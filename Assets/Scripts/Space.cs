using System;
using System.Collections.Generic;
using UnityEngine;

namespace zerog
{
    public class Space : MonoBehaviour
    {
        Transform pos;

        void Start()
        {
            pos = transform;
        }

        public Space parent = null;
        public List<Entity> occupants;

        void OnTriggerEnter(Collider other)
        {
            Entity e = other.GetComponent<Entity>();
            if (e != null)
            {
                
            }
        }


    }
}
