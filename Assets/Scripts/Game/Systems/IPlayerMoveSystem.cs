using Game.Models.PlayerCharacter;
using UnityEngine;

namespace Game.Systems
{
    public interface IPlayerMoveSystem
    {
        Vector3 GetMovePosition(PlayerCharacterView playerCharacterView);
    }
}