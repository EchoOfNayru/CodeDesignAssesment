using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour {

    public int health, str, dex, mag, res, pie;
    public int weaponDamage, armor;
    public int weakness;
    public bool isDead;
    public bool isPlayer;
    public bool isEnemy;
    

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

    void Awake()
    {
        
    }

    void Start()
    {
        playerManager = ServiceLocator.instance.playerManager;

        currentTarget = playerManager.currentEnemy;

        if (isPlayer)
        {
            updateStats();
        }
        if (isEnemy)
        {
            name = gameObject.name;
            health = Random.Range(15, 35);
            str = Random.Range(1, 8) + 1;
            dex = Random.Range(1, 5) + 1;
            mag = Random.Range(1, 8) + 1;
            res = Random.Range(1, 5) + 1;
            pie = Random.Range(1, 8) + 1;

            updateStats();
        }
    }

    public virtual bool Attack(CharacterBase defender)
    {
        currentTarget = playerManager.currentEnemy;
        if (currentTarget != null)
        {
            CharacterBase currentDefender = currentTarget.GetComponent<CharacterBase>();

            defender.health -= str + weaponDamage - defender.dex;

            currentDefender.updateStats();
            playerManager.UpdateEnemy(currentDefender.myStats);

            if (defender.health <= 0)
            {
                defender.gameObject.SetActive(false);
                defender.isDead = true;
                currentDefender = null;
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

    public virtual void UseItem()
    {
        Debug.Log("Used Item");
        
    }

    public void updateStats()
    {
        myStats.name = name;
        myStats.health = health;
        myStats.str = str;
        myStats.weaponDamage = weaponDamage;
        myStats.dex = dex;
        myStats.armor = armor;
        myStats.mag = mag;
        myStats.res = res;
        myStats.pie = pie;
        myStats.weakness = weakness;
    }
}