using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hyno
{
    public class AttackSystem : MonoBehaviour
    {
        [SerializeField,Header("§ðÀ»¸ê®Æ")]
        private DataAttack dataAttack;

        protected bool canAttack = true;

        private void OnDrawGizmos()
        {
            Gizmos.color = dataAttack.attackAreaColor;

            Gizmos.matrix = Matrix4x4.TRS(
                transform.position +
                transform.TransformDirection(dataAttack.attackAreaoffset),
                transform.rotation, transform.localScale
                );


            Gizmos.DrawCube(
                Vector3.zero,
                dataAttack.attackAreaSize);
        }

        public void StartAttack()
        {
            if (!canAttack) return;
            StartCoroutine(AttackFlow());
        }
        private IEnumerator AttackFlow()
        {
            canAttack= false;
            yield return new WaitForSeconds(dataAttack.delayAttack);
            CheckAttackArea();

            yield return new WaitForSeconds(dataAttack.waitAttackEnd);
            canAttack= true;
            StopAttack();
        }

        protected virtual void StopAttack()
        {

        }

        private void CheckAttackArea()
        {
            Collider[] hits = Physics.OverlapBox(
                transform.position +
                transform.TransformDirection(dataAttack.attackAreaoffset),
                dataAttack.attackAreaSize * 0.5f,
                transform.rotation, dataAttack.layerTarget);

            if (hits.Length>0)
            {
                print(hits[0].name);
            }
            
        }

        

    }


}
