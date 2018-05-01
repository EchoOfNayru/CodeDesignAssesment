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
    public GameObject posHolder;
    public float speed;

    protected PlayerManager playerManager;

    public bool isAttacking;
    protected float isAttackingTimer;
    protected CharacterBase currentTarget;
    protected Transform startPos;

    void Start()
    {
        playerManager = ServiceLocator.instance.playerManager;
        
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
        GameObject temp = Instantiate(posHolder);
        temp.transform.position = transform.position;

        startPos = temp.transform;
    }

    void Update()
    {
        if (isAttacking)
        {
            ShowAttack();
        }
    }

    public virtual void Attack(CharacterBase defender)
    {
        int damage = myStats.str + myStats.weaponDamage - defender.myStats.dex;
        if (damage < 1)
        {
            damage = 1;
        }
        defender.myStats.health -= damage;

        isAttacking = true;
        isAttackingTimer = 0;

        playerManager.UpdateEnemy(defender.myStats);

        if (defender.myStats.health <= 0)
        {
            defender.gameObject.SetActive(false);
            defender.isDead = true;
            playerManager.enemyLost();
            playerManager.TurnOrder.Remove(defender);
        }

        playerManager.EndTurn();
    }

    public virtual void UseItem()
    {
        Debug.Log("Used Item");
    }

    public virtual void ShowAttack()
    {
        Debug.Log("I DIDNT DO");
    }
}