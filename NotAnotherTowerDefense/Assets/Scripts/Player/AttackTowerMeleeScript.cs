using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackTowerMeleeScript : MonoBehaviour
{
    public SpriteRenderer spriteRender;
    public Sprite level5Sprite;
    public Sprite level10Sprite;
    private int upgradeCost = 4;
    private int upgradeLevel = 1;


    private float shootTimer;

    private float maxCostTimer = 1.0f;
    private float costTimer;

    public bool isActive;
    public GameObject MainTower;
    public CircleCollider2D rangeCollider;
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
                    Debug.Log("about to hit enemy");
                    HitEnemy();

                    shootTimer = towerDecorator.GetAttackSpeed;
                }
            }
            else
            {
                shootTimer -= Time.deltaTime;
            }
        }
    }

    //pay the upkeep cost of the tower
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

    //attack the enemy
    protected void HitEnemy()
    {
        Enemy iDamage = targetEnemy.GetComponent<Enemy>();

        if(iDamage != null)
        {
            Debug.Log("idamage not null");
            iDamage.UpdateHealth(towerDecorator.GetDamage);
        }
    }

    //search for a target in the world
    protected void SearchForTarget()
    {
        targetEnemy = FindClosestTarget();

        if (targetEnemy != null)
        {
            Debug.Log("found Target");
        }
        else
        {
           // Debug.Log("no found Target");
        }
    }

    //find the closest target that is in the towers range
    protected GameObject FindClosestTarget()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemies");

        Debug.Log(enemies.Length);

        GameObject closestEnemy = null;
        Vector3 startPosition = MainTower.transform.position;

        float distance = 1000.0f;

        foreach (GameObject enemy in enemies)
        {
            if (rangeCollider.bounds.Intersects(enemy.GetComponent<BoxCollider2D>().bounds))
            {
                Debug.Log("in collider");

                Vector3 vecDistance = enemy.transform.position - startPosition;
                float currentDistance = vecDistance.magnitude;
                if (currentDistance < distance)
                {
                    closestEnemy = enemy;
                    distance = currentDistance;
                }
            }
        }

        return closestEnemy;
    }

    //set the activity of the tower
    public void SetActive(bool active)
    {
        isActive = active;
    }

    //change the activity of the tower
    public void ChangeActive()
    {
        SetActive(!isActive);
    }

    //get the towers level
    public int GetTowerLevel()
    {
        return upgradeLevel;
    }

    //function for the attack speed upgrade button
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
    
    //function for the damage upgrade button
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

    //upgrade the attack speed
    protected void UpgradeAttackSpeed()
    {
        Debug.Log("Upgraded Attack Speed");
        AttackSpeedUpgrade attackSpeedUpgrade = new AttackSpeedUpgrade();
        attackSpeedUpgrade.ApplyUpgrade(towerDecorator);
    }

    //upgrade the damage
    protected void UpgradeDamage()
    {
        Debug.Log("Upgraded Damage");
        DamageUpgrade damageUpgrade = new DamageUpgrade();
        damageUpgrade.ApplyUpgrade(towerDecorator);
    }

    //upgrade the cost
    protected void UpgradeResourceCost()
    {
        Debug.Log("Upgraded ResourceCost");
        ResourceCostUpgrade resourceCostUpgrade = new ResourceCostUpgrade();
        resourceCostUpgrade.ApplyUpgrade(towerDecorator);
    }
}
