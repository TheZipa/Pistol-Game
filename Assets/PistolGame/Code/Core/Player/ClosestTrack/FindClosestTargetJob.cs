using Unity.Collections;
using Unity.Jobs;

namespace PistolGame.Code.Core.Player.ClosestTrack
{
    public struct FindClosestTargetJob : IJob
    {
        [ReadOnly] public NativeArray<float> Distances;
        public NativeArray<int> ClosestTargetIndex;
        public NativeArray<float> MinDistance;

        public void Execute()
        {
            float minDist = float.MaxValue;
            int index = -1;

            for (int i = 0; i < Distances.Length; i++)
            {
                if (!(Distances[i] < minDist)) continue;
                minDist = Distances[i];
                index = i;
            }

            MinDistance[0] = minDist;
            ClosestTargetIndex[0] = index;
        }
    }
}