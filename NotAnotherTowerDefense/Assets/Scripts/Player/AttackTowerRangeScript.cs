using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackTowerRangeScript : MonoBehaviour
{
    public SpriteRenderer spriteRender;
    public Sprite level5Sprite;
    public Sprite level10Sprite;
    private int upgradeCost = 4;
    private int upgradeLevel = 1;


    private float shootTimer;

    private float maxCostTimer = 1.0f;
    private float costTimer;

    public bool isActive = true;
    public GameObject Projectiles;
    public GameObject MainTower;
    private GameObject targetEnemy = null;

    AttackTowerDecorator towerDecorator = new BaseTower();

    [SerializeField] private GameObject playerController;

    // Start is called before the first frame update
    void Start()
    {
        shootTimer = towerDecorator.GetAttackSpeed;
        costTimer = maxCostTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (shootTimer <= 0)
            {
                SearchForTarget();

                if (targetEnemy != null)
                {
                    ShootProjectile();

                    shootTimer = towerDecorator.GetAttackSpeed;
                }
            }
            else
            {
                shootTimer -= Time.deltaTime;
            }
        }
    }

    //loops the timer to pay the upkeep cost
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

    //shoot a projectile at the targeted enemy
    protected void ShootProjectile()
    {
        GameObject projectile =  Instantiate(Projectiles, transform);

        projectile.GetComponent<ProjectileScript>().SetTarget(targetEnemy);
        projectile.GetComponent<ProjectileScript>().SetDamage(towerDecorator.GetDamage);
    }

    //search for a target in the world
    protected void SearchForTarget()
    {
        targetEnemy = FindClosestTarget();

        if(targetEnemy != null)
        {
            Debug.Log("found Target");
        }
    }

    //find the closest target in the world
    protected GameObject FindClosestTarget()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemies");
        GameObject closestEnemy = null;
        Vector3 startPosition = MainTower.transform.position;

        float distance = 1000.0f;

        foreach (GameObject enemy in enemies)
        {
            Vector3 vecDistance = enemy.transform.position - startPosition;
            float currentDistance = vecDistance.magnitude;
            if (currentDistance < distance)
            {
                closestEnemy = enemy;
                distance = currentDistance;
            }
        }

        return closestEnemy;
    }

    //set the tower as active
    public void SetActive(bool active)
    {
        isActive = active;
    }

    //change the towers active state
    public void ChangeActive()
    {
        SetActive(!isActive);
    }

    //get the level of the tower
    public int GetTowerLevel()
    {
        return upgradeLevel;
    }

    //the button function to upgrade the speed
    public void UpgradeAttackSpeedButton()
    {
        if (MainTower.GetComponent<TownScript>().VerifyGold(upgradeCost))
        {
            MainTower.GetComponent<TownScript>().IncreaseGold(-upgradeCost);

            UpgradeAttackSpeed();
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
            playerController.GetComponent<PlayerController>().NotEnoughResourcesText();
        }
    }

    //the buttons function to upgrade the damage
    public void UpgradeDamageButton()
    {
        if (MainTower.GetComponent<TownScript>().VerifyGold(upgradeCost))
        {
            MainTower.GetComponent<TownScript>().IncreaseGold(-upgradeCost);

            UpgradeDamage();
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
           playerController.GetComponent<PlayerController>().NotEnoughResourcesText();
        }
    }

    //upgrades the speed
    protected void UpgradeAttackSpeed()
    {
        Debug.Log("Upgraded Attack Speed");
        AttackSpeedUpgrade attackSpeedUpgrade = new AttackSpeedUpgrade();
        attackSpeedUpgrade.ApplyUpgrade(towerDecorator);
    }

    //upgrades the damage
    protected void UpgradeDamage()
    {
        Debug.Log("Upgraded Damage");
        DamageUpgrade damageUpgrade = new DamageUpgrade();
        damageUpgrade.ApplyUpgrade(towerDecorator);
    }

    //upgrades the cost
    protected void UpgradeResourceCost()
    {
        Debug.Log("Upgraded ResourceCost");
        ResourceCostUpgrade resourceCostUpgrade = new ResourceCostUpgrade();
        resourceCostUpgrade.ApplyUpgrade(towerDecorator);
    }
}
