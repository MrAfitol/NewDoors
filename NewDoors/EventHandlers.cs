namespace NewDoors
{
    using Mirror;
    using PluginAPI.Core.Attributes;
    using PluginAPI.Enums;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public class EventHandlers
    {
        private List<GameObject> spawnedDoors = new List<GameObject>();

        [PluginEvent(ServerEventType.RoundStart)]
        public void OnRoundStarted()
        {
            SpawnDoors();
        }

        public void SpawnDoors()
        {
            if (NewDoors.Instance.Config.IsEnabledDoor1)
            {
                SpawnDoor(new Vector3(10.474f, 996.468f, -16.942f), new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 1.5f), 2);
            }

            if (NewDoors.Instance.Config.IsEnabledDoor2)
            {
                SpawnDoor(new Vector3(10.474f, 996.468f, -31.65f), new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 1.4f), 2);
            }

            if (NewDoors.Instance.Config.IsEnabledDoor3)
            {
                SpawnDoor(new Vector3(126.87f, 987.793f, 21.164f), new Vector3(0f, 90f, 0f), new Vector3(1f, 1f, 1.3f), 2);
            }

            if (NewDoors.Instance.Config.IsEnabledDoor4)
            {
                SpawnDoor(new Vector3(128.186f, 987.793f, 25.63f), new Vector3(0f, 180f, 0f), new Vector3(1f, 1f, 1.35f), 2);
            }
        }

        public void SpawnDoor(Vector3 position, Vector3 rotation, Vector3 scale, int doorType = 0)
        {
            MapGeneration.DoorSpawnpoint prefab = null;

            switch (doorType)
            {
                case 0: prefab = UnityEngine.Object.FindObjectsOfType<MapGeneration.DoorSpawnpoint>().First(x => x.TargetPrefab.name.Contains("LCZ")); break;
                case 1: prefab = UnityEngine.Object.FindObjectsOfType<MapGeneration.DoorSpawnpoint>().First(x => x.TargetPrefab.name.Contains("HCZ")); break;
                case 2: prefab = UnityEngine.Object.FindObjectsOfType<MapGeneration.DoorSpawnpoint>().First(x => x.TargetPrefab.name.Contains("EZ")); break;
            }

            var door = UnityEngine.Object.Instantiate(prefab.TargetPrefab, position, Quaternion.Euler(rotation));


            door.transform.localScale = scale;


            spawnedDoors.Add(door.gameObject);
            NetworkServer.Spawn(door.gameObject);
        }
    }
}
