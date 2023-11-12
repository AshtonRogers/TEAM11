using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownScript : MonoBehaviour
{
    //currency
    public int gold = 0;
    public int silver = 0;

    public Level level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseGold(int amount)
    {
        gold += amount;
    }

    public void IncreaseSilver(int amount)
    {
        silver += amount;
    }

    public bool UpKeepAmount(int amount)
    {
        if(silver > amount)
        {
            silver -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool UpKeepSilverAmount(int amount)
    {
        if(gold > amount)
        {
            gold -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            Debug.Log("Objective Damage");

            Enemy iDamage = collision.gameObject.GetComponent<Enemy>();

            if (iDamage != null)
            {
                Debug.Log("idamage not null");
                iDamage.DealDamage();
            }

            //take damage

            Destroy(collision.gameObject);
            
        }
    }
}
