namespace Game.Settings
{
    public interface IGameParametersSettings
    {
        float PlayerMoveSpeed { get; }
        int StartingPlayerHealth { get; }

        int StartingEnemyHealth { get; }
        float EnemySinkSpeed { get; }
        int EnemyAttackDamage { get; }
        float TimeBetweenEnemyAttacks { get; }

        float TimeBetweenBullets { get; }
        float GunRange { get; }
        float GunEffectsDisplayTime { get; }

        int DamagePerShot { get; }

        int ScorePerDeath { get; }

        float CamRayLen { get; }
        float CamSmoothing { get; }
    }
}