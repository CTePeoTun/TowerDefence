using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace TowerDefence
{
    public class EcsBoostrap : MonoBehaviour
    {
        private EcsWorld world;
        private EcsSystems systems;
        private EcsSystems fixedSystems;

        private void Start()
        {
            world = new EcsWorld();
            systems = new EcsSystems(world);
            fixedSystems = new EcsSystems(world);

            AddSystems();
            
            systems.ConvertScene();
            fixedSystems.ConvertScene();
            
            systems.Init();
            fixedSystems.Init();
        }

        private void AddSystems()
        {
            systems.Add(new PlayerInputSystem());
            fixedSystems.Add(new MovementSystem());
        }
        
        private void Update()
            => systems.Run();

        private void FixedUpdate()
            => fixedSystems.Run();

        private void OnDestroy()
        {
            DestroySystems();
            DestroyFixedSystems();
            DestroyWorld();
        }

        private void DestroySystems()
        {
            if (systems == null)
                return;
            
            systems.Destroy();
            systems = null;
        }
        
        private void DestroyFixedSystems()
        {
            if (fixedSystems == null)
                return;
            
            fixedSystems.Destroy();
            fixedSystems = null;
        }
        
        private void DestroyWorld()
        {
            if (world == null)
                return;
            
            world.Destroy();
            world = null;
        }
    }
}
