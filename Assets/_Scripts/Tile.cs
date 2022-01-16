using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject _cross;
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

    private void OnMouseDown()
    {
        isChecked = !_isChecked;
        if(isChecked)
            OnTileClicked?.Invoke(this);
    }
}