using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float projectileSpeed;
    public BoxCollider2D collider;

    private float speedScale = 1.5f;
    private int projectileDamage;
    private GameObject targetEnemy;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy.gameObject == null)
        {
            Debug.Log("DESTORYED BULLET");
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, targetEnemy.transform.position, projectileSpeed * Time.deltaTime * speedScale);

            if (collider.bounds.Intersects(targetEnemy.GetComponent<BoxCollider2D>().bounds))
            {
                Enemy iDamage = targetEnemy.GetComponent<Enemy>();

                //Debug.Log("is hit enemy");

                if (iDamage != null)
                {
                    //Debug.Log("idamage not null");
                    iDamage.Health = iDamage.UpdateHealth(projectileDamage);
                    //Debug.Log(iDamage.Health);
                }

                Destroy(gameObject);
            }
        }
    }

    //sets the target for this particular projectile
    public void SetTarget(GameObject target)
    {
        targetEnemy = target;
    }

    //sets the damage for this particular projectile
    public void SetDamage(int damage)
    {
        projectileDamage = damage;
    }
}
