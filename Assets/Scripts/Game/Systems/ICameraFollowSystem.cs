using UnityEngine;

namespace Game.Systems
{
    public interface ICameraFollowSystem
    {
        Vector3 GetCameraPositionFromTarget(Vector3 targetPosition, Vector3 offset);
    }
}