using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Board _board;
    void Start()
    {
        _board.Initialize();
    }

    private void OnEnable()
    {
        UIManager.OnRebuild += Rebuild;
    }

    private void OnDisable()
    {
        UIManager.OnRebuild -= Rebuild;
    }

    private void Rebuild(int size,int scoreCondition)
    {
        _board.Restart(size,scoreCondition);
    }
}