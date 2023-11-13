using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Transform m_EnemySpawn;
    [SerializeField] EnemyFactory[] m_EnemyFactories;
    private EnemyFactory m_CurrentFactory;

    [SerializeField] private Text m_HealthText;
    [SerializeField] private Text m_LevelText;

    //Wave Control
    public int m_StartWave = 1;
    public int m_CurrentWave;
    private int m_CurrentSpawnCount = 0;

    //Timing Varibles
    private float m_SpawnTimer = 1.0f;
    private float m_TimeUntillSpawn;
    private float m_WaveTimer = 5.0f;
    private float m_TimeUntillNextWave; 
    
    public int m_ObjectiveHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentWave = m_StartWave;
        m_TimeUntillSpawn = m_SpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {

        //Spawning the Enemies & Waves
        SpawnWave();

        //Updating UI Text
        m_HealthText.text = m_ObjectiveHealth.ToString();
        m_LevelText.text = m_CurrentWave.ToString();
    }

    void SpawnWave() //Controls the Spawning of Enemies and Wave Flow
    {
        if (m_TimeUntillNextWave <= 0) //Time Between Waves is less than 0
        {
            m_TimeUntillSpawn -= Time.deltaTime; //Time Between Units Spawns 

            if (m_TimeUntillSpawn <= 0)
            {
                if (m_CurrentSpawnCount <= m_CurrentWave * 10) //Enemy Spawn Counter is less than Wave Spawn Count
                {
                    //Creating the Enemy 
                    m_CurrentFactory = m_EnemyFactories[Random.Range(0, m_EnemyFactories.Length)];
                    m_CurrentFactory.GetEnemy();

                    //Updating the Spawn Counter
                    m_CurrentSpawnCount++;
                }
                else //Preparing the Next Wave
                {
                    m_CurrentWave++; //Updating the Wave Count
                    m_CurrentSpawnCount = 0; //Reseting the Spawn Counter
                    m_TimeUntillNextWave = m_WaveTimer; //Reseting the Time Between Waves 
                }

                m_TimeUntillSpawn = m_SpawnTimer; //Reseting the Spawn Timer
            }
        }

        m_TimeUntillNextWave -= Time.deltaTime; //Updating Time Between Waves


    }

    public void TakeDamage(int damage)
    {
        m_ObjectiveHealth -= damage;

        if(m_ObjectiveHealth <= 0)
        {
            //endgame
        }
    }

    void SetEnemyPath()
    {

    }

    


}
