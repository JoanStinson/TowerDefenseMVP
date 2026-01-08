using JGM.Gameplay.Base;
using UnityEngine;

namespace JGM.Gameplay.Creeps
{
    public class CreepModel
    {
        public Transform Target { get; }
        public float Speed { get; }
        public float StopDistance { get; }
        public PlayerBase PlayerBase { get; }
        public float HitDelay { get; }

        public CreepModel(Transform target, float speed, float stopDistance, PlayerBase playerBase, float hitDelay)
        {
            Target = target;
            Speed = speed;
            StopDistance = stopDistance;
            PlayerBase = playerBase;
            HitDelay = hitDelay;
        }
    }
}
