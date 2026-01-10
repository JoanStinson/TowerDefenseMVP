using JGM.Gameplay.Base;
using JGM.Gameplay.Creeps;
using JGM.Gameplay.Turrets;
using JGM.Gameplay.Wallet;
using JGM.Gameplay.Waves;
using UnityEngine;

namespace JGM.Gameplay.Installer
{
    public class ServiceInstaller : MonoBehaviour
    {
        [Header("Initialization Data")]
        [SerializeField] private GameConfig gameConfig;
        [SerializeField] private Transform[] creepSpawnPoints;

        [Header("Service Instances")]
        [SerializeField] private PlayerBase playerBase;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private CoroutineService coroutineService;

        private void Awake()
        {
            var serviceLocator = ServiceLocator.Instance;
            InstallMonoServices(serviceLocator);
            InstallServices(serviceLocator);
        }

        private void InstallMonoServices(ServiceLocator serviceLocator)
        {
            playerBase.Initialize(gameConfig.PlayerStartHealth);
            serviceLocator.Register<PlayerBase>(playerBase);
            serviceLocator.Register<Camera>(mainCamera);
            serviceLocator.Register<CoroutineService>(coroutineService);
        }

        private void InstallServices(ServiceLocator serviceLocator)
        {
            var creepSpawner = new CreepSpawner(creepSpawnPoints);
            serviceLocator.Register<CreepSpawner>(creepSpawner);
            serviceLocator.Register<TurretSpawner>(new TurretSpawner(creepSpawner));
            serviceLocator.Register<WavesController>(new WavesController(gameConfig.WaveList));
            serviceLocator.Register<PlayerWallet>(new PlayerWallet(gameConfig.PlayerStartCoins));
        }
    }
}
