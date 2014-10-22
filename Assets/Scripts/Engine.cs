using System;
using System.Collections;
using UnityEngine;
using System.Linq;

namespace zerog
{
    public class Engine : MonoBehaviour
    {

        public Transform pos;
        public ParticleSystem[] thrusters;
        public Light[] glow;

        public float intensity = 5;


        private bool firing = false;
        public bool Fire
        {
            get { return firing; }
            set
            {
                if (firing != value)
                {
                    firing = value;
                    foreach (var thr in thrusters)
                    {
                        if (value) thr.Play();
                        else thr.Stop();
                    }
                }
            }
        }

        public float Accel = 1f;
        public float Power = 1f;
        public float TurnSpeed = 0.5f;

        float activeThrust = 0f;

        float deltaV = 0f;

        // Use this for initialization
        void Start()
        {
            pos = transform;
            glow = GetComponentsInChildren<Light>();
            thrusters = GetComponentsInChildren<ParticleSystem>();
            //foreach (var th in thrusters)
            //    th.renderer.sortingLayerName = "particles_bottom";
        }

        // Update is called once per frame
        void LateUpdate()
        {

            if (deltaV > 0)
            {
                Fire = true;
                deltaV = 0;

            }
            else
            {
                Fire = false;
                activeThrust -= Accel * Time.deltaTime;
                if (activeThrust < 0)
                {
                    activeThrust = 0;
                }
            } 

            // Loop engine rumble when engines are running
            //if (audio && firing)
            //    loopStart();
            //else if (audio)
            //    loopFadeOut();
        }

        public Vector3 Thrust(float pw, Vector3 fwd)
        {
            if (pw > 0)
            {
                if (activeThrust < pw * Power)
                    activeThrust += Accel * Time.deltaTime;
            }
            else
            {
                if (activeThrust > pw*Power)
                    activeThrust -= Accel * Time.deltaTime;
            }
                
            deltaV = Power * Mathf.Clamp(pw, -1f, 1f);
            
            if (pw >= 0)
                glow.ToList().ForEach(l => l.intensity = pw * intensity);
            return fwd * activeThrust;
        }

        public float Turn(float pwr)
        {
            return TurnSpeed * Mathf.Clamp(pwr, -2f, 2f);
        }


        //void loopStart()
        //{
        //    // Set volume to 0.5 and play
        //    audio.volume = 0.4f;
        //    if (!audio.isPlaying)
        //        audio.Play();
        //}
        //
        //void loopFadeOut()
        //{
        //    // Fade out with regard to deltaTime and stop when volume is 0
        //    if (!audio.isPlaying)
        //        return;
        //    if (audio.volume == 0)
        //        audio.Stop();
        //    else
        //        audio.volume -= 2 * Time.deltaTime;
        //}
    }
}