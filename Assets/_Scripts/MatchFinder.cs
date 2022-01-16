using System;
using System.Collections.Generic;
using UnityEngine;

public class MatchFinder : MonoBehaviour
{
    private HashSet<Tile> _searchingTiles = new HashSet<Tile>();
    private float _score;
    public static event Action<int> OnScore;

    private void OnEnable()
    {
        Tile.OnTileClicked += TileClicked;
    }

    private void OnDisable()
    {
        Tile.OnTileClicked -= TileClicked;    
    }
    
    private void TileClicked(Tile tile)
    {
        RecursiveSearch(tile);
        ClearTileFlagsAfterSearch();
        CheckForScoreCondition();

        _searchingTiles.Clear();
    }

    void ClearTileFlagsAfterSearch()
    {
        foreach (var t in _searchingTiles)
        {
            t.isVisited = false;
        }
    }
    
    private void CheckForScoreCondition()
    {
        if (_searchingTiles.Count >= 3)
        {
            _score++;
            foreach (var t in _searchingTiles)
            {
                t.isChecked = false;
            }
        }
    }

    void RecursiveSearch(Tile tile)
    {
        tile.isVisited = true;
        _searchingTiles.Add(tile);
        Tile left = tile.leftNeighbour;
        Tile right = tile.rightNeighbour;
        Tile up = tile.upNeighbour;
        Tile down = tile.downNeighbour;

        if(left != null && !left.isVisited && left.isChecked)
            RecursiveSearch(left);
        if(right != null && !right.isVisited && right.isChecked)
            RecursiveSearch(right);
        if(up != null && !up.isVisited && up.isChecked)
            RecursiveSearch(up);
        if(down != null && !down.isVisited && down.isChecked)
            RecursiveSearch(down);
    }

    public void ResetScore()
    {
        _score = 0;
    }
}