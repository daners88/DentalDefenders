using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ToothfairyScripts
{
    public class GameManager : MonoBehaviour
    {

        public enum ToolState
        {
            None,
            Wash,
            Brush,
            Floss
        }

        private bool clickOnChar =false;
        public GameObject washer;
        public GameObject brusher;
        public GameObject flosser;

        public GameObject washEffPrefab;
        public GameObject brushEffPrefab;
        public GameObject flossEffPrefab;

        public AudioSource flossSFX;
        public AudioSource MouthWashSFX;
        public AudioSource BrushSFX;

        public Bounds brushBounds;
        public Bounds washBounds;
        public Bounds flossBounds;

        private ToolState _curToolState;
        private AudioSource _curSFX;
        private void Start()
        {
            _curToolState = ToolState.None;
            _curSFX = null;
            brushBounds = GameObject.FindGameObjectWithTag("brusher").GetComponent<BoxCollider2D>().bounds;
            washBounds = GameObject.FindGameObjectWithTag("brusher").GetComponent<BoxCollider2D>().bounds;
            flossBounds = GameObject.FindGameObjectWithTag("brusher").GetComponent<BoxCollider2D>().bounds;
    }

        public void OnClickedWash()
        {
            clickOnChar = true;
            Debug.Log("OnClickedWash");
            _curToolState = ToolState.Wash;
            _curSFX = MouthWashSFX;
            RefreshToolState();
        }

        public void OnClickedBrush()
        {
            clickOnChar = true;
            Debug.Log("OnClickedBrush");
            _curToolState = ToolState.Brush;
            _curSFX = BrushSFX;
            RefreshToolState();
        }

        public void OnClickedFloss()
        {
            clickOnChar = true;
            Debug.Log("OnClickedFloss");
            _curToolState = ToolState.Floss;
            _curSFX = flossSFX;
            RefreshToolState();
        }

        private void LateUpdate()
        {
            if (_curToolState == ToolState.None)
                return;

            //bit of a hack to keep particle effects from happening when changing tools, now some bad stuff on the low edge of screen will not have particle cleaning effects
            if (Input.GetMouseButtonDown(0) && (Input.mousePosition.y > 68 || Input.mousePosition.x < 157.5 || Input.mousePosition.x > 348.5))
            {
                AddEffect();
            }
        }

        private void AddEffect()
        {
            GameObject effPrefab = null;
            switch (_curToolState)
            {
                case ToolState.Wash:
                    effPrefab = washEffPrefab;
                    break;
                case ToolState.Brush:
                    effPrefab = brushEffPrefab;
                    break;
                case ToolState.Floss:
                    effPrefab = flossEffPrefab;
                    break;
                default:
                    effPrefab = washEffPrefab;
                    break;

            }

            var eff = Instantiate(effPrefab, InputManager.instance.touchedPos, Quaternion.identity);
            _curSFX.Play();
        }

        private void RefreshToolState()
        {
            switch (_curToolState)
            {
                case ToolState.Wash:
                    {
                        if(brusher.GetComponent<Character>().isSelected)
                        {
                            brusher.transform.localScale -= new Vector3(0.00075F, 0.00075F, 0.00075F);
                        }
                        else if(flosser.GetComponent<Character>().isSelected)
                        {
                            flosser.transform.localScale -= new Vector3(0.00075F, 0.00075F, 0.00075F);
                        }
                        
                        if (!washer.GetComponent<Character>().isSelected)
                        {
                            washer.transform.localScale += new Vector3(0.00075F, 0.00075F, 0.00075F);
                            washer.GetComponent<Character>().isSelected = true;
                        }

                        brusher.GetComponent<Character>().isSelected = false;
                        flosser.GetComponent<Character>().isSelected = false;
                    }
                    break;
                case ToolState.Brush:
                    {
                        if (washer.GetComponent<Character>().isSelected)
                        {
                            washer.transform.localScale -= new Vector3(0.00075F, 0.00075F, 0.00075F);
                        }
                        else if (flosser.GetComponent<Character>().isSelected)
                        {
                            flosser.transform.localScale -= new Vector3(0.00075F, 0.00075F, 0.00075F);
                        }
                        if (!brusher.GetComponent<Character>().isSelected)
                        {
                            brusher.transform.localScale += new Vector3(0.00075F, 0.00075F, 0.00075F);
                            brusher.GetComponent<Character>().isSelected = true;
                        }

                        washer.GetComponent<Character>().isSelected = false;
                        flosser.GetComponent<Character>().isSelected = false;
                    }
                    break;
                case ToolState.Floss:
                    {
                        if (washer.GetComponent<Character>().isSelected)
                        {
                            washer.transform.localScale -= new Vector3(0.00075F, 0.00075F, 0.00075F);
                        }
                        else if (brusher.GetComponent<Character>().isSelected)
                        {
                            brusher.transform.localScale -= new Vector3(0.00075F, 0.00075F, 0.00075F);
                        }
                        if (!flosser.GetComponent<Character>().isSelected)
                        {
                            flosser.transform.localScale += new Vector3(0.00075F, 0.00075F, 0.00075F);
                            flosser.GetComponent<Character>().isSelected = true;
                        }

                        washer.GetComponent<Character>().isSelected = false;
                        brusher.GetComponent<Character>().isSelected = false;
                    }
                    break;
                default:
                    {
                        washer.GetComponent<Character>().isSelected = false;
                        brusher.GetComponent<Character>().isSelected = false;
                        flosser.GetComponent<Character>().isSelected = false;
                    }
                    break;
            }
        }
    }
}