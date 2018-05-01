using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : CharacterBase {

    public override void ShowAttack()
    {
        currentTarget = playerManager.currentEnemy;
        if (currentTarget != null)
        {
            if (isAttackingTimer == 0)
            {
                Transform targetPos = currentTarget.transform;

                transform.position = targetPos.position - (Vector3.right * 3);
            }

            if (isAttackingTimer >= 0.3f && isAttackingTimer <= 0.6f)
            {
                transform.Translate(Vector3.right * speed);
            }
            else if (isAttackingTimer >= 0.6f && isAttackingTimer <= 0.9f)
            {
                transform.Translate(-Vector3.right * speed);
            }

            isAttackingTimer += Time.deltaTime;
            Debug.Log(isAttackingTimer);

            if (isAttackingTimer >= 1)
            {
                transform.position = startPos.position;
                Attack(currentTarget);
                isAttacking = false;
                isAttackingTimer = 0;
            }
        }
        else
        {
            transform.position = startPos.position;
        }
    }
}
