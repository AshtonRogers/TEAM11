using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float projectileSpeed;
    //public GameObject characterSprite;

    private float speedScale = 100.0f;
    private int projectileDamage;
    private GameObject targetEnemy;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetEnemy.transform.position, projectileSpeed * Time.deltaTime * speedScale);
    }

    public void SetTarget(GameObject target)
    {
        targetEnemy = target;
    }

    public void SetDamage(int damage)
    {
        projectileDamage = damage;
    }
}
