using System.Collections.Generic;
using Entitas;
using Game.Settings;
using Libs.OpenCore.Ecs;
using Libs.OpenCore.Providers;
using UnityEngine;

namespace Game.Systems
{
    public class CameraFollowSystem : IFixedSystem, ICameraFollowSystem
    {
        private readonly ITimeProvider _timeProvider;
        private readonly IGameParametersSettings _gameParametersSettings;
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<GameEntity> _playersGroup;
        private readonly List<GameEntity> _playersBuffer = new List<GameEntity>();

        public CameraFollowSystem(GameContext gameContext, ITimeProvider timeProvider,
            IGameParametersSettings gameParametersSettings, ICameraProvider cameraProvider)
        {
            _timeProvider = timeProvider;
            _gameParametersSettings = gameParametersSettings;
            _cameraProvider = cameraProvider;
            _playersGroup = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.PlayerCharacterView)
                .NoneOf(GameMatcher.Death, GameMatcher.Destroyed));
        }

        public void Execute()
        {
            _playersGroup.GetEntities(_playersBuffer);
            if (_playersBuffer.Count < 1)
                return;

            var firstPlayer = _playersBuffer[0];
            var playerPosition = firstPlayer.playerCharacterView.Value.transform.position;
            
            var targetCamPos = GetCameraPositionFromTarget(playerPosition, _cameraProvider.Offset);
            var smoothing = _gameParametersSettings.CamSmoothing;
            var camera = _cameraProvider.CameraView;
            
            camera.transform.position = Vector3.Lerp(camera.transform.position, targetCamPos, smoothing * _timeProvider.DeltaTime);
        }

        public Vector3 GetCameraPositionFromTarget(Vector3 targetPosition, Vector3 offset)
        {
            return targetPosition + offset;
        }
    }
}