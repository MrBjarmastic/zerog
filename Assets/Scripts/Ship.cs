using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace zerog
{

    public interface IShip
    {
        void Thrust(float power);
        void Turn(float angle);
        void Face(Vector3 target);
        void Stop();
    }
    public enum Placement
    {
        Aft, Front, Center
    }
    public enum Alignment
    {
        Port, Starboard, Backward, Forward
    }

    public class Ship : MonoBehaviour
    {
        public Transform pos { get; set; }
        public Rigidbody bod { get; set; }

        float piv = 0;
        float thr = 0;
        float rot = 0;

        public Thruster[] thrusters;

        public Engine[] engines;

        void Start()
        {
            pos = transform;
            bod = rigidbody;

            thrusters = GetComponentsInChildren<Thruster>();
        }

        void Update()
        {
            thr = Input.GetAxis("Vertical");
            rot = Input.GetAxis("Horizontal");
        }
        /// <summary>
        /// returns the activeThrusters depending on Thrust <see cref="thr"/> and Rotation <see cref="rot"/>
        /// </summary>
        IEnumerable<Thruster> activeThrusters
        {
            get
            {
                foreach (var th in thrusters)
                {
                    if (thr > 0)
                    {
                        if (th.alignment == Alignment.Backward)
                        {
                            yield return th;
                        }
                    }
                    else if (thr < 0)
                    {

                        if (th.alignment == Alignment.Forward)
                            yield return th;
                    }
                }
            }
        }

        IEnumerable<Thruster> activeSteering
        {
            get
            {
                foreach (var th in thrusters)
                {
                    if (rot > 0)
                    {
                        if ((th.placement == Placement.Front && th.alignment == Alignment.Port) || (th.placement == Placement.Aft && th.alignment == Alignment.Starboard))
                            yield return th;
                    }
                    else if (rot < 0)
                    {
                        if ((th.placement == Placement.Front && th.alignment == Alignment.Starboard) || (th.placement == Placement.Aft && th.alignment == Alignment.Port))
                            yield return th;
                    }
                }
            }
        }

        void FixedUpdate()
        {
            if (thr > 0)
            {
                Thrust(thr);
            }
            else if (thr < 0)
            {
                Stop();
            }
            if (rot != 0)
            {
                Turn(rot);
            }
        }

        #region IShip Implementation

        public void Thrust(float power)
        {
            foreach (var e in engines)
            {
                var thrust = Quaternion.AngleAxis(-e.Turn(rot), pos.up) * e.Thrust(thr, -pos.forward);
                bod.AddForce(thrust);
            }
            //Debug.Log ("Thrusting " + f);
        }

        public void Stop()
        {
            foreach (var e in engines)
            {
                bod.AddForce(-bod.velocity.normalized * e.Power * Time.deltaTime);
            }
            //Debug.Log ("Breaking " + f);
        }

        public void Turn(float angle)
        {
            //pos.RotateAround(pos.position,new Vector3(0,0,1),engines.Sum(e=>e.Turn(angle)));
            bod.AddTorque(0, engines.Sum(e => e.Turn(angle)), 0);
        }
        public void Face(Vector3 target)
        {
            Vector3 hereToThere = target - pos.position;
            float angle = Vector3.Angle(pos.up, hereToThere);

            Vector3 newDir = Vector3.RotateTowards(pos.up, hereToThere, (engines.Sum(e => e.TurnSpeed * Mathf.Deg2Rad)) * Time.deltaTime, 0.0f);
            pos.up = newDir;
        }
        #endregion
    }
}