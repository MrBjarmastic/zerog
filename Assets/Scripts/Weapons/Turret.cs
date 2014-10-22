using System;
using System.Collections.Generic;
using UnityEngine;

namespace zerog
{
    public enum FiringMode
    {
        Single, Sequential, Random
    }
    public class Turret : Entity
    {
        public float arch = 0f;
        public float turnSpeed = 1f;

        public Vector3 axis = Vector3.up;

        public GameObject bulletPrefab;

        public Barrel[] barrels;

        public Transform turret;
        float baseRotation
        {
            get
            {
                return Vector3.Dot(pos.rotation.eulerAngles, pos.up);
            }
        }

        protected override void Start()
        {
            base.Start();
        }

        public bool debug = false;
        void Update()
        {
            Vector3 sp = Camera.main.WorldToScreenPoint(pos.position);
            Vector3 hereToThere = Input.mousePosition - sp;

            hereToThere.Set(hereToThere.x, 0, hereToThere.y);

            Quaternion dir = Quaternion.LookRotation(hereToThere, pos.up);

            float angle = Quaternion.Angle(pos.rotation, dir);
            if (angle <= arch / 2f)
            {
                turret.rotation = Quaternion.RotateTowards(turret.rotation, dir, turnSpeed);
            }
            else
            {
                float maxAngle = baseRotation + arch / 2f;
                float posAngle = Quaternion.Angle(dir, Quaternion.AngleAxis(baseRotation + (angle / 2f), pos.up));
                float negAngle = Quaternion.Angle(dir, Quaternion.AngleAxis(baseRotation - (angle / 2f), pos.up));
                //Debug.Log("NegAngle: "+negAngle+"\tPosAngle: "+posAngle);

                if (negAngle < posAngle)
                    maxAngle = baseRotation  -arch / 2f;
                turret.rotation = Quaternion.RotateTowards(turret.rotation, Quaternion.AngleAxis(maxAngle, pos.up), turnSpeed);
            }

        }


    }
}
