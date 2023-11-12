using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    public TownScript town;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
