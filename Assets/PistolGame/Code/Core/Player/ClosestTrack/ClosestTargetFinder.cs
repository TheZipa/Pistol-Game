using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace PistolGame.Code.Core.Player.ClosestTrack
{
    public class ClosestTargetFinder : MonoBehaviour
    {
        private Player _player;
        private Transform[] _targets;

        private NativeArray<Vector3> _targetPositions;
        private NativeArray<float> _distances;
        private NativeArray<float> _minDistance;
        private NativeArray<int> _closestIndex;
        
        public void Construct(Player player, Transform[] targets)
        {
            _player = player;
            _targets = targets;
            _targetPositions = new NativeArray<Vector3>(targets.Length, Allocator.Persistent);
            _distances = new NativeArray<float>(targets.Length, Allocator.Persistent);
            _minDistance = new NativeArray<float>(1, Allocator.Persistent);
            _closestIndex = new NativeArray<int>(1, Allocator.Persistent);
        }

        private void Update()
        {
            int lastClosestIndex = _closestIndex[0];
            _minDistance[0] = float.MaxValue;
            FillEnemyPositions();
            StartSearchJobs();

            if (lastClosestIndex == _closestIndex[0]) return;
            SwapEnemyTarget();
        }

        private void FillEnemyPositions()
        {
            for (int i = 0; i < _targetPositions.Length; i++) 
                _targetPositions[i] = _targets[i].transform.position;
        }

        private void StartSearchJobs()
        {
            CalculateDistancesJob distancesJob = CreateCalculateDistancesJob();
            JobHandle distanceJobHandle = distancesJob.Schedule(_targets.Length, 4);
            FindClosestTargetJob findClosestTargetJob = CreateClosestEnemyJob();
            JobHandle closestEnemyHandle = findClosestTargetJob.Schedule(distanceJobHandle);
            distanceJobHandle.Complete();
            closestEnemyHandle.Complete();
        }

        private CalculateDistancesJob CreateCalculateDistancesJob() => new()
        {
            EnemyPositions = _targetPositions,
            PlayerPosition = _player.transform.position,
            Distances = _distances
        };

        private FindClosestTargetJob CreateClosestEnemyJob() => new()
        {
            Distances = _distances,
            ClosestTargetIndex = _closestIndex,
            MinDistance = _minDistance
        };

        private void SwapEnemyTarget() => _player.SetFocusEnemy(_targets[_closestIndex[0]].transform);

        private void OnDestroy()
        {
            _targetPositions.Dispose();
            _minDistance.Dispose();
            _closestIndex.Dispose();
            _distances.Dispose();
        }
    }
}