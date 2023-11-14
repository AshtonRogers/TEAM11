using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TownScript : MonoBehaviour
{
    //currency
    public int gold = 100;
    public int silver = 0;

    private float silverCollectionTimer = 1.0f;

    [SerializeField] private Text m_GoldText;
    [SerializeField] private Text m_SilverText;

    public Level level;

    public List<SilverTowerScript> silverTowers = new List<SilverTowerScript>();
    public List<GoldTowerScript> goldTowers = new List<GoldTowerScript>();
    public List<AttackTowerMeleeScript> attackTowerMelees = new List<AttackTowerMeleeScript>();
    public List<AttackTowerRangeScript> attackTowerRanges = new List<AttackTowerRangeScript>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Updating UI Text
        m_GoldText.text = gold.ToString();
        m_SilverText.text = silver.ToString();
    }

    //claim the silver that the town produces
    public void ClaimTownSilver()
    {
        if(silverCollectionTimer <= 0.0f)
        {
            int amount = 3 * level.m_CurrentWave;
            IncreaseSilver(amount);
            silverCollectionTimer = 1.0f;
        }
        else
        {
            silverCollectionTimer -= Time.deltaTime;
        }
    }

    //increase the amount of gold
    public void IncreaseGold(int amount)
    {
        gold += amount;
    }

    //increase the amount of silver
    public void IncreaseSilver(int amount)
    {
        silver += amount;
    }

    //pay the silver upkeep amount
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

    //pay the gold upkeep amount, only used by the silver tower
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

    //add a gold tower to the list
    public void AddGoldTower(GoldTowerScript tower)
    {
        goldTowers.Add(tower);
    }

    //add a silver tower to the list
    public void AddSilverTower(SilverTowerScript tower)
    {
        silverTowers.Add(tower);
    }

    //add a melee tower to the list
    public void AddMeleeTower(AttackTowerMeleeScript tower)
    {
        attackTowerMelees.Add(tower);
    }

    //add a range tower to the list
    public void AddRangeTower(AttackTowerRangeScript tower)
    {
        attackTowerRanges.Add(tower);
    }

    //verify the gold is enough for the amount
    public bool VerifyGold(int amount)
    {
        if(gold >= amount)
        {
            return true;
        }

        return false;
    }

    //verify the silver is enough for the amount
    public bool VerifySilver(int amount)
    {
        if(silver >= amount)
        {
            return true;
        }

        return false;
    }

    //when colliding with an enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            Enemy iDamage = collision.gameObject.GetComponent<Enemy>();

            if (iDamage != null)
            {
                int dealDamage;
                Debug.Log("idamage not null");
                dealDamage = iDamage.DealDamage();

                level.TakeDamage(dealDamage);
            }

            //take damage

            Destroy(collision.gameObject);

        }
    }
}
