using UnityEngine;
using System.Collections;
using System;

public class Mob2 : Mob
{
    public override void SetStat(int health, int damage)
    {
        this.fullHealth = health;
        this.Health = health;
        this.Damage = damage;
    }
}
