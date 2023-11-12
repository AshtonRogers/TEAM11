using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryEnemyDefault : EnemyFactory
{

    [SerializeField] public EnemyDefault m_EnemyDefaultPrefab;

    public override Enemy GetEnemy()
    {
        Vector3 Temp = new Vector3(0f, 0f, 0f);
        //GameObject newEnemyInstance = Instantiate(m_EnemyDefaultPrefab.gameObject, _Transform.position, _Transform.rotation);
        GameObject newEnemyInstance = Instantiate(m_EnemyDefaultPrefab.gameObject, Temp, Quaternion.identity);
        newEnemyInstance.tag = "Enemies";

        EnemyDefault newDefault = newEnemyInstance.GetComponent<EnemyDefault>();
        newDefault.Initialize();

        newEnemyInstance.name = newDefault.EnemyName;

        return newDefault;
    }
}
