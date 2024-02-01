using UnityEngine;

namespace Exemple.Factory
{
    /// <summary>
    /// Enemy types
    /// </summary>
    public enum EnemyType
    {
        Walking,
        Flying,
        Armored
    }

    /// <summary>
    /// Enemy data
    /// </summary>
    [CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
    public class EnemyData : ScriptableObject
    {
        public GameObject Prefab;
        public EnemyType Type;
        public float MoveSpeed;
        public float Health;        
        public float DmgReduction;
        public float EvasionChance;
    }   
}