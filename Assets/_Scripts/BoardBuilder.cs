using System.Collections.Generic;
using UnityEngine;

public class BoardBuilder : MonoBehaviour
{
    private Tile _tilePrefab;
    private int _size ;
    private Camera _camera;
    private Board _board;

    public void Initialize(Board board,Tile tilePrefab,int size)
    {
        _tilePrefab = tilePrefab;
        _size = size;
        _board = board;
        _camera = Camera.main;
        CreateBoard();
        SetTileRelations();
        CalculateAndSetPosition();
    }

    private void CreateBoard()
    {
        Vector3 tilePosition = new Vector3();
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                tilePosition.x = j;
                tilePosition.y = i;
                Tile tile = Instantiate(_tilePrefab, transform);
                tile.name = $"Tile_{i}x{j}";
                tile.transform.position = tilePosition;
                _board.tiles[i, j] = tile;
            }
        }
    }

    private void SetTileRelations()
    {
        for (int i = 0; i < _size; i++)
        {
            for (var j = 0; j < _size; j++)
            {
                Tile tile = _board.tiles[i, j];
                if (i > 0)
                {
                    tile.downNeighbour = _board.tiles[i - 1, j];
                    _board.tiles[i - 1, j].upNeighbour = tile;
                }

                if (j > 0)
                {
                    tile.leftNeighbour = _board.tiles[i, j - 1];
                    _board.tiles[i, j - 1].rightNeighbour = tile;
                }
            }
        }
    }


    private void CalculateAndSetPosition()
    {
        _camera.orthographicSize = _size;
        Vector3 upperCenterPosition = new Vector3((_size / 2f) - .5f, (_size / 2f) - .5f, 0);
        upperCenterPosition = new Vector3(upperCenterPosition.x, upperCenterPosition.y - (_size / 2.5f), 0);
        Vector3 currentPosition = transform.position;
        transform.position = new Vector3(currentPosition.x - upperCenterPosition.x, currentPosition.y - upperCenterPosition.y, 0);
    }
}