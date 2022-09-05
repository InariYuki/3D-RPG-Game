using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsuneYuki
{
    public class AttackSystem : MonoBehaviour
    {
        [SerializeField] DataAttack data;
        bool canAttack = true;
        private void OnDrawGizmos()
        {
            Gizmos.color = data.attColor;
            Gizmos.matrix = Matrix4x4.TRS(transform.position + transform.TransformDirection(data.offset) , transform.rotation , transform.localScale);
            Gizmos.DrawCube(Vector3.zero , data.attArea);
        }
        public void Attack()
        {
            if (!canAttack) return;
            StartCoroutine(AttackFlow());
        }
        IEnumerator AttackFlow()
        {
            canAttack = false;
            yield return new WaitForSeconds(data.attDelay);
            CheckAttackArea();
            yield return new WaitForSeconds(data.attRemainTime);
            canAttack = true;
        }
        void CheckAttackArea()
        {
            Collider[] hits = Physics.OverlapBox(transform.position + transform.TransformDirection(data.offset) , data.attArea/2 , transform.rotation , data.playerLayer);
            if(hits.Length != 0)
            {
                print(hits[0].name);
            }
        }
    }
}
