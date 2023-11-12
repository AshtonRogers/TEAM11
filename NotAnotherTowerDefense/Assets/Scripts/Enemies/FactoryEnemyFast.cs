using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryEnemyFast : EnemyFactory
{

    [SerializeField] private EnemyDefault m_EnemyDefaultPrefab;

    public override Enemy GetEnemy(Transform _Transform)
    {
        GameObject newEnemyInstance = Instantiate(m_EnemyDefaultPrefab.gameObject, _Transform.position, _Transform.rotation);
        newEnemyInstance.tag = "Enemies";

        EnemyDefault newFast = newEnemyInstance.GetComponent<EnemyDefault>();
        newFast.Initialize();

        newEnemyInstance.name = newFast.EnemyName;
        return newFast;
    }
}
