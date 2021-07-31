using UnityEngine;

namespace Game.Settings
{
    public interface IGameSoundFxSettings
    {
        AudioClip PlayerDeathClip { get; }
        AudioClip EnemyDeathClip { get; }
    }
}