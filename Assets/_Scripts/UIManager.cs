
using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static event Action<int> OnRebuild;

    private void OnEnable()
    {
        MatchFinder.OnScore += UpdateScore;
    }

    private void OnDisable()
    {
        MatchFinder.OnScore -= UpdateScore;
    }

    private void UpdateScore(int score)
    {
        
    }
}
