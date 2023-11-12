using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface AttackTowerDecorator
{
    float GetAttackSpeed { get; }
    int GetDamage { get; }
    int GetResourceCost { get; }
}

public class BaseTower : AttackTowerDecorator
{
    float attackSpeed = 4.0f;
    int damage = 1;
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
