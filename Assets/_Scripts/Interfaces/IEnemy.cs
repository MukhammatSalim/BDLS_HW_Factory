using UnityEngine;

    /// <summary>
    /// Enemy interface
    /// </summary>
    public interface IEnemy
    {
        GameObject gameObject { get ; } 
        /// <summary>
        /// Configure enemy by data
        /// </summary>
        /// <param name="data"></param>
        void Configure(EnemyData data);

        /// <summary>
        /// Move enemy
        /// </summary>
        void Move(Vector3 targetLocation);
        void TakeDamage(float dmg);
    }