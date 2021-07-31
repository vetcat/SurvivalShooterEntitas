using UnityEngine;

namespace Game.Settings
{
    [CreateAssetMenu(menuName = "Settings/GameSoundFxSettings", fileName = "GameSoundFxSettings")]
    public class GameSoundFxSettings : ScriptableObject, IGameSoundFxSettings
    {
        public AudioClip PlayerDeathClip => _playerDeathClip;
        [SerializeField] private AudioClip _playerDeathClip;

        public AudioClip EnemyDeathClip => _enemyDeathClip;
        [SerializeField] private AudioClip _enemyDeathClip;
    }
}