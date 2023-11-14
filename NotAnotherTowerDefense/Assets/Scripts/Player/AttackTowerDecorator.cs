using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attack tower decotator
public interface AttackTowerDecorator
{
    float GetAttackSpeed { get; }
    int GetDamage { get; }
    int GetResourceCost { get; }
}

//the base tower, the lowest teir of tower
public class BaseTower : AttackTowerDecorator
{
    float attackSpeed = 2.0f;
    int damage = 5;
    int resourceCost = 1;


    public float GetAttackSpeed
    {
        get
        {
            return attackSpeed;
        }
    }
    public int GetDamage
    {
        get
        {
            return damage;
        }
    }
    public int GetResourceCost
    {
        get
        {
            return resourceCost;
        }
    }
}

//the tower after upgrades have happened
//changing the decorator to be the upgraded values
public abstract class TowerUpgrade : AttackTowerDecorator
{
    public AttackTowerDecorator towerDecorator;

    public void ApplyUpgrade(AttackTowerDecorator newTowerDecorator)
    {
        towerDecorator = newTowerDecorator;
    }

    public virtual float GetAttackSpeed
    {
        get
        {
            return towerDecorator.GetAttackSpeed;
        }
    }

    public virtual int GetDamage
    {
        get
        {
            return towerDecorator.GetDamage;
        }
    }

    public virtual int GetResourceCost
    {
        get
        {
            return towerDecorator.GetResourceCost;
        }
    }
}

//upgrade the attack speed
public class AttackSpeedUpgrade : TowerUpgrade
{
    float attackSpeed = 0.9f;

    public override float GetAttackSpeed
    {
        get
        {
            return towerDecorator.GetAttackSpeed * attackSpeed;
        }
    }
}

//upgrade the damage
public class DamageUpgrade : TowerUpgrade
{
    int damage = 2;

    public override int GetDamage
    {
        get
        {
            return towerDecorator.GetDamage * damage;
        }
    }
}

//upgrade the resource cost
public class ResourceCostUpgrade : TowerUpgrade
{
    int cost = 2;

    public override int GetResourceCost
    {
        get
        {
            return towerDecorator.GetResourceCost * cost;
        }
    }
}
