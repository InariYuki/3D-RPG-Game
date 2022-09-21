using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsuneYuki
{
    public delegate void delegateHit(GameObject obj);
    public class RecycleBall : MonoBehaviour
    {
        public delegateHit OnHit;
        private void OnEnable()
        {
            StartCoroutine(DestroyBallWhenTooLong());
        }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.name.Contains("Floor"))
            {
                OnHit(gameObject);
            }
        }
        IEnumerator DestroyBallWhenTooLong()
        {
            yield return new WaitForSeconds(5f);
            OnHit(gameObject);
        }
    }
}
