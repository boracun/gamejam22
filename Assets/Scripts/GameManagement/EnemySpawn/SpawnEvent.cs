using UnityEngine;

namespace GameManagement
{
    public struct SpawnEvent
    {
        public Vector2 spawnLocation;
        public float spawnDelay;
        public SpawnInfo spawnInfo;
        public float spawnTimer;
        public float spawnPlayerDistance;

        public float spawnDelayUpperLimit;
        public float spawnDelayLowerLimit;

        public SpawnEvent(Vector2 spawnLocation, float spawnDelay, SpawnInfo spawnInfo, float spawnTimer, 
            float spawnPlayerDistance, float spawnDelayLowerLimit, float spawnDelayUpperLimit)
        {
            this.spawnLocation = spawnLocation;
            this.spawnDelay = spawnDelay;
            this.spawnInfo = spawnInfo;
            this.spawnTimer = spawnTimer;
            this.spawnPlayerDistance = spawnPlayerDistance;
            this.spawnDelayLowerLimit = spawnDelayLowerLimit;
            this.spawnDelayUpperLimit = spawnDelayUpperLimit;
        }
    }
}