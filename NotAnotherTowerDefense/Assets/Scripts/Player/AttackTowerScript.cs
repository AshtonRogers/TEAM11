using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTowerScript : MonoBehaviour
{
    public float shootTimerSecondsMax = 4.0f;
    float shootTimerSeconds;

    public GameObject Projectiles;
    public GameObject MainTower;

    private ProjectileScript projectileScript;
    private GameObject targetEnemy = null;

    // Start is called before the first frame update
    void Start()
    {
        shootTimerSeconds = shootTimerSecondsMax;
        projectileScript = Projectiles.GetComponent<ProjectileScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(shootTimerSeconds <= 0)
        {
            SearchForTarget();

            if(targetEnemy != null)
            {
                ShootProjectile();

                shootTimerSeconds = shootTimerSecondsMax;
            }
        }
        else
        {
            shootTimerSeconds -= Time.deltaTime;
        }    
    }

    protected void ShootProjectile()
    {
        //projectileScript.SetDamage();
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
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
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
}
