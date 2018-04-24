using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : CharacterBase {

    public struct StatsToShow
    {
        public int health;
        public int str;
        public int dex;
        public int res;
        public string weakness;
    }

    public StatsToShow stats;
    public int Level;

    void Start()
    {
        isPlayer = false;
        isEnemy = true;

        health = Random.Range(15, 35);
        str = Random.Range(1, 8) + 1;
        dex = Random.Range(1, 5) + 1;
        mag = Random.Range(1, 8) + 1;
        res = Random.Range(1, 5) + 1;
        pie = Random.Range(1, 8) + 1;

        stats.health = health;
        stats.str = str;
        stats.dex = dex;
        stats.res = res;
        stats.weakness = "none";
    }

    public void updateStats()
    {
        stats.health = health;
        stats.str = str;
        stats.dex = dex;
        stats.res = res;
        stats.weakness = "none";
    }
}
