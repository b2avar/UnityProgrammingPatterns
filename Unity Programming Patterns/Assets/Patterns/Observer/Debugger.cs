using System.Collections;
using UnityEngine;

namespace Patterns.Observer {
    public class Debugger : MonoBehaviour {
        private IEnumerator Start() {
            var health = GetComponent<Health>();
            var level = GetComponent<Level>();
            while (true) {
                yield return new WaitForSeconds(1);
                Debug.Log($"Exp: {level.GetExperience()}, Level: {level.GetLevel()}, Health: {health.GetHealth()}");
            }
        }
    }
}