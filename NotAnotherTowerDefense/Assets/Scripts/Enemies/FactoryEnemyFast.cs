using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryEnemyFast : EnemyFactory
{
    //Enemy Factory for Creating the "Fast Enemy Type"
    [SerializeField] public EnemyFast m_EnemyDefaultPrefab;

    public override Enemy GetEnemy()
    {

        Vector3 Temp = new Vector3(0f, 6.5f, 0f);
        GameObject newEnemyInstance = Instantiate(m_EnemyDefaultPrefab.gameObject, Temp, Quaternion.identity);

        //GameObject newEnemyInstance = Instantiate(m_EnemyDefaultPrefab.gameObject, _Transform.position, _Transform.rotation);
        newEnemyInstance.tag = "Enemies";

        EnemyFast newFast = newEnemyInstance.GetComponent<EnemyFast>();
        newFast.Initialize();

        newEnemyInstance.name = newFast.EnemyName;
        return newFast;
    }
}
