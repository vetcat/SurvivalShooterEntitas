using UnityEngine;

namespace Game.Settings
{
    [CreateAssetMenu(menuName = "Settings/GameParametersSettings", fileName = "GameParametersSettings")]
    public class GameParametersSettings : ScriptableObject, IGameParametersSettings
    {
        public float PlayerMoveSpeed => _playerMoveSpeed;
        [SerializeField] private float _playerMoveSpeed = 6f;

        public int StartingPlayerHealth => _startingPlayerHealth;
        [SerializeField] private int _startingPlayerHealth = 100;

        public int StartingEnemyHealth => _startingEnemyHealth;
        [SerializeField] private int _startingEnemyHealth = 100;

        public float EnemySinkSpeed => _enemySinkSpeed;
        [SerializeField] private float _enemySinkSpeed = 2.5f;

        public int EnemyAttackDamage => _enemyAttackDamage;
        [SerializeField] private int _enemyAttackDamage = 20;

        public float TimeBetweenEnemyAttacks => _timeBetweenEnemyAttacks;
        [SerializeField] private float _timeBetweenEnemyAttacks = 0.5f;

        public float TimeBetweenBullets => _timeBetweenBullets;
        [SerializeField] private float _timeBetweenBullets = 0.15f;

        public float GunRange => _gunRange;
        [SerializeField] private float _gunRange = 100f;

        public float GunEffectsDisplayTime => _gunEffectsDisplayTime;
        [SerializeField] private float _gunEffectsDisplayTime = 0.2f;

        public int DamagePerShot => _damagePerShot;
        [SerializeField] private int _damagePerShot = 20;

        public int ScorePerDeath => _scorePerDeath;
        [SerializeField] private int _scorePerDeath = 10;

        public float CamRayLen => _camRayLen;
        [SerializeField] private float _camRayLen = 100f;

        public float CamSmoothing => _camSmoothing;
        [SerializeField] private float _camSmoothing = 5f;
    }
}
