using UnityEngine;

namespace JGM.Gameplay.Turrets.Projectiles
{
    [CreateAssetMenu(fileName = "New Projectile Config", menuName = "Projectile Config")]
    public class ProjectileConfig : ScriptableObject
    {
        public float MoveSpeed = 10f;
        public int DamageAmount = 1;
    }
}
