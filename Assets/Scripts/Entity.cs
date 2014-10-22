using System;
using System.Collections.Generic;
using UnityEngine;

namespace zerog
{
    public class Entity : MonoBehaviour
    {
        public Guid ID { get; protected set; }
        public string lore;
        public string Lore 
        {
            get { return lore; }
            set { lore = value; }
        }

        public Transform pos { get; protected set; }


        protected virtual void Start()
        {
            pos = transform;
        }

        public virtual void SetParent(Transform other)
        {
            pos.parent = other;
            pos.localScale.Set(1, 1, 1);
        }
    }
}
