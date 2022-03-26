using System.Collections.Generic;
using Entitas;
using Game.Providers;
using Game.Settings;
using Libs.OpenCore.Ecs;
using Libs.OpenCore.Providers;
using UnityEngine;

namespace Game.Systems
{
    public class PlayerTurningSystem : IFixedSystem
    {
        private readonly IInputProvider _inputProvider;
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<GameEntity> _playersGroup;
        private readonly List<GameEntity> _playersBuffer = new List<GameEntity>();
        private readonly int _floorMask;
        private readonly float _camRayLen;

        public PlayerTurningSystem(GameContext gameContext, IInputProvider inputProvider,
            ICameraProvider cameraProvider, IGameParametersSettings gameParametersSettings)
        {
            _floorMask = LayerMask.GetMask (gameParametersSettings.LayerMaskFloor);
            _camRayLen = gameParametersSettings.CamRayLen;
            _inputProvider = inputProvider;
            _cameraProvider = cameraProvider;
            _playersGroup = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.PlayerCharacterView)
                .NoneOf(GameMatcher.Death, GameMatcher.Destroyed));
        }

        public void Execute()
        {
            _playersGroup.GetEntities(_playersBuffer);

            for (var i = 0; i < _playersBuffer.Count; i++)
            {
                var mousePosition = _inputProvider.MousePosition;
                var ray = _cameraProvider.ScreenPointToRay(mousePosition);
                
                if (Physics.Raycast(ray, out var floorHit, _camRayLen, _floorMask))
                {
                    var playerView = _playersBuffer[i].playerCharacterView.Value;
                    var direction = playerView.transform.position.GetDirectionToTarget(floorHit.point).SetY(0f);;

                    RigidbodyRotation(playerView.Rigidbody, direction);
                }
            }
        }

        private void RigidbodyRotation(Rigidbody rigidbody, Vector3 direction)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            rigidbody.MoveRotation(rotation);
        }
    }
}