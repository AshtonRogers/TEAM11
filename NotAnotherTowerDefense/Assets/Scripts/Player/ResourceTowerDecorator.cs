using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//resource tower decorator
public interface ResourceTowerDecorator
{
    float GetGenerationSpeed { get; }
    int GetAmount { get; }
    int GetResourceCost { get; }
}

//the most basic resource tower
public class ResourceBaseTower : ResourceTowerDecorator
{
    float generationSpeed = 2.0f;
    int amount = 5;
    int resourceCost = 1;


    public float GetGenerationSpeed
    {
        get
        {
            return generationSpeed;
        }
    }
    public int GetAmount
    {
        get
        {
            return amount;
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

//an upgraded resource tower
public abstract class ResourceTowerUpgrade : ResourceTowerDecorator
{
    public ResourceTowerDecorator towerDecorator;

    public void ApplyUpgrade(ResourceTowerDecorator newTowerDecorator)
    {
        towerDecorator = newTowerDecorator;
    }

    public virtual float GetGenerationSpeed
    {
        get
        {
            return towerDecorator.GetGenerationSpeed;
        }
    }

    public virtual int GetAmount
    {
        get
        {
            return towerDecorator.GetAmount;
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

//upgrades the generation speed
public class GenerationUpgrade : ResourceTowerUpgrade
{
    float generationSpeed = 0.9f;

    public override float GetGenerationSpeed
    {
        get
        {
            return towerDecorator.GetGenerationSpeed * generationSpeed;
        }
    }
}

//upgrades the amount
public class AmountUpgrade : ResourceTowerUpgrade
{
    int amount = 2;

    public override int GetAmount
    {
        get
        {
            return towerDecorator.GetAmount * amount;
        }
    }
}

//upgrades the resource cost
public class ResourceResourceCostUpgrade : ResourceTowerUpgrade
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

