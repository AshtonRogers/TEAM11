using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTowerRangeScript : MonoBehaviour
{
    float shootTimer;

    float maxCostTimer = 1.0f;
    float costTimer;
    bool isActive;

    public GameObject Projectiles;
    public GameObject MainTower;

    private ProjectileScript projectileScript;
    private GameObject targetEnemy = null;

    AttackTowerDecorator towerDecorator = new BaseTower();

    // Start is called before the first frame update
    void Start()
    {
        shootTimer = towerDecorator.GetAttackSpeed;
        costTimer = maxCostTimer;
        projectileScript = Projectiles.GetComponent<ProjectileScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(shootTimer <= 0)
        {
            SearchForTarget();

            if(targetEnemy != null)
            {
                ShootProjectile();

                shootTimer = towerDecorator.GetAttackSpeed;
            }
        }
        else
        {
            shootTimer -= Time.deltaTime;
        }    

        if(costTimer <= 0)
        {
            //pay cost
            costTimer = maxCostTimer;
        }
        else
        {
            costTimer -= Time.deltaTime;
        }
    }

    protected void ShootProjectile()
    {
        projectileScript.SetDamage(towerDecorator.GetDamage);
        projectileScript.SetTarget(targetEnemy);
        Instantiate(projectileScript, transform);
    }


    protected void SearchForTarget()
    {
        targetEnemy = FindClosestTarget();

        if(targetEnemy != null)
        {
            Debug.Log("found Target");
        }
    }

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
            if(currentDistance < distance)
            {
                closestEnemy = enemy;
                distance = currentDistance;
            }
        }

        return closestEnemy;
    }

    protected void UpgradeAttackSpeed()
    {
        Debug.Log("Upgraded Attack Speed");
        AttackSpeedUpgrade attackSpeedUpgrade = new AttackSpeedUpgrade();
        attackSpeedUpgrade.ApplyUpgrade(towerDecorator);
    }

    protected void UpgradeDamage()
    {
        Debug.Log("Upgraded Damage");
        DamageUpgrade damageUpgrade = new DamageUpgrade();
        damageUpgrade.ApplyUpgrade(towerDecorator);
    }

    protected void UpgradeResourceCost()
    {
        Debug.Log("Upgraded ResourceCost");
        ResourceCostUpgrade resourceCostUpgrade = new ResourceCostUpgrade();
        resourceCostUpgrade.ApplyUpgrade(towerDecorator);
    }
}
