using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace PistolGame.Code.Core.Player.ClosestTrack
{
    public struct CalculateDistancesJob : IJobParallelFor
    {
        [ReadOnly] public NativeArray<Vector3> EnemyPositions;
        [ReadOnly] public Vector3 PlayerPosition;
        public NativeArray<float> Distances;

        public void Execute(int index)
        {
            Distances[index] = Vector3.Distance(PlayerPosition, EnemyPositions[index]);
        }
    }
}