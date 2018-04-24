using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayer : CharacterBase {

    public struct Stats
    {
        public string name;
        public int Health;
        public int Str;
        public int Dex;
        public int Mag;
        public int Res;
        public int Pie;
    }

    public Stats myStats;

    void Start()
    {
        isPlayer = true;
        isEnemy = false;

        myStats.name = gameObject.name;
        myStats.Health = health;
        myStats.Str = str;
        myStats.Dex = dex;
        myStats.Mag = mag;
        myStats.Res = res;
        myStats.Pie = pie;
    }
}
