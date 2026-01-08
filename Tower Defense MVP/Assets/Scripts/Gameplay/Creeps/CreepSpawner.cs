using UnityEngine;

namespace JGM.Gameplay.Creeps
{
    public class CreepSpawner : MonoBehaviour
    {
        [SerializeField] private Creep creepPrefab;
        [SerializeField] private Transform[] spawnPoints;

        public void Spawn()
        {
            GameObject.Instantiate(creepPrefab, spawnPoints[1], false);
        }
    }
}
