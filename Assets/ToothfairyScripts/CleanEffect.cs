using System.Collections;
using UnityEngine;

namespace Assets.ToothfairyScripts
{
    public class CleanEffect : MonoBehaviour
    {
        public float duration = 2f;

        void Start()
        {
            StartCoroutine(WaitForDestroy());
        }

        IEnumerator WaitForDestroy()
        {
            yield return new WaitForSeconds(duration);

            Destroy(gameObject);
        }
    }
}