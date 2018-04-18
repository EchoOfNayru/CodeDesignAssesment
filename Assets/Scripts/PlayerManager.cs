using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public GameObject tank;
    public GameObject magic;
    public GameObject healer;

    void Start()
    {
        ServiceLocator.instance.playerManager = this;
    }

    public void TankAttackEnemy1()
    {
        tank.GetComponent<BasicPlayer>().AttackTarget(tank.GetComponent<BasicPlayer>(), ServiceLocator.instance.enemyManager.enemies[0].GetComponent<BasicEnemy>());
    }
}
