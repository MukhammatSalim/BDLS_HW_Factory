using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

    /// <summary>
    /// Enemy abstract class
    /// </summary>
    public abstract class AbstractEnemy : MonoBehaviour, IEnemy
    {
        [SerializeField] protected EnemyData data;

        /// <summary>
        /// Configure enemy by data
        /// </summary>
        /// <param name="data"></param>
        public event Action<float> OnEnemyKilled;
        public NavMeshAgent _agent;
        public Slider _HPBar;
        public float _health;
        private float _maxHealth;
        float _dodgeChance;
        float _dmgReduction;
        public float WaveCost { get; internal set; }

        public WaveManager waveMeneger;

        private void OnEnable()
        {
            
            waveMeneger = GameObject.Find("--Managers").GetComponent<WaveManager>();
            _dodgeChance = data.EvasionChance;
            _dmgReduction = data.DmgReduction;
            _health = data.Health;
            _maxHealth = _health;
        }
        public void SetDestination(Vector3 targetPosition)
        {
            _agent.SetDestination(targetPosition);
        }
        public void Move(Vector3 targetLocation)
        {
            _agent.SetDestination(targetLocation);
        }
        private void Update()
        {
            // Vector3 dir = Camera.main.transform.position - _HPBar.GetComponentInParent<Canvas>().transform.position;
            // dir.x = 0;
            // dir.y = 0;
            // dir.z = 0;
        }

        public void TakeDamage(float dmg)
        {
            if (UnityEngine.Random.Range(1,100)>_dodgeChance){
            _health -= dmg * (1-(_dmgReduction/100));

            _HPBar.value = _health / _maxHealth;

            if (_health <= 0)
            {
                waveMeneger.DestroyEnemy(gameObject);
            }
            } else Debug.Log("Dmg Evaded");
        }

        private void OnMouseDown() {
            TakeDamage(50);
        }
        public virtual void Configure(EnemyData data)
        {
            this.data = data;
        }
    }