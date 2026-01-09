using UnityEngine;

namespace JGM.Gameplay.Turrets.Projectiles
{
    public interface IProjectile
    {
        GameObject GameObject { get; }

        void Initialize(Transform target);
    }
}
