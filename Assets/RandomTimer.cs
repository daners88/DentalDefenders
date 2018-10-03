using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTimer : MonoBehaviour {
    float timer;
    float flag;
    public float flagValue;
    public GameObject tongue;
    Animator AnimatorVar;
    // Use this for initialization
    void Start () {
        timer = Time.time;
        flag = flagValue*100;
        AnimatorVar = tongue.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        flag -= Random.value;
        if(flag<0)
        {
            flag = flagValue*100;
            playAnim();
        }

        




    }

    void playAnim()
    {

        if (Random.value > 0.5)
            AnimatorVar.Play("Tongue_Anim", -1, 0f);

        else
        {
            AnimatorVar.Play("Tongue_Anim_Up", 0, 0f);
            Debug.Log("UP!!!");
        }
    }
}
