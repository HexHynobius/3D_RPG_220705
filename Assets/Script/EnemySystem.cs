using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Hyno
{
    public class EnemySystem : MonoBehaviour
    {
        #region ���
        [SerializeField, Header("�ĤH���")]
        private DataEnemy dataEnemy;
        [SerializeField]
        private StateEnemy stateEnemy;

        private Animator ani;
        private NavMeshAgent nma;
        private Vector3 v3TargetPosition;
        private string parWalk = "�}������";
        #endregion
        private float timerIdle;

        private EnemyAttack enemyAttack;

        #region �ƥ�
        private void Awake()
        {
            ani = GetComponent<Animator>();
            enemyAttack=GetComponent<EnemyAttack>();
            nma = GetComponent<NavMeshAgent>();
            nma.speed = dataEnemy.seepWalk;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(0, 1, 0.2f, 0.3f);
            Gizmos.DrawSphere(transform.position, dataEnemy.rangTrack);

            Gizmos.color = new Color(1, 0.2f, 0.2f, 0.3f);
            Gizmos.DrawSphere(transform.position, dataEnemy.rangAttack);

            Gizmos.color = new Color(1, 0.2f, 0.3f, 1);
            Gizmos.DrawSphere(v3TargetPosition, 0.3f);
        }

        private void Update()
        {
            StateSwitcher();
            CheckerTargetInTrackRange();
        }
        #endregion

        private void OnDisable()
        {
            //nma.Stop(); //���L�C �O �L��API
            nma.isStopped = true;
        }

        #region ��k

        private void StateSwitcher()
        {
            switch (stateEnemy)
            {
                case StateEnemy.Idle:
                    Idle();
                    break;
                case StateEnemy.Wander:
                    Wander();
                    break;
                case StateEnemy.Track:
                    Track();
                    break;
                case StateEnemy.Attack:
                    Attack();
                    break;
            }
        }
        private void Wander()
        {
            if (nma.remainingDistance == 0)
            {
                v3TargetPosition = transform.position + Random.insideUnitSphere * dataEnemy.rangTrack;
                v3TargetPosition.y = transform.position.y;
            }
            nma.SetDestination(v3TargetPosition);
            //print(nma.velocity);
            ani.SetBool(parWalk, nma.velocity.magnitude > 01f);
        }
        #endregion


        private void Idle()
        {
            //nma.velocity = Vector3.zero;
            ani.SetBool(parWalk, false);
            timerIdle += Time.deltaTime;
            //print("���ݮɶ�" + timerIdle);

            float r = Random.Range(dataEnemy.timeIdleRange.x, dataEnemy.timeIdleRange.y);

            if (timerIdle >= r)
            {
                timerIdle = 0;
                stateEnemy = StateEnemy.Wander;
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        private void Track()
        {
            if (ani.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                nma.velocity = Vector3.zero;
            }

            nma.SetDestination(v3TargetPosition);
            ani.SetBool(parWalk, true);
            ani.ResetTrigger(parAttack);

            if (Vector3.Distance(transform.position, v3TargetPosition) <= dataEnemy.rangAttack)
            {
                stateEnemy = StateEnemy.Attack;
                //print("�i�J�������A");
            }
            else
            {
                timerAttack = dataEnemy.intervalAttack;
            }
        }
        private float timerAttack;
        private string parAttack = "Ĳ�o����";

        /// <summary>
        /// �������j
        /// </summary>
        private void Attack()
        {
            ani.SetBool(parWalk, false);
            nma.velocity = Vector3.zero;

            if (timerAttack < dataEnemy.intervalAttack)
            {
                timerAttack += Time.deltaTime;
            }
            else
            {
                ani.SetTrigger(parAttack);
                timerAttack = 0;
                enemyAttack.StartAttack();
                stateEnemy = StateEnemy.Track;
            }
        }
        /// <summary>
        /// �P�_���Ľd��
        /// </summary>
        private void CheckerTargetInTrackRange()
        {

            Collider[] hits = Physics.OverlapSphere(transform.position, dataEnemy.rangTrack, dataEnemy.layerTarget);

            if (hits.Length > 0)
            {
                //print("�I��������" + hits[0].name);
                v3TargetPosition = hits[0].transform.position;
                if (stateEnemy == StateEnemy.Attack) return;
                stateEnemy = StateEnemy.Track;
            }
            else
            {
                stateEnemy = StateEnemy.Wander;
            }
        }



    }

}



