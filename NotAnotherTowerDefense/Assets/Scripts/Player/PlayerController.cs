using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

enum PlacementMode
{
    Mode_Range,
    Mode_Melee,
    Mode_Gold,
    Mode_Silver,
    Mode_Inactive
}

public class PlayerController : MonoBehaviour
{
    public TownScript town;

    PlacementMode m_CurrentMode = PlacementMode.Mode_Inactive;

    [SerializeField] private GameObject m_RangeTowerRef;
    [SerializeField] private GameObject m_MeleeTowerRef;
    [SerializeField] private GameObject m_GoldTowerRef;
    [SerializeField] private GameObject m_SilverTowerRef;

    private bool m_IsPlacing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        CheckForKeyInput(); 


        //update currencys
        town.ClaimTownSilver();

        foreach (SilverTowerScript tower in town.silverTowers)
        {
            tower.ClaimSiliver();
        }

        foreach (GoldTowerScript tower in town.goldTowers)
        {
            tower.ClaimGold();
        }

        //update payments
        int goldLength = town.goldTowers.Count;
        int silverLength = town.silverTowers.Count;
        int meleeLength = town.attackTowerMelees.Count;
        int rangeLength = town.attackTowerRanges.Count;
        int[] lengths = { goldLength, silverLength, meleeLength, rangeLength };
        int maxSize = lengths.Max();

        for(int i = 0; i < maxSize; i++)
        {
            if(goldLength < i && goldLength != 0)
            {
                town.goldTowers[i].PayCost();
            }

            if (silverLength < i && silverLength != 0)
            {
                town.silverTowers[i].PayCost();
            }

            if (meleeLength < i && meleeLength != 0 )
            {
                town.attackTowerMelees[i].PayCost();
            }

            if (rangeLength < i && rangeLength != 0 )
            {
                town.attackTowerRanges[i].PayCost();
            }
        }
    }

    void PlaceTower(PlacementMode _Mode)
    {
        m_CurrentMode = _Mode;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject newTower = null;
        switch (m_CurrentMode)
        {
            case PlacementMode.Mode_Melee:
                newTower = Instantiate(m_MeleeTowerRef, mousePosition, Quaternion.identity);
                break;
            case PlacementMode.Mode_Range:
                newTower = Instantiate(m_RangeTowerRef, mousePosition, Quaternion.identity);
                break;
            case PlacementMode.Mode_Gold:
                newTower = Instantiate(m_GoldTowerRef, mousePosition, Quaternion.identity);
                break;
            case PlacementMode.Mode_Silver:
                newTower = Instantiate(m_SilverTowerRef, mousePosition, Quaternion.identity);
                break;
        }

        if (CheckPlacement(newTower) == false)
        {
            Destroy(newTower);
        }
        else
        {
            switch (m_CurrentMode)
            {
                case PlacementMode.Mode_Melee:
                    town.attackTowerMelees.Add(newTower.GetComponent<AttackTowerMeleeScript>());
                    break;
                case PlacementMode.Mode_Range:
                    town.attackTowerRanges.Add(newTower.GetComponent<AttackTowerRangeScript>());
                    break;
                case PlacementMode.Mode_Gold:
                    town.goldTowers.Add(newTower.GetComponent<GoldTowerScript>());
                    break;
                case PlacementMode.Mode_Silver:
                    town.silverTowers.Add(newTower.GetComponent<SilverTowerScript>());
                    break;
            }
        }
    }

    bool CheckPlacement(GameObject _TowerObj)
    {
        
        GameObject[] Path = GameObject.FindGameObjectsWithTag("Path");
        GameObject[] Towers = GameObject.FindGameObjectsWithTag("Towers");

        Debug.Log(Path.Length);
        foreach (GameObject _Tower in Towers)
        {
            if (_TowerObj.GetComponent<BoxCollider2D>().bounds.Intersects(_Tower.GetComponent<BoxCollider2D>().bounds) && _TowerObj != _Tower)
            {
                return false;
            }

        }

        foreach (GameObject _Path in Path)
        {
            if (_TowerObj.GetComponent<BoxCollider2D>().bounds.Intersects(_Path.GetComponent<BoxCollider2D>().bounds))
            {
                return false;
            }

        }


        return true;
    }

    void CheckForKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) //Placing Melee
        {
            PlaceTower(PlacementMode.Mode_Melee);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) //Placing Ranged
        {
            PlaceTower(PlacementMode.Mode_Range);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) //Placing Gold
        {
            PlaceTower(PlacementMode.Mode_Gold);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) //Placing Silver
        {
            PlaceTower(PlacementMode.Mode_Silver);
        }
    }
}
