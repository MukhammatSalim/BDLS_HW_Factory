using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class WaveManager : MonoBehaviour
    {
        public Transform SpawnLocation;
        public Transform TargetLocation;
        /// <summary>
        /// List of enemies data and wave settings
        /// </summary>
        public List<WaveSettings> waveSettings = new List<WaveSettings>();

        /// <summary>
        /// List of enemies
        /// </summary>
        public List<GameObject> enemies = new List<GameObject>();

        /// <summary>
        /// Wave settings
        /// </summary>
        [Serializable]
        public class WaveSettings
        {
            public int EnemyCount;
            public float WaveDelay;
            public float CostPerUnit;
            public float SpawnDelay;
            public EnemyData EnemyData;
        }

        private void Start()
        {
            for(int i = 0; i < waveSettings.Count; i++)
            CreateWave(waveSettings[i]);
        }

        /// <summary>
        /// Create wave of enemies
        /// </summary>
        /// <param name="waveData"></param>
        public void CreateWave(List<WaveSettings> waveSettings)
        {
            foreach (WaveSettings data in waveSettings)
            {
                for (int i = 0; i < data.EnemyCount; i++)
                {
                    IEnemy enemy = CreateEnemy(data.EnemyData);
                    enemy.Move(TargetLocation.position);//you can add Vector3 enemy.Move(whereToMove);
                    enemies.Add(enemy.gameObject);
                }
            }
        }

        /// <summary>
        /// Create one enemy
        /// </summary>
        /// <param name="waveData"></param>
        public void CreateWave(WaveSettings waveSettings)
        {
            StartCoroutine(CreateWaveOneByOne(waveSettings));
        }
        IEnumerator CreateWaveOneByOne(WaveSettings waveSettings){
            for (int i = 0; i < waveSettings.EnemyCount; i++)
            {
                IEnemy enemy = CreateEnemy(waveSettings.EnemyData);
                enemy.Move(TargetLocation.position);//you can add Vector3 enemy.Move(whereToMove);
                enemies.Add(enemy.gameObject);
                yield return new WaitForSeconds(waveSettings.SpawnDelay);
            }
        }

        /// <summary>
        /// Get enemy by factory type
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private IEnemy CreateEnemy(EnemyData data)
        {
            switch (data.Type)
            {
                case EnemyType.Walking:
                    EnemyFactory<WalkingEnemy> WalkingEnemyFactory = new EnemyFactory<WalkingEnemy>();
                    return WalkingEnemyFactory.CreateEnemy(data);
                case EnemyType.Flying:
                    EnemyFactory<FlyingEnemy> FlyingEnemyFactory = new EnemyFactory<FlyingEnemy>();
                    return FlyingEnemyFactory.CreateEnemy(data);
                    case EnemyType.Armored:
                    EnemyFactory<ArmoredEnemy> ArmoredEnemyFactory = new EnemyFactory<ArmoredEnemy>();
                    return ArmoredEnemyFactory.CreateEnemy(data);
                default:
                    return null;
            }
        }

        public void  DestroyEnemy(GameObject enemy){
            enemies.Remove(enemy);
            Destroy(enemy);
        }
    }
