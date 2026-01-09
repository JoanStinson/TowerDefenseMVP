using JGM.Gameplay.Creeps;
using UnityEngine;

namespace JGM.Gameplay.Turrets
{
    public interface ITurret
    {
        GameObject GameObject { get; }

        void Initialize(CreepSpawner creepSpawner);
    }
}
