using Game.Models.PlayerCharacter;
using UnityEngine;

namespace Game.Systems
{
    public interface IPlayerMoveSystem
    {
        Vector3 GetNextMovePosition(PlayerCharacterView playerCharacterView);
    }
}