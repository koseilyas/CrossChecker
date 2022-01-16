using System.Collections.Generic;
using UnityEngine;

public class Board :MonoBehaviour
{
    public Tile[,] tiles ;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField]private int _size ;
    private BoardBuilder _boardBuilder;
    private MatchFinder _matchFinder;

    public void Initialize()
    {
        tiles = new Tile[_size, _size];
        _boardBuilder = gameObject.AddComponent<BoardBuilder>();
        _matchFinder = gameObject.AddComponent<MatchFinder>();
        _boardBuilder.Initialize(this,_tilePrefab,_size);
    }

    public void Restart(int size, int scoreCondition)
    {
        _boardBuilder.RemoveTiles();
        _size = size;
        tiles = new Tile[_size, _size];
        _boardBuilder.Initialize(this,_tilePrefab,_size);
        _matchFinder.ResetScore(scoreCondition);
    }
}
