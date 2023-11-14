using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

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

    [SerializeField] private GameObject m_ButtonParent;
    [SerializeField] private Button m_Button1;
    [SerializeField] private Button m_Button2;
    [SerializeField] private Button m_Button3;
    [SerializeField] private Button m_CloseButton;
    [SerializeField] private GameObject m_Panel;

    [SerializeField] private TextMeshProUGUI m_ResourceText;
    private float m_ResourceTextTimer = 0.0f;

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
            if (town.goldTowers.Count > i && goldLength > 0)
            {
                Debug.Log("Gold Upkeep Taken");
                town.goldTowers[i].PayCost();
            }

            if (town.silverTowers.Count > i && silverLength > 0)
            {
                Debug.Log("Silver Upkeep Taken");
                town.silverTowers[i].PayCost();
            }

            if (town.attackTowerMelees.Count > i && meleeLength > 0)
            {
                Debug.Log("Melee Upkeep Taken");
                town.attackTowerMelees[i].PayCost();
            }

            if (town.attackTowerRanges.Count > i && rangeLength > 0)
            {
                Debug.Log("Range Upkeep Taken");
                town.attackTowerRanges[i].PayCost();
            }
        }

        //check the resource timer
        if (m_ResourceTextTimer <= 0.0f)
        {
            m_ResourceText.text = " ";
        }
        else
        {
            m_ResourceTextTimer -= Time.deltaTime;
        }
    }

    //place a tower based on position and input
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
        else if (CheckResources() == false)
        {
            NotEnoughResourcesText();
            Destroy(newTower);
        }
        else
        {
            switch (m_CurrentMode)
            {
                case PlacementMode.Mode_Melee:
                    town.attackTowerMelees.Add(newTower.GetComponent<AttackTowerMeleeScript>());
                    newTower.GetComponent<AttackTowerMeleeScript>().SetActive(true);
                    break;
                case PlacementMode.Mode_Range:
                    town.attackTowerRanges.Add(newTower.GetComponent<AttackTowerRangeScript>());
                    newTower.GetComponent<AttackTowerRangeScript>().SetActive(true);
                    break;
                case PlacementMode.Mode_Gold:
                    town.goldTowers.Add(newTower.GetComponent<GoldTowerScript>());
                    newTower.GetComponent<GoldTowerScript>().SetActive(true);
                    break;
                case PlacementMode.Mode_Silver:
                    town.silverTowers.Add(newTower.GetComponent<SilverTowerScript>());
                    newTower.GetComponent<SilverTowerScript>().SetActive(true);
                    break;
            }
        }
    }

    //check if the placement position is valid
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

    //check there is enough resources to place
    bool CheckResources()
    {
        if(town.GetComponent<TownScript>().VerifyGold(25))
        {
            town.GetComponent<TownScript>().IncreaseGold(-25);
            return true;
        }

        return false;
    }

    //select the towers
    void SelectTower()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit) //Valid Selection of a tower 
        {
            if(hit.collider.gameObject.tag == "Path" || hit.collider.gameObject.tag == "Enemies" || hit.collider.gameObject.name == "TownTower")
            { }
            else
            {
                Debug.Log(hit.collider.gameObject.name);
                GameObject currentSelection = hit.collider.gameObject; //Setting the Game Obj Ref

                m_ButtonParent.GetComponent<TowerUpgradeButtons>().SetSelectedObject(currentSelection);

                //Enabling the Buttons 
                m_Panel.GetComponent<Image>().enabled = true;

                m_CloseButton.enabled = true;
                m_CloseButton.GetComponent<Image>().enabled = true;

                m_Button1.GetComponent<Button>().enabled = true;
                m_Button1.GetComponent<Image>().enabled = true;

                m_Button2.GetComponent<Button>().enabled = true;
                m_Button2.GetComponent<Image>().enabled = true;

                m_Button3.GetComponent<Button>().enabled = true;
                m_Button3.GetComponent<Image>().enabled = true;

            }
        }

    }

    //check of a player key input
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

        if (Input.GetMouseButtonDown(0)) //selecting towers
        {
            SelectTower();
        }
    }

    //set the not enough resources text
    public void NotEnoughResourcesText()
    {
        m_ResourceText.text = "Not Enough Resources";
        m_ResourceTextTimer = 1.0f;
    }
}
