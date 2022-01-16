using System;
using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Tile leftNeighbour, rightNeighbour, upNeighbour, downNeighbour;
    public bool isVisited;
    [SerializeField] private GameObject _cross;
    
    private static WaitForSeconds _animationTime = new WaitForSeconds(0.1f);
    private bool _isChecked;
    
    public static event Action<Tile> OnTileClicked; 
    public bool isChecked
    {
        get => _isChecked;
        set
        {
            _cross.SetActive(value);
            _isChecked = value;
        }
    }

    private IEnumerator OnMouseDown()
    {
        isChecked = !_isChecked;   
        yield return _animationTime;
        if(isChecked)
            OnTileClicked?.Invoke(this);

    }
}