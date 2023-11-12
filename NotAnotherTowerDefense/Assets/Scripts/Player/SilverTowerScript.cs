using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverTowerScript : MonoBehaviour
{
    float payTimer;

    float maxCostTimer = 1.0f;
    float costTimer;
    bool isActive = true;

    public GameObject MainTower;

    ResourceTowerDecorator towerDecorator = new ResourceBaseTower();

    // Start is called before the first frame update
    void Start()
    {
        payTimer = towerDecorator.GetGenerationSpeed;
        costTimer = maxCostTimer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClaimSiliver()
    {
        if (isActive)
        {
            if (payTimer <= 0)
            {
                //pay town amount
                MainTower.GetComponent<TownScript>().IncreaseSilver(towerDecorator.GetAmount);
                payTimer = towerDecorator.GetGenerationSpeed;
            }
            else
            {
                payTimer -= Time.deltaTime;
            }
        }
    }

    public void PayCost()
    {
        if (costTimer <= 0)
        {
            //pay cost
            if (MainTower.GetComponent<TownScript>().UpKeepSilverAmount(towerDecorator.GetResourceCost))
            {
                costTimer = maxCostTimer;
                isActive = true;
            }
            else
            {
                isActive = false;
                costTimer = maxCostTimer;
            }
        }
        else
        {
            costTimer -= Time.deltaTime;
        }
    }

    protected void UpgradeGenerationSpeed()
    {
        Debug.Log("Upgraded Generation Speed");
        GenerationUpgrade generationUpgrade = new GenerationUpgrade();
        generationUpgrade.ApplyUpgrade(towerDecorator);
    }

    protected void UpgradeAmount()
    {
        Debug.Log("Upgraded Amount");
        AmountUpgrade amountUpgrade = new AmountUpgrade();
        amountUpgrade.ApplyUpgrade(towerDecorator);
    }

    protected void UpgradeResourceCost()
    {
        Debug.Log("Upgraded Resource Cost");
        ResourceResourceCostUpgrade resourceCostUpgrade = new ResourceResourceCostUpgrade();
        resourceCostUpgrade.ApplyUpgrade(towerDecorator);
    }
}
