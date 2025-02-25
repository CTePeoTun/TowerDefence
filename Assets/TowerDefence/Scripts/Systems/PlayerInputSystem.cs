using Leopotam.Ecs;
using UnityEngine;

namespace TowerDefence
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, DirectionComponent> directionFilter = null;

        private float moveX;
        private float moveZ;
        
        public void Run()
        {
            GetDirection();
            
            foreach (var i in directionFilter)
            {
                ref var directionComponent = ref directionFilter.Get2(i);
                ref var direction = ref directionComponent.direction;

                direction.x = moveX;
                direction.z = moveZ;
            }
        }

        private void GetDirection()
        {
            moveX = Input.GetAxis("Horizontal");
            moveZ = Input.GetAxis("Vertical");
        }
    }
}