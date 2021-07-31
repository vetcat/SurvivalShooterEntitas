using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Libs.OpenCore.Ecs
{
    public abstract class EntityView : MonoBehaviour, IEntityView
    {
        public GameObject GameObject => gameObject;
        public GameEntity Entity => _entity;
        public bool IsDestroy => _destroyed;

        private GameEntity _entity;
        private bool _entityDestroyed;
        private bool _destroyed;

        public virtual void Link(IEntity entity)
        {
            _entityDestroyed = false;
            _entity = (GameEntity) entity;
            gameObject.Link(_entity);
            _entity.OnDestroyEntity += OnDestroyEntity;
        }
        
        public void OnDestroyEntity(IEntity entity)
        {
            _entityDestroyed = true;
            entity.OnDestroyEntity -= OnDestroyEntity;
            gameObject.Unlink();
            if (!_destroyed)
                DestroyObject();
        }

        protected virtual void DestroyObject()
        {
#if UNITY_EDITOR
            if (UnityEditor.EditorApplication.isPlaying)
                Destroy(gameObject);
            else
            {
                DestroyImmediate(gameObject);
            }
#else
            Destroy(gameObject);
#endif
        }

        private void OnDestroy()
        {
            _destroyed = true;
            if (!_entityDestroyed && _entity != null)
                OnDestroyEntity(_entity);
        }
    }
}