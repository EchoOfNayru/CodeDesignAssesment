using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : CharacterBase
{

    public override void ShowAttack()
    {
        int target = Random.Range(0, 3);
        if (target == 1)
        {
            currentTarget = playerManager.tank;
        }
        if (target == 2)
        {
            currentTarget = playerManager.magic;
        }
        if (target == 3)
        {
            currentTarget = playerManager.healer;
        }
        if (currentTarget != null)
        {
            if (isAttackingTimer == 0)
            {
                

                Transform targetPos = currentTarget.transform;

                transform.position = targetPos.position + (Vector3.right * 3);
            }

            if (isAttackingTimer >= 0.3f && isAttackingTimer <= 0.6f)
            {
                transform.Translate(Vector3.right * -speed);
            }
            else if (isAttackingTimer >= 0.6f && isAttackingTimer <= 0.9f)
            {
                transform.Translate(-Vector3.right * -speed);
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
