using System;
using System.Collections.Generic;
using UnityEngine;

namespace zerog
{
    [RequireComponent(typeof(Orbiter))]
    public class OrbitalBody : Entity
    {
        Orbiter orb;

        protected override void Start()
        {
            base.Start();
            orb = GetComponent<Orbiter>();
            //if (parent != null)
            //{
            //}
        }
        public override void SetParent(Transform other)
        {
            orb.EnterOrbit(other);
            base.SetParent(other);
        }
    }
}
