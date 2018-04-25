using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour {

    public bool isDead;
    public bool isPlayer;
    public bool isEnemy;

    [System.Serializable]
    public struct Stats
    {
        public string name;
        public int health;
        public int str;
        public int weaponDamage;
        public int dex;
        public int armor;
        public int mag;
        public int res;
        public int pie;
        public int weakness;
    }

    public Stats myStats;

    PlayerManager playerManager;
    CharacterBase currentTarget;

    void Start()
    {
        playerManager = ServiceLocator.instance.playerManager;

        currentTarget = playerManager.currentEnemy;
        if (isEnemy)
        {
            name = gameObject.name;
            myStats.health = Random.Range(15, 35);
            myStats.str = Random.Range(1, 8) + 1;
            myStats.dex = Random.Range(1, 5) + 1;
            myStats.mag = Random.Range(1, 8) + 1;
            myStats.res = Random.Range(1, 5) + 1;
            myStats.pie = Random.Range(1, 8) + 1;
        }
    }

    public virtual void Attack(CharacterBase defender)
    {
        defender.myStats.health -= myStats.str + myStats.weaponDamage - defender.myStats.dex;

        playerManager.UpdateEnemy(defender.myStats);

        if (defender.myStats.health <= 0)
        {
            defender.gameObject.SetActive(false);
            defender.isDead = true;
            playerManager.enemyLost();
        }

        playerManager.EndTurn();
    }

    public virtual void UseItem()
    {
        Debug.Log("Used Item");
    }
}