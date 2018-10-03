using UnityEngine;
using UnityEngine.Events;

namespace Assets.ToothfairyScripts
{
    public class ClickEvent : MonoBehaviour
    {
        public UnityEvent onClicked;


        void OnMouseUp()
        {
            if (onClicked != null)
                onClicked.Invoke();
        }
    }
}