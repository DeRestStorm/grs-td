using System;
using UnityEditor;
using UnityEngine;

namespace Behaviours
{
    public class Health: MonoBehaviour
    {
        public float MaxHealth = 100;
        public float CurrentHealth;

        private void Start()
        {
            CurrentHealth = MaxHealth;
        }

        public void Damage(float damage)
        {
            CurrentHealth -= damage;
            if(CurrentHealth <= 0)
                Destroy(gameObject);

        }
    }
}