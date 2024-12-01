using Mirror;
using PluginAPI.Core.Attributes;
using PluginAPI.Events;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NewDoors
{
    public class EventHandlers
    {
        private List<GameObject> spawnedDoors = new List<GameObject>();

        [PluginEvent]
        public void OnRoundStart(RoundStartEvent ev)
        {
            spawnedDoors.Clear();
            SpawnDoors();
        }

        public void SpawnDoors()
        {
            if (NewDoors.Instance.Config.IsEnabledDoor1)
                SpawnDoor(new Vector3(10.474f, 996.468f, -16.942f), new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 1.5f), 2);
            if (NewDoors.Instance.Config.IsEnabledDoor2)
                SpawnDoor(new Vector3(10.474f, 996.468f, -31.65f), new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 1.4f), 2);
            if (NewDoors.Instance.Config.IsEnabledDoor3)
                SpawnDoor(new Vector3(128.186f, 987.793f, 25.63f), new Vector3(0f, 180f, 0f), new Vector3(1f, 1f, 1.35f), 2);
        }

        public void SpawnDoor(Vector3 position, Vector3 rotation, Vector3 scale, int doorType = 0)
        {
            GameObject prefab = null;

            switch (doorType)
            {
                case 0: prefab = NetworkClient.prefabs.Values.First(x => x.name == "LCZ BreakableDoor"); break;
                case 1: prefab = NetworkClient.prefabs.Values.First(x => x.name == "HCZ BreakableDoor"); break;
                case 2: prefab = NetworkClient.prefabs.Values.First(x => x.name == "EZ BreakableDoor"); break;
            }

            var door = UnityEngine.Object.Instantiate(prefab, position, Quaternion.Euler(rotation));
            door.transform.localScale = scale;

            spawnedDoors.Add(door.gameObject);
            NetworkServer.Spawn(door.gameObject);
        }
    }
}
