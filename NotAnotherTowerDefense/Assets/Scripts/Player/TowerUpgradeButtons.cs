using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TowerUpgradeButtons : MonoBehaviour
{
    public GameObject selectedObject;

    [SerializeField] private GameObject m_Panel;
    [SerializeField] private Button m_CloseButton;

    [SerializeField] private Button m_Button1;
    [SerializeField] private Button m_Button2;
    [SerializeField] private Button m_Button3;

    [SerializeField] private TextMeshProUGUI m_Button1Text;
    [SerializeField] private TextMeshProUGUI m_Button2Text;
    [SerializeField] private TextMeshProUGUI m_Button3Text;
    [SerializeField] private TextMeshProUGUI m_TowerType;

    // Start is called before the first frame update
    void Start()
    {
        CloseButtonPressed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //set the obejct that is selected
    public void SetSelectedObject(GameObject selected)
    {
        if(selected != null)
        {
            selectedObject = selected;
            SetText();
        }
        else
        {
            ClearText();
        }
        
    }

    //set the text based off the selected tower
    private void SetText()
    {
        if (selectedObject.name == "AttackTowerMeleePrefab(Clone)")
        {
            m_Button1Text.text = ("Attack Speed: " + selectedObject.GetComponent<AttackTowerMeleeScript>().GetTowerLevel());
            m_Button2Text.text = ("Damage: " + selectedObject.GetComponent<AttackTowerMeleeScript>().GetTowerLevel());
            if (selectedObject.GetComponent<AttackTowerMeleeScript>().isActive)
            {
                m_Button3Text.text = ("Deactivate");
            }
            else
            {
                m_Button3Text.text = ("Activate");
            }

            m_TowerType.text = "Melee";

            Debug.Log("Melee Tower Selected");
        }
        else if (selectedObject.name == "AttackTowerRangePrefab(Clone)")
        {
            m_Button1Text.text = ("Attack Speed: " + selectedObject.GetComponent<AttackTowerRangeScript>().GetTowerLevel());
            m_Button2Text.text = ("Damage: " + selectedObject.GetComponent<AttackTowerRangeScript>().GetTowerLevel());
            if (selectedObject.GetComponent<AttackTowerRangeScript>().isActive)
            {
                m_Button3Text.text = ("Deactivate");
            }
            else
            {
                m_Button3Text.text = ("Activate");
            }

            m_TowerType.text = "Range";

            Debug.Log("Range Tower Selected");
        }
        else if (selectedObject.name == "GoldTowerPrefab(Clone)")
        {
            m_Button1Text.text = ("Gen Speed: " + selectedObject.GetComponent<GoldTowerScript>().GetTowerLevel());
            m_Button2Text.text = ("Amount: " + selectedObject.GetComponent<GoldTowerScript>().GetTowerLevel());
            if (selectedObject.GetComponent<GoldTowerScript>().isActive)
            {
                m_Button3Text.text = ("Deactivate");
            }
            else
            {
                m_Button3Text.text = ("Activate");
            }

            m_TowerType.text = "Gold";

            Debug.Log("Gold Tower Selected");
        }
        else if (selectedObject.name == "SilverTowerPrefab(Clone)")
        {
            m_Button1Text.text = ("Gen Speed: " + selectedObject.GetComponent<SilverTowerScript>().GetTowerLevel());
            m_Button2Text.text = ("Amount: " + selectedObject.GetComponent<SilverTowerScript>().GetTowerLevel());
            if (selectedObject.GetComponent<SilverTowerScript>().isActive)
            {
                m_Button3Text.text = ("Deactivate");
            }
            else
            {
                m_Button3Text.text = ("Activate");
            }

            m_TowerType.text = "Silver";

            Debug.Log("Silver Tower Selected");
        }
    }

    //clear the text
    private void ClearText()
    {
        m_Button1Text.text = " ";
        m_Button2Text.text = " ";
        m_Button3Text.text = " ";
        m_TowerType.text = " ";
    }

    //the function placed on the button for the speed upgrade
    public void DoSpeedUpgrade()
    {
        if (selectedObject.name == "AttackTowerMeleePrefab(Clone)")
        {
            selectedObject.GetComponent<AttackTowerMeleeScript>().UpgradeAttackSpeedButton();
        }
        else if(selectedObject.name == "AttackTowerRangePrefab(Clone)")
        {
            selectedObject.GetComponent<AttackTowerRangeScript>().UpgradeAttackSpeedButton();
        }
        else if(selectedObject.name == "GoldTowerPrefab(Clone)")
        {
            selectedObject.GetComponent<GoldTowerScript>().UpgradeGenerationSpeedButton();
        }
        else if(selectedObject.name == "SilverTowerPrefab(Clone)")
        {
            selectedObject.GetComponent<SilverTowerScript>().UpgradeGenerationSpeedButton();
        }

        SetText();
    }

    //the function placed on the button for the damage or amount upgrade
    public void DoDamageOrAmountUpgrade()
    {
        if (selectedObject.name == "AttackTowerMeleePrefab(Clone)")
        {
            selectedObject.GetComponent<AttackTowerMeleeScript>().UpgradeDamageButton();
        }
        else if (selectedObject.name == "AttackTowerRangePrefab(Clone)")
        {
            selectedObject.GetComponent<AttackTowerRangeScript>().UpgradeDamageButton();
        }
        else if (selectedObject.name == "GoldTowerPrefab(Clone)")
        {
            selectedObject.GetComponent<GoldTowerScript>().UpgradeAmountButton();
        }
        else if (selectedObject.name == "SilverTowerPrefab(Clone)")
        {
            selectedObject.GetComponent<SilverTowerScript>().UpgradeAmountButton();
        }

        SetText();
    }

    //the function placed on the button for the activity of the tower
    public void DoEnabledButton()
    {
        if (selectedObject.name == "AttackTowerMeleePrefab(Clone)")
        {
            selectedObject.GetComponent<AttackTowerMeleeScript>().ChangeActive();
        }
        else if (selectedObject.name == "AttackTowerRangePrefab(Clone)")
        {
            selectedObject.GetComponent<AttackTowerRangeScript>().ChangeActive();
        }
        else if (selectedObject.name == "GoldTowerPrefab(Clone)")
        {
            selectedObject.GetComponent<GoldTowerScript>().ChangeActive();
        }
        else if (selectedObject.name == "SilverTowerPrefab(Clone)")
        {
            selectedObject.GetComponent<SilverTowerScript>().ChangeActive();
        }

        SetText();
    }

    //to close the upgrade menu
    public void CloseButtonPressed()
    {
        ClearText();
        m_Button1.GetComponent<Button>().enabled = false;
        m_Button1.GetComponent<Image>().enabled = false;

        m_Button2.GetComponent<Button>().enabled = false;
        m_Button2.GetComponent<Image>().enabled = false;

        m_Button3.GetComponent<Button>().enabled = false;
        m_Button3.GetComponent<Image>().enabled = false;
        m_CloseButton.enabled = false;
        m_CloseButton.GetComponent<Image>().enabled = false;
        m_Panel.GetComponent<Image>().enabled = false;
    }
}
