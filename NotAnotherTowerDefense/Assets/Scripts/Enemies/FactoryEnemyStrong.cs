using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryEnemyStrong : EnemyFactory
{

    [SerializeField] public EnemyStrong m_EnemyDefaultPrefab;

    public override Enemy GetEnemy()
    {
        Vector3 Temp = new Vector3(0f, 0f, 0f);
        GameObject newEnemyInstance = Instantiate(m_EnemyDefaultPrefab.gameObject, Temp, Quaternion.identity);
        newEnemyInstance.tag = "Enemies";

        EnemyStrong newStrong = newEnemyInstance.GetComponent<EnemyStrong>();
        newStrong.Initialize();

        newEnemyInstance.name = newStrong.EnemyName;
        return newStrong;
    }
}
