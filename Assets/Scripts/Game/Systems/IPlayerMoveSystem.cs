using UnityEngine;

namespace Game.Systems
{
    public interface IPlayerMoveSystem
    {
        Vector3 GetNextMovePosition(GameEntity player);
    }
}