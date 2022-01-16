using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private InputField _scoreConditionInputField,_boardSizeInputField;
    [SerializeField] private Text _scoreText;
    private int _scoreCondition = 3, _boardSize = 6;
    public static event Action<int,int> OnRebuild;

    private void OnEnable()
    {
        MatchFinder.OnScore += UpdateScore;
    }

    private void OnDisable()
    {
        MatchFinder.OnScore -= UpdateScore;
    }

    public void OnBoardSizeChanged()
    {
        string size = _boardSizeInputField.text;
        if (int.TryParse(size, out int boardSize) && boardSize > 0)
        {
            _boardSize = boardSize;
        }
        
    }
    
    public void OnScoreConditionChanged()
    {
        string score = _scoreConditionInputField.text;
        if (int.TryParse(score, out int scoreCondition) && scoreCondition > 0)
            _scoreCondition = scoreCondition;
    }

    public void RebuildPressed()
    {
        _scoreConditionInputField.text = _scoreCondition.ToString();
        _boardSizeInputField.text = _boardSize.ToString();
        UpdateScore(0);
        OnRebuild?.Invoke(_boardSize,_scoreCondition);
    }

    private void UpdateScore(int score)
    {
        _scoreText.text = $"Score : {score}";
    }
}
