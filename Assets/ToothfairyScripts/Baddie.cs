using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ToothfairyScripts
{
    public class Baddie : MonoBehaviour
    {
        public string type;

        public void Kill()
        {
            if ((this.type == "bacteria" || this.type == "stain") && GameObject.FindGameObjectWithTag("brusher").GetComponent<Character>().isSelected)
            {
                GameObject.FindGameObjectWithTag("mouth").GetComponent<BadSpawn>().removeActiveBaddie(new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z));
                Destroy(this.gameObject, 0);
            }
            else if (this.type == "food" && GameObject.FindGameObjectWithTag("flosser").GetComponent<Character>().isSelected)
            {
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
