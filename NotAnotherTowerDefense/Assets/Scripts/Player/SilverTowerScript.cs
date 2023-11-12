using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverTowerScript : MonoBehaviour
{
    float payTimer;

    float maxCostTimer = 1.0f;
    float costTimer;
    bool isActive;

    public GameObject MainTower;

    ResourceTowerDecorator towerDecorator = new ResourceBaseTower();

    // Start is called before the first frame update
    void Start()
    {
        payTimer = towerDecorator.GetGenerationSpeed;
        costTimer = maxCostTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (payTimer <= 0)
        {
            //pay town amount
            payTimer = towerDecorator.GetGenerationSpeed;
        }
        else
        {
            payTimer -= Time.deltaTime;
        }

        if (costTimer <= 0)
        {
            //pay cost
            costTimer = maxCostTimer;
        }
        else
        {
            costTimer -= Time.deltaTime;
        }
    }
}
