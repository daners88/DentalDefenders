using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ToothfairyScripts
{
    public class Character : MonoBehaviour
    {

        public bool isSelected;
        public string type;




        // Use this for initialization
        void Start()
        {

        }

        public Character()
        {
            this.isSelected = false;
        }

        public void Move()
        {

        }

        //public void setActive()
        //{
        //    this.isSelected = true;
        //    if(this.type == "brusher")
        //    {
        //        GameObject.FindGameObjectWithTag("washer").GetComponent<Character>().isSelected = false;
        //        GameObject.FindGameObjectWithTag("flosser").GetComponent<Character>().isSelected = false;
        //    }
        //    else if(this.type == "washer")
        //    {
        //        GameObject.FindGameObjectWithTag("brusher").GetComponent<Character>().isSelected = false;
        //        GameObject.FindGameObjectWithTag("flosser").GetComponent<Character>().isSelected = false;
        //    }
        //    else
        //    {
        //        GameObject.FindGameObjectWithTag("washer").GetComponent<Character>().isSelected = false;
        //        GameObject.FindGameObjectWithTag("brusher").GetComponent<Character>().isSelected = false;
        //    }
        //}

        // Update is called once per frame
        void Update()
        {
            //if (Input.GetMouseButtonDown(0))
            //{
            //    this.setActive();
            //}

        }
    }
}
