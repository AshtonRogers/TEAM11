using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    EnemyFactory EnemyFactory;
    public int m_StartWave = 1;
    public int m_CurrentWave;
    // Start is called before the first frame update
    void Start()
    {
        m_CurrentWave = m_StartWave;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnWave()
    {
        if (GameObject.FindGameObjectsWithTag("Enemies") == null)
        {
            for (int i = 0; i != m_CurrentWave; i++)
            {
                //EnemyFactory.getEnemy()
            }
        } 
    }
    void SetEnemyPath()
    {
        
    }
}
