using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryEnemyStrong : EnemyFactory
{

    [SerializeField] private EnemyStrong m_EnemyDefaultPrefab;

    public override Enemy GetEnemy(Transform _Transform)
    {
        GameObject newEnemyInstance = Instantiate(m_EnemyDefaultPrefab.gameObject, _Transform.position, _Transform.rotation);
        newEnemyInstance.tag = "Enemies";

        EnemyDefault newStrong = newEnemyInstance.GetComponent<EnemyDefault>();
        newStrong.Initialize();

        newEnemyInstance.name = newStrong.EnemyName;
        return newStrong;
    }
}
