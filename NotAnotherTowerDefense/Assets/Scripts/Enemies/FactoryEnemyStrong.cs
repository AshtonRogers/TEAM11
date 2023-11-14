using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryEnemyStrong : EnemyFactory
{
    //Enemy Factory for Creating the "Strong Enemy Type"

    [SerializeField] public EnemyStrong m_EnemyDefaultPrefab;

    public override Enemy GetEnemy()
    {
        Vector3 Temp = new Vector3(0f, 6.5f, 0f);
        GameObject newEnemyInstance = Instantiate(m_EnemyDefaultPrefab.gameObject, Temp, Quaternion.identity);
        newEnemyInstance.tag = "Enemies";

        EnemyStrong newStrong = newEnemyInstance.GetComponent<EnemyStrong>();
        newStrong.Initialize();

        newEnemyInstance.name = newStrong.EnemyName;
        return newStrong;
    }
}
