using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ToothfairyScripts
{
    public class Baddie : MonoBehaviour
    {
        public GameObject contentFace;
        public string type;
        List<Vector3> betweenTeethVectorOptions;
        List<Vector3> onTeethVectorOptions;
        Vector3 facePosition;
        Vector3 faceScale;

        public Baddie()
        {
            betweenTeethVectorOptions = new List<Vector3>();
            onTeethVectorOptions = new List<Vector3>();
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
        }

        void betweenTeethSetFace(int i)
        {
            switch (i)
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
                    GameObject a = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    a.transform.SetParent(GameObject.FindGameObjectWithTag("face1").transform, false);
                    GameObject b = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
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
                    GameObject c = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    c.transform.SetParent(GameObject.FindGameObjectWithTag("face3").transform, false);
                    GameObject d = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
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
                    GameObject e = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    e.transform.SetParent(GameObject.FindGameObjectWithTag("face3").transform, false);
                    GameObject f = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
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
                    GameObject g = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    g.transform.SetParent(GameObject.FindGameObjectWithTag("face4").transform, false);
                    GameObject h = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
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
                    GameObject j = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    j.transform.SetParent(GameObject.FindGameObjectWithTag("face5").transform, false);
                    GameObject k = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    k.transform.SetParent(GameObject.FindGameObjectWithTag("face6").transform, false);
                    break;
                case 5:
                    foreach (Transform child in GameObject.FindGameObjectWithTag("face7").transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    GameObject l = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    l.transform.SetParent(GameObject.FindGameObjectWithTag("face7").transform, false);
                    break;
                case 6:
                    foreach (Transform child in GameObject.FindGameObjectWithTag("face8").transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    GameObject m = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
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
                    GameObject n = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    n.transform.SetParent(GameObject.FindGameObjectWithTag("face8").transform, false);
                    GameObject o = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
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
                    GameObject p = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    p.transform.SetParent(GameObject.FindGameObjectWithTag("face9").transform, false);
                    GameObject q = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
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
                    GameObject r = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    r.transform.SetParent(GameObject.FindGameObjectWithTag("face11").transform, false);
                    GameObject s = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
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
                    GameObject t = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    t.transform.SetParent(GameObject.FindGameObjectWithTag("face11").transform, false);
                    GameObject u = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    u.transform.SetParent(GameObject.FindGameObjectWithTag("face12").transform, false);
                    break;
                case 11:
                    foreach (Transform child in GameObject.FindGameObjectWithTag("face13").transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    GameObject v = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    v.transform.SetParent(GameObject.FindGameObjectWithTag("face13").transform, false);
                    break;
                default:
                    foreach (Transform child in GameObject.FindGameObjectWithTag("face13").transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    GameObject w = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    w.transform.SetParent(GameObject.FindGameObjectWithTag("face13").transform, false);
                    break;
            }
        }

        void onTeethSetFace(int i)
        {
            switch (i)
            {
                case 0:
                    foreach (Transform child in GameObject.FindGameObjectWithTag("face1").transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    GameObject a = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    a.transform.SetParent(GameObject.FindGameObjectWithTag("face1").transform, false);
                    break;
                case 1:
                    foreach (Transform child in GameObject.FindGameObjectWithTag("face2").transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    GameObject b = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    b.transform.SetParent(GameObject.FindGameObjectWithTag("face2").transform, false);
                    break;
                case 2:
                    foreach (Transform child in GameObject.FindGameObjectWithTag("face3").transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    GameObject c = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    c.transform.SetParent(GameObject.FindGameObjectWithTag("face3").transform, false);
                    break;
                case 3:
                    foreach (Transform child in GameObject.FindGameObjectWithTag("face4").transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    GameObject d = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    d.transform.SetParent(GameObject.FindGameObjectWithTag("face4").transform, false);
                    break;
                case 4:
                    foreach (Transform child in GameObject.FindGameObjectWithTag("face5").transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    GameObject e = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    e.transform.SetParent(GameObject.FindGameObjectWithTag("face5").transform, false);
                    break;
                case 5:
                    foreach (Transform child in GameObject.FindGameObjectWithTag("face6").transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    GameObject f = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    f.transform.SetParent(GameObject.FindGameObjectWithTag("face6").transform, false);
                    break;
                case 6:
                    foreach (Transform child in GameObject.FindGameObjectWithTag("face7").transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    GameObject g = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
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
                    GameObject h = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    h.transform.SetParent(GameObject.FindGameObjectWithTag("face8").transform, false);
                    break;
                case 9:
                    foreach (Transform child in GameObject.FindGameObjectWithTag("face9").transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    GameObject j = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    j.transform.SetParent(GameObject.FindGameObjectWithTag("face9").transform, false);
                    break;
                case 10:
                    foreach (Transform child in GameObject.FindGameObjectWithTag("face10").transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    GameObject k = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    k.transform.SetParent(GameObject.FindGameObjectWithTag("face10").transform, false);
                    break;
                case 11:
                    foreach (Transform child in GameObject.FindGameObjectWithTag("face11").transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    GameObject l = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    l.transform.SetParent(GameObject.FindGameObjectWithTag("face11").transform, false);
                    break;
                case 12:
                    foreach (Transform child in GameObject.FindGameObjectWithTag("face12").transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    GameObject m = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    m.transform.SetParent(GameObject.FindGameObjectWithTag("face12").transform, false);
                    break;
                default:
                    foreach (Transform child in GameObject.FindGameObjectWithTag("face12").transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    GameObject n = Instantiate(contentFace, facePosition, Quaternion.identity) as GameObject;
                    n.transform.SetParent(GameObject.FindGameObjectWithTag("face12").transform, false);
                    break;
            }
        }

        public void Kill()
        {
            if ((this.type == "bacteria" || this.type == "stain") && GameObject.FindGameObjectWithTag("brusher").GetComponent<Character>().isSelected)
            {
                for(int i = 0; i < onTeethVectorOptions.Count; i++)
                {
                    if(onTeethVectorOptions[i] == this.gameObject.transform.position)
                    {
                        onTeethSetFace(i);
                        break;
                    }
                }
                GameObject.FindGameObjectWithTag("mouth").GetComponent<BadSpawn>().removeActiveBaddie(new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z));
                Destroy(this.gameObject, 0);
            }
            else if (this.type == "food" && GameObject.FindGameObjectWithTag("flosser").GetComponent<Character>().isSelected)
            {
                for (int i = 0; i < betweenTeethVectorOptions.Count; i++)
                {
                    if (betweenTeethVectorOptions[i] == this.gameObject.transform.position)
                    {
                        betweenTeethSetFace(i);
                        break;
                    }
                }
                GameObject.FindGameObjectWithTag("mouth").GetComponent<BadSpawn>().removeActiveBaddie(new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z));
                Destroy(this.gameObject, 0);
            }
            else if (this.type == "cloud" && GameObject.FindGameObjectWithTag("washer").GetComponent<Character>().isSelected)
            {
                GameObject.FindGameObjectWithTag("mouth").GetComponent<BadSpawn>().removeActiveBaddie(new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z));
                Destroy(this.gameObject, 0);
            }
        }
    }
}
