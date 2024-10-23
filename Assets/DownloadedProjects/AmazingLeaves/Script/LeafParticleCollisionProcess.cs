using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmazingLeaves
{

    [ExecuteInEditMode]
    public class LeafParticleCollisionProcess : MonoBehaviour
    {
        public ParticleSystem particle1;

        public ParticleSystem SplashOnWater;
        public ParticleSystem LeafOnGround;
        public ParticleSystem LeafOnWater;

        // public ParticleSystem LeafGroundParticle;

        List<ParticleCollisionEvent> collisionEvents;

        public float CollisionGap = 0;

        // float MaxV;

        // Start is called before the first frame update
        void Start()
        {
            particle1 = GetComponent<ParticleSystem>();
            collisionEvents = new List<ParticleCollisionEvent>();

            /*
            var main = particle1.main;
            ParticleSystemRenderer pr = particle1.GetComponentInChildren<ParticleSystemRenderer>();        
            // MaxV = ( Mathf.Max(pr.mesh.bounds.size.x, pr.mesh.bounds.size.y, pr.mesh.bounds.size.z) * main.startSize.constant ) / 2.05f;
            MaxV = ( pr.mesh.bounds.size.y * main.startSize.constant) / 3f;
            print("MaxV=" + MaxV);
            */
        }

        void OnParticleCollision(GameObject other)
        {

            int numCollisionEvents = 0;
            if (collisionEvents != null)
                numCollisionEvents = particle1.GetCollisionEvents(other, collisionEvents);

            int i = 0;
            while (i < numCollisionEvents)
            {
                if (other.layer == LayerMask.NameToLayer("ground"))
                {
                    LeafOnGround.transform.position = collisionEvents[i].intersection;

                    //LeafOnGround.transform.TransformDirection(collisionEvents[i].normal);
                    Quaternion Q = Quaternion.LookRotation(collisionEvents[i].normal);

                    var main = LeafOnGround.main;
                    main.startRotationX = Q.eulerAngles.x * Mathf.Deg2Rad;
                    main.startRotationY = Q.eulerAngles.y * Mathf.Deg2Rad;
                    main.startRotationZ = Random.Range(-180f, 180f) * Mathf.Deg2Rad;

                    if (CollisionGap != 0)
                    {
                        // Vector3 targetForward = Q * Vector3.forward;
                        // LeafOnGround.transform.position += LeafOnGround.transform.forward * CollisionGap;
                        LeafOnGround.transform.position += Q * Vector3.forward * CollisionGap;

                    }

                    LeafOnGround.Emit(1);

                }
                else if (other.layer == LayerMask.NameToLayer("water"))
                {
                    SplashOnWater.transform.position = collisionEvents[i].intersection;

                    //SplashOnWater.transform.TransformDirection(collisionEvents[i].normal);
                    Quaternion Q = Quaternion.LookRotation(collisionEvents[i].normal);

                    var main = SplashOnWater.main;
                    main.startRotationX = Q.eulerAngles.x * Mathf.Deg2Rad;
                    main.startRotationY = Q.eulerAngles.y * Mathf.Deg2Rad;
                    main.startRotationZ = Random.Range(-180f, 180f) * Mathf.Deg2Rad;

                    if (CollisionGap != 0)
                        SplashOnWater.transform.position += SplashOnWater.transform.forward * CollisionGap;

                    SplashOnWater.Emit(1);

                    ////////////////////////

                    LeafOnWater.transform.position = collisionEvents[i].intersection;

                    //SplashOnWater.transform.TransformDirection(collisionEvents[i].normal);
                    // Q = Quaternion.LookRotation(collisionEvents[i].normal);

                    var main2 = LeafOnWater.main;
                    main2.startRotationX = Q.eulerAngles.x * Mathf.Deg2Rad;
                    main2.startRotationY = Q.eulerAngles.y * Mathf.Deg2Rad;
                    main2.startRotationZ = Random.Range(-180f, 180f) * Mathf.Deg2Rad;

                    if (CollisionGap != 0)
                        LeafOnWater.transform.position += SplashOnWater.transform.forward * CollisionGap;

                    LeafOnWater.Emit(1);


                }
                i++;
            }
        }


    }

}
