using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmazingLeaves
{

    [ExecuteInEditMode]
    public class LeafController : MonoBehaviour
    {
        public enum intensity
        {
            VeryLight,
            Light,
            Moderate,
            Heavy,
            VeryHeavy,
            Stormy,
            VeryStormy,
            Custom
        }

        public ParticleSystem LeafParticle;

        public ParticleSystem.EmissionModule emissionModule;

        public ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule;

        public ParticleSystem.MainModule mainModule;

        public intensity Intensity;
        private intensity OldIntensity;

        public int CustomRateOverTime = 200;

        // Start is called before the first frame update
        void Start()
        {
            // LeafParticle.Stop();
            LeafParticle.Clear();

            emissionModule = LeafParticle.emission;
            velocityOverLifetimeModule = LeafParticle.velocityOverLifetime;
            mainModule = LeafParticle.main;

            OldIntensity = Intensity;

            ChangeIntensity();

            // mainModule.prewarm = true;

            LeafParticle.Simulate(mainModule.duration);
            LeafParticle.Play();

        }



        // Update is called once per frame
        void Update()
        {
            if (Intensity != OldIntensity)
            {
                ChangeIntensity();
                OldIntensity = Intensity;
            }

            if (Intensity == intensity.Custom && CustomRateOverTime != (int)emissionModule.rateOverTime.constant)
            {
                emissionModule.rateOverTime = CustomRateOverTime;
                CustomRateOverTime = (int)emissionModule.rateOverTime.constant;
            }
        }

        void ChangeIntensity()
        {
            switch (Intensity)
            {
                case intensity.VeryLight:
                    emissionModule.rateOverTime = 15;
                    break;

                case intensity.Light:
                    emissionModule.rateOverTime = 30;
                    break;

                case intensity.Moderate:
                    emissionModule.rateOverTime = 40;
                    break;

                case intensity.Heavy:
                    emissionModule.rateOverTime = 50;
                    break;

                case intensity.VeryHeavy:
                    emissionModule.rateOverTime = 70;
                    break;

                case intensity.Stormy:
                    emissionModule.rateOverTime = 85;
                    //velocityOverLifetimeModule.x = -30;
                    //mainModule.startLifetime = 15;
                    break;

                case intensity.VeryStormy:
                    emissionModule.rateOverTime = 100;
                    //velocityOverLifetimeModule.x = -30;
                    //mainModule.startLifetime = 15;
                    break;
            }

        }
    }

}
