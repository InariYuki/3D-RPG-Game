using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace KitsuneYuki
{
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField] DataEnemy dataEnemy;
        [SerializeField] EnemyState enemyState;
        Animator anim;
        NavMeshAgent navAgent;
        AttackSystem attSys;
        Vector3 targetPosition;
        Vector3 origin;
        float timerIdle;
        float timerAttack = 0;
        private void Awake()
        {
            anim = GetComponent<Animator>();
            navAgent = GetComponent<NavMeshAgent>();
            attSys = GetComponent<EnemyAttack>();
            navAgent.speed = dataEnemy.moveSpeed;
            origin = transform.position;
        }
        private void FixedUpdate()
        {
            StateSwitcher();
            CheckTargetInRange();
        }
        private void OnDisable()
        {
            navAgent.isStopped = true;
        }
        void StateSwitcher()
        {
            switch (enemyState)
            {
                case EnemyState.Idle:
                    Idle();
                    break;
                case EnemyState.Wander:
                    Wander();
                    break;
                case EnemyState.Track:
                    Track();
                    break;
                case EnemyState.Attack:
                    Attack();
                    break;
            }
        }
        void Wander()
        {
            if (navAgent.remainingDistance == 0)
            {
                targetPosition = origin + Random.insideUnitSphere * dataEnemy.detectRange;
                targetPosition.y = transform.position.y;
            }
            navAgent.SetDestination(targetPosition);
            anim.SetBool("boolMove" , navAgent.velocity.magnitude > 0.1f);
        }
        void Idle()
        {
            anim.SetBool("boolMove" , false);
            timerIdle += Time.fixedDeltaTime;
            float random = Random.Range(dataEnemy.waitTimeRange.x , dataEnemy.waitTimeRange.y);
            if(timerIdle > random)
            {
                timerIdle = 0;
                enemyState = EnemyState.Wander;
            }
        }
        void Track()
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("PunchLeft"))
            {
                navAgent.velocity = Vector3.zero;
            }
            navAgent.SetDestination(targetPosition);
            anim.SetBool("boolMove", true);
            anim.ResetTrigger("triggerAttack");
            if((transform.position - targetPosition).magnitude <= dataEnemy.attackRange)
            {
                enemyState = EnemyState.Attack;
            }
        }
        void Attack()
        {
            navAgent.velocity = Vector3.zero;
            anim.SetBool("boolMove", false);
            timerAttack += Time.fixedDeltaTime;
            if(timerAttack >= dataEnemy.attackInterval)
            {
                timerAttack = 0;
                anim.SetTrigger("triggerAttack");
                attSys.Attack();
                enemyState = EnemyState.Track;
            }
        }
        void CheckTargetInRange()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position , dataEnemy.detectRange , dataEnemy.detectLayer);
            if(hits.Length != 0)
            {
                if (enemyState == EnemyState.Attack) return;
                targetPosition = hits[0].transform.position;
                enemyState = EnemyState.Track;
            }
            else
            {
                enemyState = EnemyState.Wander;
            }
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Vector4(0, 2, 0.2f, 0.3f);
            Gizmos.DrawSphere(transform.position, dataEnemy.detectRange);
            Gizmos.color = new Vector4(1, 0, 0, 0.3f);
            Gizmos.DrawSphere(transform.position, dataEnemy.attackRange);
            Gizmos.color = new Vector4(1, 0, 0, 1);
            Gizmos.DrawSphere(targetPosition, 1f);
        }
    }
}
