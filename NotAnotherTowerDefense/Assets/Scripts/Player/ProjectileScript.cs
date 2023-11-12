using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float projectileSpeed;
    public BoxCollider2D collider;
    //public GameObject characterSprite;

    private float speedScale = 0.5f;
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

        if(collider.bounds.Intersects(targetEnemy.GetComponent<BoxCollider2D>().bounds))
        {
            Enemy iDamage = targetEnemy.GetComponent<Enemy>();

            //Debug.Log("is hit enemy");

            if (iDamage != null)
            {
                //Debug.Log("idamage not null");
                iDamage.Health = iDamage.UpdateHealth();
                //Debug.Log(iDamage.Health);
            }

            Destroy(gameObject);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Enemy iDamage = targetEnemy.GetComponent<Enemy>();

    //    Debug.Log("is hit enemy");

    //    if (iDamage != null)
    //    {
    //        Debug.Log("idamage not null");
    //        iDamage.UpdateHealth();
    //    }

    //    Destroy(this);
    //}

    public void SetTarget(GameObject target)
    {
        targetEnemy = target;
    }

    public void SetDamage(int damage)
    {
        projectileDamage = damage;
    }
}
