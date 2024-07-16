using System.Linq;
using Cysharp.Threading.Tasks;
using PistolGame.Code.Core.Player;
using PistolGame.Code.Core.Player.ClosestTrack;
using PistolGame.Code.Core.Player.Movement;
using PistolGame.Code.Core.Player.Weapons;
using PistolGame.Code.Core.UI.HUD;
using PistolGame.Code.Services.Assets;
using PistolGame.Code.Services.EntityContainer;
using PistolGame.Code.Services.Factories.WeaponsFactory;
using PistolGame.Code.Services.SpawnedEntitiesProvider;
using PistolGame.Code.Services.StaticData;
using UnityEngine;

namespace PistolGame.Code.Services.Factories.PlayerFactory
{
    public class PlayerFactory : BaseFactory.BaseFactory, IPlayerFactory
    {
        private readonly IWeaponsFactory _weaponsFactory;
        private readonly IStaticData _staticData;
        private readonly ISpawnedEntitiesProvider _spawnedEntitiesProvider;

        public PlayerFactory(IAssets assets, IEntityContainer entityContainer, IWeaponsFactory weaponsFactory,
            IStaticData staticData, ISpawnedEntitiesProvider spawnedEntitiesProvider) : base(assets, entityContainer)
        {
            _weaponsFactory = weaponsFactory;
            _staticData = staticData;
            _spawnedEntitiesProvider = spawnedEntitiesProvider;
        }

        public async UniTask WarmUp()
        {
            await _assets.Load<GameObject>(nameof(Player));
            await _assets.Load<GameObject>(nameof(PlayerCamera));
            await _weaponsFactory.WarmUp();
        }

        public async UniTask<Player> CreatePlayer()
        {
            Player player = await InstantiateAsRegistered<Player>();
            Weapon[] weapons = await _weaponsFactory.CreateWeapons(player.Weapon.WeaponLocation);
            player.Construct(CreatePlayerMovement(player), weapons);
            CreateClosestTargetFinder(player, _spawnedEntitiesProvider
                .GetEntitiesByLayer(_staticData.PlayerConfiguration.TargetsMask).Keys.ToArray());
            await CreatePlayerCamera(player);
            return player;
        }
            
        private async UniTask CreatePlayerCamera(Player player)
        {
            PlayerCamera playerCamera = await InstantiateAsRegistered<PlayerCamera>();
            playerCamera.Construct(player.transform);
        }

        private PlayerMovement CreatePlayerMovement(Player player)
        {
            PlayerMovement movement = player.gameObject.AddComponent<PlayerMovement>();
            movement.Construct(player, _entityContainer.GetEntity<IPlayerInput>(),
                _staticData.PlayerConfiguration.MovementSpeed);
            return movement;
        }

        private void CreateClosestTargetFinder(Player player, Transform[] targets)
        {
            ClosestTargetFinder closestTargetFinder = player.gameObject.AddComponent<ClosestTargetFinder>();
            closestTargetFinder.Construct(player, targets);
        }
    }
}