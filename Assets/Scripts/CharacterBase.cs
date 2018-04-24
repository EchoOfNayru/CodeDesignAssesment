using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour {

    public int health, str, dex, mag, res, pie;
    public bool isDead;
    public bool isPlayer;
    public bool isEnemy;

    PlayerManager playerManager;
    CharacterBase currentTarget;

    void Awake()
    {
        playerManager = ServiceLocator.instance.playerManager;
    }

    void Start()
    {
        currentTarget = playerManager.currentEnemy;
    }

    public virtual bool Attack(CharacterBase defender)
    {
        if (currentTarget != null)
        {
            if (currentTarget.isPlayer)
            {
                BasicPlayer currentPlayer = currentTarget.GetComponent<BasicPlayer>();

                return true;
            }
            if (currentTarget.isEnemy)
            {
                BasicEnemy currentEnemy = currentTarget.GetComponent<BasicEnemy>();
                defender.health -= str - defender.dex;

                currentEnemy.updateStats();
                playerManager.UpdateEnemy(currentEnemy.stats);

                if (defender.health <= 0)
                {
                    defender.gameObject.SetActive(false);
                    defender.isDead = true;
                    currentEnemy = null;
                    playerManager.enemyLost();
                }

                Debug.Log(defender.health);
                return true;
            }
            else
            {
                Debug.Log("failed");
                return false;
            }
        }
        else
        {
            Debug.Log("failed");
            return false;
        }
    }

    public virtual void UseItem()
    {
        Debug.Log("Used Item");
        
    }
}
