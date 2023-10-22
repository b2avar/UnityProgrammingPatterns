using System;
using System.Collections;
using UnityEngine;

namespace Patterns.Observer {
    public class Health : MonoBehaviour {
        [SerializeField] private float fullHealth = 100f;
        [SerializeField] private float drainPerSecond = 2f;
        private float _currentHealth = 0;

        private void Awake() {
            ResetHealth();
            StartCoroutine(HealthDrain());
        }

        private void OnEnable() {
            GetComponent<Level>().OnLevelUpAction += ResetHealth;
        }
        
        private void OnDisable() {
            GetComponent<Level>().OnLevelUpAction -= ResetHealth;
        }

        public float GetHealth() {
            return _currentHealth;
        }

        void ResetHealth() {
            _currentHealth = fullHealth;
        }

        private IEnumerator HealthDrain() {
            while (_currentHealth > 0) {
                _currentHealth -= drainPerSecond;
                yield return new WaitForSeconds(1);
            }
        }
    }
}