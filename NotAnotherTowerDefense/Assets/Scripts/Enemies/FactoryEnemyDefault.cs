using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryEnemyDefault : EnemyFactory
{

    [SerializeField] private EnemyDefault m_EnemyDefaultPrefab;

    public override Enemy GetEnemy(Transform _Transform)
    {
        GameObject newEnemyInstance = Instantiate(m_EnemyDefaultPrefab.gameObject, _Transform.position, _Transform.rotation);
        newEnemyInstance.tag = "Enemies";

        EnemyDefault newDefault = newEnemyInstance.GetComponent<EnemyDefault>();
        newDefault.Initialize();
        newEnemyInstance.name = newDefault.EnemyName;

        return newDefault;
    }
}
