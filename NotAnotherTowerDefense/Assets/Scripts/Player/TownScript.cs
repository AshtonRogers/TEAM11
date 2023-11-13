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

    public void AddGoldTower(GoldTowerScript tower)
    {
        goldTowers.Add(tower);
    }
    public void AddSilverTower(SilverTowerScript tower)
    {
        silverTowers.Add(tower);
    }
    public void AddMeleeTower(AttackTowerMeleeScript tower)
    {
        attackTowerMelees.Add(tower);
    }
    public void AddRangeTower(AttackTowerRangeScript tower)
    {
        attackTowerRanges.Add(tower);
    }

    public bool VerifyGold(int amount)
    {
        if(gold >= amount)
        {
            return true;
        }

        return false;
    }

    public bool VerifySilver(int amount)
    {
        if(silver >= amount)
        {
            return true;
        }

        return false;
    }


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
