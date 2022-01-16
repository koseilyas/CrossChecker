using System.Collections.Generic;
using UnityEngine;

public class Board :MonoBehaviour
{
    public Tile[,] tiles ;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField]private int _size ;
    private BoardBuilder _boardBuilder;

    private void Start()
    {
        tiles = new Tile[_size, _size];
        _boardBuilder = gameObject.AddComponent<BoardBuilder>();
        _boardBuilder.Initialize(this,_tilePrefab,_size);
    }
}
