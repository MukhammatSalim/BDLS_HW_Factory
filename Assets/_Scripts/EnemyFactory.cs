using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exemple.Factory
{
    /// <summary>
    /// Generic factory for creating enemies
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EnemyFactory<T> where T : MonoBehaviour, IEnemy
    {
        /// <summary>
        /// Create enemy by prefab and configure it
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public T CreateEnemy(EnemyData data)
        {
            GameObject instance = GameObject.Instantiate(data.Prefab);
            T enemy = instance.GetComponent<T>();
            enemy.Configure(data);
            return enemy;
        }
    }
}