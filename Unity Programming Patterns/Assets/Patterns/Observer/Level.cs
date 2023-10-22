using System.Collections;
using Patterns.Observer;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour {

    [SerializeField] int pointsPerLevel = 200;
    [SerializeField] private UnityEvent onLevelUp;
    int experiencePoints = 0;

    private IEnumerator Start() {
        while (true) {
            yield return new WaitForSeconds(.2f);
            GainExperience(10);
        }
    }

    private void GainExperience(int points) { 
        var level = GetLevel();
        experiencePoints += points;
        if (GetLevel() > level) {
            onLevelUp.Invoke();
        }
    }

    public int GetExperience() {
        return experiencePoints;
    }

    public int GetLevel() {
        return experiencePoints / pointsPerLevel;
    }
}