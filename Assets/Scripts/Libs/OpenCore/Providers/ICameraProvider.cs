using Game.Models.CameraModel;
using UnityEngine;

namespace Libs.OpenCore.Providers
{
    public interface ICameraProvider
    {
        CameraView CameraView { get; }
        Vector3 Offset { get; }
        float ScreenAspect { get; }
        Vector2 GetScreenPosition(Vector3 worldPosition);
        Vector3 GetWorldPosition(Vector2 screenPosition);
        Ray ScreenPointToRay(Vector2 position);
        Vector3 GetLayerHitPoint(int mask, Vector2 position, float lenght);
    }
}