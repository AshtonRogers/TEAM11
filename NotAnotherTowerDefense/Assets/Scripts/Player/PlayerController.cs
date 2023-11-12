using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

enum PlacementMode
{
    Mode_Range,
    Mode_Melee,
    Mode_Inactive
}

public class PlayerController : MonoBehaviour
{
    public TownScript town;

    PlacementMode m_CurrentMode = PlacementMode.Mode_Inactive;

    [SerializeField] private GameObject m_RangeTowerRef;
    [SerializeField] private GameObject m_MeleeTowerRef;

    private bool m_IsPlacing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlaceTower(PlacementMode.Mode_Melee);
        }


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
            if(goldLength < i)
            {
                town.goldTowers[i].PayCost();
            }

            if (silverLength < i)
            {
                town.silverTowers[i].PayCost();
            }

            if (meleeLength < i)
            {
                town.attackTowerMelees[i].PayCost();
            }

            if (rangeLength < i)
            {
                town.attackTowerRanges[i].PayCost();
            }
        }
    }

    void PlaceTower(PlacementMode _Mode)
    {
        m_CurrentMode = _Mode;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        switch (m_CurrentMode)
        {
            case PlacementMode.Mode_Melee:
                GameObject newMelee = Instantiate(m_MeleeTowerRef, mousePosition, Quaternion.identity);

                if (CheckPlacement(newMelee) == false)
                {
                    Destroy(newMelee);
                }
                else
                {


                }
                break;
            case PlacementMode.Mode_Range:

                break;
        }
    }

    bool CheckPlacement(GameObject _TowerObj)
    {
        
        GameObject[] Path = GameObject.FindGameObjectsWithTag("Path");
        GameObject[] Towers = GameObject.FindGameObjectsWithTag("Towers");

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
}
