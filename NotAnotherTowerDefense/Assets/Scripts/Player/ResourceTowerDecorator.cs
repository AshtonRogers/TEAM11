using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ResourceTowerDecorator
{
    float GetGenerationSpeed { get; }
    int GetAmount { get; }
    int GetResourceCost { get; }
}

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

