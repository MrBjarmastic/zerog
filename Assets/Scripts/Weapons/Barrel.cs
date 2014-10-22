using System;
using System.Collections.Generic;
using UnityEngine;

namespace zerog
{
    public class Barrel:MonoBehaviour
    {
        public Transform back;
        public Transform front;

        public void Fire(Rigidbody projectile, float power)
        {
            projectile.transform.SetParent(back);
            projectile.transform.localPosition = Vector3.zero;
            projectile.transform.localScale.Set(1, 1, 1);

            var hereToThere = front.position - back.position;

            projectile.transform.SetParent(null);
            projectile.velocity = hereToThere.normalized * power;
        }
    }
}
