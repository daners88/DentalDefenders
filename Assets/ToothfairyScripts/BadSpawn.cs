using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ToothfairyScripts
{
    public class BadSpawn : MonoBehaviour
    {

        public GameObject bacteria;
        public GameObject stain;
        public GameObject food;
        public GameObject cloud;
         //      GameObject obj;
        private float Starttime;

        List<Vector3> betweenTeethVectorOptions;
        List<Vector3> onTeethVectorOptions;
        List<Vector3> onTongueVectorOptions;
        List<Vector3> inAirVectorOptions;
        List<Vector3> activeBaddies;

        Quaternion tongueBaddieRotation = Quaternion.Euler(82, -10, -12);
        Quaternion teethBaddieRotation = Quaternion.Euler(9, 2, -2);

        float alpha = 0;

        public float spawnRate = 12f;



        float nextSpawn = 3f;

        int whatToSpawn;
        System.Random random;

        // Use this for initialization
        void Start()
        {
             Starttime = Time.time;

        }

        public BadSpawn()
        {
            random = new System.Random();

            betweenTeethVectorOptions = new List<Vector3>();
            onTeethVectorOptions = new List<Vector3>();
            onTongueVectorOptions = new List<Vector3>();
            inAirVectorOptions = new List<Vector3>();
            activeBaddies = new List<Vector3>();

            betweenTeethVectorOptions.Add(new Vector3(-2.9f, 2.9f, 2.0f));
            betweenTeethVectorOptions.Add(new Vector3(-1.65f, 2.5f, 2.0f));
            betweenTeethVectorOptions.Add(new Vector3(-0.15f, 2.5f, 2.0f));
            betweenTeethVectorOptions.Add(new Vector3(1.3f, 2.4f, 2.0f));
            betweenTeethVectorOptions.Add(new Vector3(2.5f, 2.75f, 2.0f));
            betweenTeethVectorOptions.Add(new Vector3(2.45f, 0.3f, 2.0f));
            betweenTeethVectorOptions.Add(new Vector3(1.2f, 0.8f, 2.0f));
            betweenTeethVectorOptions.Add(new Vector3(-0.15f, 0.8f, 2.0f));
            betweenTeethVectorOptions.Add(new Vector3(-1.4f, 0.6f, 2.0f));
            betweenTeethVectorOptions.Add(new Vector3(-2.5f, 0.0f, 2.0f));
            betweenTeethVectorOptions.Add(new Vector3(-3.0f, -0.45f, 0.2f));
            betweenTeethVectorOptions.Add(new Vector3(2.75f, -0.25f, 0.45f));

            onTongueVectorOptions.Add(new Vector3(1.75f, -0.2f, 1.25f));
            onTongueVectorOptions.Add(new Vector3(-1.75f, -0.2f, 1.25f));
            onTongueVectorOptions.Add(new Vector3(1.75f, -0.2f, 0.5f));
            onTongueVectorOptions.Add(new Vector3(-1.75f, -0.2f, 0.5f));
            onTongueVectorOptions.Add(new Vector3(0, -0.1f, 1.75f));
            onTongueVectorOptions.Add(new Vector3(-0.75f, -0.15f, 1.75f));
            onTongueVectorOptions.Add(new Vector3(0.75f, -0.15f, 1.75f));

            onTeethVectorOptions.Add(new Vector3(-0.75f, 0.75f, 2.5f));
            onTeethVectorOptions.Add(new Vector3(-2.0f, 0.6f, 2.5f));
            onTeethVectorOptions.Add(new Vector3(-3.0f, 0.2f, 1.9f));
            onTeethVectorOptions.Add(new Vector3(-3.25f, 2.9f, 1.8f));
            onTeethVectorOptions.Add(new Vector3(-2.5f, 2.5f, 2.5f));
            onTeethVectorOptions.Add(new Vector3(-1.0f, 2.5f, 2.5f));
            onTeethVectorOptions.Add(new Vector3(0.5f, 2.5f, 2.5f));
            onTeethVectorOptions.Add(new Vector3(2.5f, 2.5f, 2.5f));
            onTeethVectorOptions.Add(new Vector3(3.0f, 2.5f, 1.8f));
            onTeethVectorOptions.Add(new Vector3(3.0f, 0.5f, 2.0f));
            onTeethVectorOptions.Add(new Vector3(2.0f, 0.5f, 2.5f));
            onTeethVectorOptions.Add(new Vector3(0.5f, 1.0f, 2.5f));
            onTeethVectorOptions.Add(new Vector3(3.0f, 0.0f, 0.1f));
            onTeethVectorOptions.Add(new Vector3(-3.15f, -0.3f, 1.0f));
            onTeethVectorOptions.Add(new Vector3(-3.85f, 3.1f, 1.5f));

            inAirVectorOptions.Add(new Vector3(3.1f, 2.0f, 1.0f));
            inAirVectorOptions.Add(new Vector3(-3.1f, 2.0f, 1.0f));
            inAirVectorOptions.Add(new Vector3(3.1f, 1.0f, 1.0f));
            inAirVectorOptions.Add(new Vector3(-3.1f, 1.0f, 1.0f));
        }

        public void removeActiveBaddie(Vector3 myVec)
        {
            activeBaddies.RemoveAll(i => i.Equals(myVec));
        }


        //private IEnumerator GrowSprite(GameObject baddie, List<Vector3> options, Quaternion myRot, int i)
        //{
        //    // Percentage of the scale we have completed.
        //    var t = 0.0f;

        //    // The scale we're going from and the scale we're going to.
        //    var start = new Vector3(0.0f, 0.0f, 0.0f);
        //    var end = baddie.transform.localScale;

        //    // In other words while our scale is not equal to our "end" vector.
        //    while (t < 1.0f)
        //    {
        //        // Scale the sprite. 2.0 here because i specified the scale to be over 2 seconds.
        //        t += (Time.deltaTime / 2.0f);
        //        baddie.transform.localScale = Vector3.Lerp(start, end, t);

        //        // Wait till the next frame.
        //        yield return null;
        //    }
        //    Instantiate(baddie, options[i], myRot);
        //    // sprite is scaled, invoke an event here.
        //}



        // Update is called once per frame
        void Update()
        {
            if(Time.time > nextSpawn)
            {
                //when we have more assets randomize the spawn
                bool spawnedBaddie = false;
                if(activeBaddies.Count > 14)
                {
                    spawnedBaddie = true;
                }
                while(!spawnedBaddie)
                {
                    whatToSpawn = random.Next(4);
                    int index = 0;
                    switch (whatToSpawn)
                    {
                        //between teeth
                        case 0:
                            index = random.Next(betweenTeethVectorOptions.Count);
                            if(!activeBaddies.Contains(betweenTeethVectorOptions[index]))
                            {
                                activeBaddies.Add(betweenTeethVectorOptions[index]);

                                Instantiate(food, betweenTeethVectorOptions[index], teethBaddieRotation)  ;
                                spawnedBaddie = true;
                            }
                            break;
                            //on teeth
                        case 1:
                            index = random.Next(onTeethVectorOptions.Count);
                            if (!activeBaddies.Contains(onTeethVectorOptions[index]))
                            {
                                activeBaddies.Add(onTeethVectorOptions[index]);
                                int temp = random.Next(4);
                                //75% chance of stain, 25% chance bacteria
                                if(temp > 0)
                                {
                                    Instantiate(stain, onTeethVectorOptions[index], teethBaddieRotation);
                                }
                                else
                                {
                                    Instantiate(bacteria, onTeethVectorOptions[index], teethBaddieRotation);
                                }
                                spawnedBaddie = true;
                            }
                                break;
                            //on tongue
                        case 2:
                            index = random.Next(onTongueVectorOptions.Count);
                            if (!activeBaddies.Contains(onTongueVectorOptions[index]))
                            {
                                activeBaddies.Add(onTongueVectorOptions[index]);

                                Instantiate(bacteria, onTongueVectorOptions[index], tongueBaddieRotation);
                                spawnedBaddie = true;
                            }
                            break;
                            //in air
                        case 3:
                            index = random.Next(inAirVectorOptions.Count);
                            if (!activeBaddies.Contains(inAirVectorOptions[index]))
                            {
                                activeBaddies.Add(inAirVectorOptions[index]);

                                Instantiate(cloud, inAirVectorOptions[index], teethBaddieRotation);
                                spawnedBaddie = true;
                            }
                            break;
                            //on teeth default
                        default:
                            index = random.Next(onTeethVectorOptions.Count);
                            if (!activeBaddies.Contains(onTeethVectorOptions[index]))
                            {
                                activeBaddies.Add(onTeethVectorOptions[index]);
                                int temp = random.Next(4);
                                //75% chance of stain, 25% chance bacteria
                                if (temp > 0)
                                {
                                    Instantiate(stain, onTeethVectorOptions[index], teethBaddieRotation);
                                }
                                else
                                {
                                    Instantiate(bacteria, onTeethVectorOptions[index], teethBaddieRotation);
                                }
                                spawnedBaddie = true;
                            }
                            break;
                    }
                    
                }


                nextSpawn = Time.time + spawnRate;
            }
        }
    }
}
