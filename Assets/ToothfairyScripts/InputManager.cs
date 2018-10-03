using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ToothfairyScripts
{
    public class InputManager : MonoBehaviour
    {

        public static InputManager instance;
        public Vector3 touchedPos;
        private void Awake()
        {
            if (instance == null || instance != this)
            {
                instance = this;
            }
        }


        [SerializeField]
        float f_scaleThreshold = 2f;
        [SerializeField]
        Transform effect;
        // Use this for initialization
        void Start()
        {


        }

        // Update is called once per frame
        void Update()
        {

            List<Touch> touches = InputHelper.GetTouches();
            if (touches.Count > 0)
            {
                foreach (Touch touch in touches)
                {
                    touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 1));
                }
            }


        }
    }
}