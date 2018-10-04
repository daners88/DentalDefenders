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


        public GameObject badFace1;
        public GameObject badFace2;
        public GameObject badFace3;
        public GameObject badFace4;
        public GameObject badFace5;
        public GameObject badFace6;
        //      GameObject obj;
        private float Starttime;

        List<Vector3> betweenTeethVectorOptions;
        List<Vector3> onTeethVectorOptions;
        List<Vector3> onTongueVectorOptions;
        List<Vector3> inAirVectorOptions;
        List<Vector3> activeBaddies;
        Vector3 facePosition;
        Vector3 faceScale;

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
            facePosition = new Vector3(-4.5f, 6.75f, -46.75f);
            faceScale = new Vector3(0.4f, 0.4f, 0.4f);

            betweenTeethVectorOptions.Add(new Vector3(-2.9f, 2.9f, 2.0f));//face1 face2
            betweenTeethVectorOptions.Add(new Vector3(-1.65f, 2.5f, 2.0f));//2 3
            betweenTeethVectorOptions.Add(new Vector3(-0.15f, 2.5f, 2.0f)); //3 4
            betweenTeethVectorOptions.Add(new Vector3(1.3f, 2.4f, 2.0f)); //4 5
            betweenTeethVectorOptions.Add(new Vector3(2.5f, 2.75f, 2.0f)); //5 6
            betweenTeethVectorOptions.Add(new Vector3(-3.0f, -0.45f, 0.2f)); //7
            betweenTeethVectorOptions.Add(new Vector3(-2.5f, 0.0f, 2.0f)); //8
            betweenTeethVectorOptions.Add(new Vector3(-1.4f, 0.6f, 2.0f)); // 8 9
            betweenTeethVectorOptions.Add(new Vector3(-0.15f, 0.8f, 2.0f)); //9 10
            betweenTeethVectorOptions.Add(new Vector3(1.2f, 0.8f, 2.0f)); //10 11
            betweenTeethVectorOptions.Add(new Vector3(2.45f, 0.3f, 2.0f)); // 11 12
            betweenTeethVectorOptions.Add(new Vector3(2.75f, -0.25f, 0.45f)); //13

            onTongueVectorOptions.Add(new Vector3(1.75f, -0.2f, 1.25f));
            onTongueVectorOptions.Add(new Vector3(-1.75f, -0.2f, 1.25f));
            onTongueVectorOptions.Add(new Vector3(1.75f, -0.2f, 0.5f));
            onTongueVectorOptions.Add(new Vector3(-1.75f, -0.2f, 0.5f));
            onTongueVectorOptions.Add(new Vector3(0, -0.1f, 1.75f));
            onTongueVectorOptions.Add(new Vector3(-0.75f, -0.15f, 1.75f));
            onTongueVectorOptions.Add(new Vector3(0.75f, -0.15f, 1.75f));

            onTeethVectorOptions.Add(new Vector3(-3.25f, 2.9f, 1.8f));//face1
            onTeethVectorOptions.Add(new Vector3(-2.5f, 2.5f, 2.5f)); //2
            onTeethVectorOptions.Add(new Vector3(-1.0f, 2.5f, 2.5f));//3
            onTeethVectorOptions.Add(new Vector3(0.5f, 2.5f, 2.5f));//4
            onTeethVectorOptions.Add(new Vector3(2.5f, 2.5f, 2.5f));//5
            onTeethVectorOptions.Add(new Vector3(3.0f, 2.5f, 1.8f)); //6
            onTeethVectorOptions.Add(new Vector3(-3.15f, -0.3f, 1.0f)); //7
            onTeethVectorOptions.Add(new Vector3(-3.0f, 0.2f, 1.9f));//none
            onTeethVectorOptions.Add(new Vector3(-2.0f, 0.6f, 2.5f));//8
            onTeethVectorOptions.Add(new Vector3(-0.75f, 0.75f, 2.5f));//9
            onTeethVectorOptions.Add(new Vector3(0.5f, 1.0f, 2.5f));//10
            onTeethVectorOptions.Add(new Vector3(2.0f, 0.5f, 2.5f)); //11
            onTeethVectorOptions.Add(new Vector3(3.0f, 0.5f, 2.0f)); //12

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

        GameObject getRandomBadFace()
        {
            int rand = random.Next(6);

            switch(rand)
            {
                case 0:
                    return badFace1;
                case 1:
                    return badFace2;
                case 2:
                    return badFace3;
                case 3:
                    return badFace4;
                case 4:
                    return badFace5;
                case 5:
                    return badFace6;
                default:
                    return badFace1;
            }
        }

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

                                Instantiate(food, betweenTeethVectorOptions[index], teethBaddieRotation);
                                spawnedBaddie = true;
                                switch (index)
                                {
                                    case 0:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face1").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face2").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject a = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        a.transform.SetParent(GameObject.FindGameObjectWithTag("face1").transform, false);
                                        GameObject b = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        b.transform.SetParent(GameObject.FindGameObjectWithTag("face2").transform, false);
                                        break;
                                    case 1:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face3").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face2").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject c = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        c.transform.SetParent(GameObject.FindGameObjectWithTag("face3").transform, false);
                                        GameObject d = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        d.transform.SetParent(GameObject.FindGameObjectWithTag("face2").transform, false);
                                        break;
                                    case 2:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face3").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face4").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject e = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        e.transform.SetParent(GameObject.FindGameObjectWithTag("face3").transform, false);
                                        GameObject f = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        f.transform.SetParent(GameObject.FindGameObjectWithTag("face4").transform, false);
                                        break;
                                    case 3:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face4").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face5").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject g = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        g.transform.SetParent(GameObject.FindGameObjectWithTag("face4").transform, false);
                                        GameObject h = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        h.transform.SetParent(GameObject.FindGameObjectWithTag("face5").transform, false);
                                        break;
                                    case 4:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face5").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face6").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject j = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        j.transform.SetParent(GameObject.FindGameObjectWithTag("face5").transform, false);
                                        GameObject k = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        k.transform.SetParent(GameObject.FindGameObjectWithTag("face6").transform, false);
                                        break;
                                    case 5:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face7").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject l = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        l.transform.SetParent(GameObject.FindGameObjectWithTag("face7").transform, false);
                                        break;
                                    case 6:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face8").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject m = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        m.transform.SetParent(GameObject.FindGameObjectWithTag("face8").transform, false);
                                        break;
                                    case 7:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face8").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face9").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject n = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        n.transform.SetParent(GameObject.FindGameObjectWithTag("face8").transform, false);
                                        GameObject o = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        o.transform.SetParent(GameObject.FindGameObjectWithTag("face9").transform, false);
                                        break;
                                    case 8:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face9").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face10").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject p = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        p.transform.SetParent(GameObject.FindGameObjectWithTag("face9").transform, false);
                                        GameObject q = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        q.transform.SetParent(GameObject.FindGameObjectWithTag("face10").transform, false);
                                        break;
                                    case 9:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face10").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face11").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject r = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        r.transform.SetParent(GameObject.FindGameObjectWithTag("face11").transform, false);
                                        GameObject s = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        s.transform.SetParent(GameObject.FindGameObjectWithTag("face10").transform, false);
                                        break;
                                    case 10:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face11").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face12").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject t = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        t.transform.SetParent(GameObject.FindGameObjectWithTag("face11").transform, false);
                                        GameObject u = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        u.transform.SetParent(GameObject.FindGameObjectWithTag("face12").transform, false);
                                        break;
                                    case 11:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face13").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject v = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        v.transform.SetParent(GameObject.FindGameObjectWithTag("face13").transform, false);
                                        break;
                                    default:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face13").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject w = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        w.transform.SetParent(GameObject.FindGameObjectWithTag("face13").transform, false);
                                        break;
                                }
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
                                switch (index)
                                {
                                    case 0:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face1").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject a = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        a.transform.SetParent(GameObject.FindGameObjectWithTag("face1").transform, false);
                                        break;
                                    case 1:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face2").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject b = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        b.transform.SetParent(GameObject.FindGameObjectWithTag("face2").transform, false);
                                        break;
                                    case 2:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face3").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject c = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        c.transform.SetParent(GameObject.FindGameObjectWithTag("face3").transform, false);
                                        break;
                                    case 3:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face4").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject d = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        d.transform.SetParent(GameObject.FindGameObjectWithTag("face4").transform, false);
                                        break;
                                    case 4:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face5").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject e = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        e.transform.SetParent(GameObject.FindGameObjectWithTag("face5").transform, false);
                                        break;
                                    case 5:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face6").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject f = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        f.transform.SetParent(GameObject.FindGameObjectWithTag("face6").transform, false);
                                        break;
                                    case 6:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face7").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject g = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        g.transform.SetParent(GameObject.FindGameObjectWithTag("face7").transform, false);
                                        break;
                                    case 7:
                                        //no need for face
                                        break;
                                    case 8:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face8").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject h = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        h.transform.SetParent(GameObject.FindGameObjectWithTag("face8").transform, false);
                                        break;
                                    case 9:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face9").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject j = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        j.transform.SetParent(GameObject.FindGameObjectWithTag("face9").transform, false);
                                        break;
                                    case 10:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face10").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject k = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        k.transform.SetParent(GameObject.FindGameObjectWithTag("face10").transform, false);
                                        break;
                                    case 11:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face11").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject l = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        l.transform.SetParent(GameObject.FindGameObjectWithTag("face11").transform, false);
                                        break;
                                    case 12:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face12").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject m = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        m.transform.SetParent(GameObject.FindGameObjectWithTag("face12").transform, false);
                                        break;
                                    default:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face12").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject n = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        n.transform.SetParent(GameObject.FindGameObjectWithTag("face12").transform, false);
                                        break;
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
                                switch (index)
                                {
                                    case 0:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face1").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject a = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        a.transform.SetParent(GameObject.FindGameObjectWithTag("face1").transform, false);
                                        break;
                                    case 1:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face2").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject b = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        b.transform.SetParent(GameObject.FindGameObjectWithTag("face2").transform, false);
                                        break;
                                    case 2:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face3").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject c = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        c.transform.SetParent(GameObject.FindGameObjectWithTag("face3").transform, false);
                                        break;
                                    case 3:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face4").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject d = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        d.transform.SetParent(GameObject.FindGameObjectWithTag("face4").transform, false);
                                        break;
                                    case 4:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face5").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject e = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        e.transform.SetParent(GameObject.FindGameObjectWithTag("face5").transform, false);
                                        break;
                                    case 5:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face6").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject f = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        f.transform.SetParent(GameObject.FindGameObjectWithTag("face6").transform, false);
                                        break;
                                    case 6:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face7").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject g = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        g.transform.SetParent(GameObject.FindGameObjectWithTag("face7").transform, false);
                                        break;
                                    case 7:
                                        //no need for face
                                        break;
                                    case 8:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face8").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject h = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        h.transform.SetParent(GameObject.FindGameObjectWithTag("face8").transform, false);
                                        break;
                                    case 9:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face9").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject j = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        j.transform.SetParent(GameObject.FindGameObjectWithTag("face9").transform, false);
                                        break;
                                    case 10:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face10").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject k = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        k.transform.SetParent(GameObject.FindGameObjectWithTag("face10").transform, false);
                                        break;
                                    case 11:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face11").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject l = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        l.transform.SetParent(GameObject.FindGameObjectWithTag("face11").transform, false);
                                        break;
                                    case 12:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face12").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject m = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        m.transform.SetParent(GameObject.FindGameObjectWithTag("face12").transform, false);
                                        break;
                                    default:
                                        foreach (Transform child in GameObject.FindGameObjectWithTag("face12").transform)
                                        {
                                            GameObject.Destroy(child.gameObject);
                                        }
                                        GameObject n = Instantiate(getRandomBadFace(), facePosition, Quaternion.identity) as GameObject;
                                        n.transform.SetParent(GameObject.FindGameObjectWithTag("face12").transform, false);
                                        break;
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
