using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoldTowerScript : MonoBehaviour
{
    public SpriteRenderer spriteRender;
    public Sprite level5Sprite;
    public Sprite level10Sprite;
    private int upgradeCost = 4;
    private int upgradeLevel = 1;

    private float payTimer;

    private float maxCostTimer = 1.0f;
    private float costTimer;

    public bool isActive = true;
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

    public void ClaimGold()
    {
        if (isActive)
        {
            if (payTimer <= 0)
            {
                //pay town amount
                MainTower.GetComponent<TownScript>().IncreaseGold(towerDecorator.GetAmount);
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
        if(isActive)
        {
            if (costTimer <= 0)
            {
                //pay cost
                if (MainTower.GetComponent<TownScript>().UpKeepAmount(towerDecorator.GetResourceCost))
                {
                    costTimer = maxCostTimer;
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
        
    }

    public void SetActive(bool active)
    {
        isActive = active;
    }

    public void ChangeActive()
    {
        SetActive(!isActive);
    }

    public int GetTowerLevel()
    {
        return upgradeLevel;
    }

    public void UpgradeGenerationSpeedButton()
    {
        if (MainTower.GetComponent<TownScript>().VerifySilver(upgradeCost))
        {
            MainTower.GetComponent<TownScript>().IncreaseSilver(-upgradeCost);

            UpgradeGenerationSpeed();
            UpgradeResourceCost();
            upgradeLevel++;
            upgradeCost *= upgradeLevel;

            if (upgradeLevel == 5)
            {
                spriteRender.sprite = level5Sprite;
            }
            else if (upgradeLevel == 10)
            {
                spriteRender.sprite = level10Sprite;
            }
        }
        else
        {
            Debug.Log("Not Enough Resources");
        }
    }

    public void UpgradeAmountButton()
    {
        if (MainTower.GetComponent<TownScript>().VerifySilver(upgradeCost))
        {
            MainTower.GetComponent<TownScript>().IncreaseSilver(-upgradeCost);

            UpgradeAmount();
            UpgradeResourceCost();
            upgradeLevel++;
            upgradeCost *= upgradeLevel;

            if (upgradeLevel == 5)
            {
                spriteRender.sprite = level5Sprite;
            }
            else if (upgradeLevel == 10)
            {
                spriteRender.sprite = level10Sprite;
            }
        }
        else
        {
            Debug.Log("Not Enough Resources");
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
