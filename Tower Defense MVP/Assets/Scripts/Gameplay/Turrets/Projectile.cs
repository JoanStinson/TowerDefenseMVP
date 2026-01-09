using System;
using UnityEngine;

namespace JGM.Gameplay.Turrets
{
    public class Projectile : MonoBehaviour
    {
        private Transform target;
        private float speed = 7f;

        public void SetTarget(Transform target)
        {
            this.target = target;
            Destroy(gameObject, 10);
        }

        private void Update()
        {
            if (target == null)
            {
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
