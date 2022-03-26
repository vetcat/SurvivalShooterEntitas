using Game.Models.CameraModel;
using UnityEngine;

namespace Libs.OpenCore.Providers
{
    public class CameraProvider : ICameraProvider
    {
        public CameraView CameraView { get; }
        public Vector3 Offset { get; }
        public float ScreenAspect { get; }

        public CameraProvider(CameraView cameraView)
        {
            CameraView = cameraView;
            ScreenAspect = Screen.width / Screen.height;
            Offset = CameraView.transform.position;
        }

        public Vector2 GetScreenPosition(Vector3 worldPosition)
        {
            return CameraView.Camera.WorldToScreenPoint(worldPosition);
        }

        public Vector3 GetWorldPosition(Vector2 screenPosition)
        {
            return CameraView.Camera.ScreenToWorldPoint(screenPosition);
        }

        public Ray ScreenPointToRay(Vector2 position)
        {
            return CameraView.Camera.ScreenPointToRay(position);
        }

        public Vector3 GetLayerHitPoint(int mask, Vector2 position, float lenght)
        {
            var ray = ScreenPointToRay(position);
            if (Physics.Raycast(ray, out var hit, lenght, mask))
            {
                return hit.point;
            }
            
            return Vector3.zero;
        }
    }
}