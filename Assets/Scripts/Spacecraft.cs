using System;
using System.Collections.Generic;
using UnityEngine;

namespace zerog
{
    public class Spacecraft : Entity, IShip
    {
        public float maxSpeed = 10;
        public float accel = 1f;
        public float decel = 0.1f;
        public float brakePower = 1f;
        public float turnSpeed = 1;

        float speed = 0;

        public Vector3 velocity = Vector3.zero;

        Rigidbody bod;

        public virtual void FixedUpdate()
        {
            if (speed != 0)
            {
                pos.Translate(velocity, UnityEngine.Space.World);
                velocity = velocity.normalized * (speed - decel);
            }
        }

        public void Thrust(float power)
        {
            power = Mathf.Clamp(power, -1, 1);
            if (power == 0)
                return;
            speed = velocity.sqrMagnitude;
            if (speed < maxSpeed)
                velocity += pos.forward * accel * power * Time.deltaTime;
        }

        public void Turn(float angle)
        {
            angle = Mathf.Clamp(angle, -1, 1);
            pos.Rotate(pos.up, angle * turnSpeed * Time.deltaTime);
        }

        public void Face(Vector3 target)
        {
            var hereToThere = target - pos.position;
            hereToThere.y = 0;
            float angle = Vector3.Angle(pos.forward, hereToThere);
            Turn(angle);
        }

        public void Stop()
        {
            speed -= brakePower * Time.deltaTime;
        }
    }
}
