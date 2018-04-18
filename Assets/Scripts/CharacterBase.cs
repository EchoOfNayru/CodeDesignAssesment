using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour {

    public int health, str, dex, mag, res, pie;

    public void AttackTarget(CharacterBase attacker, CharacterBase defender)
    {
        defender.health -= attacker.str - defender.dex;

        if (defender.health <= 0)
        {
            if (ServiceLocator.instance.enemyManager.enemies.Contains(defender.gameObject))
            {
                ServiceLocator.instance.enemyManager.enemies.Remove(defender.gameObject);
            }
            Destroy(defender.gameObject);
        }
    }
}
