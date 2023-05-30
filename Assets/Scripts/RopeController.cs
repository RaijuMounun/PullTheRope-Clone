using System;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    public static RopeController Instance { get; private set; }
    public int Value{get; set;}
    Vector2 _minMaxVerticalPosition;
    
    Transform _topLine, _botLine;
    public Vector2 minMaxValue;

    void Awake()
    {
        var parent = transform.parent;
        if (Instance == null) Instance = this;
        _topLine = parent.GetChild(1);
        _botLine = parent.GetChild(2);
        _minMaxVerticalPosition = new Vector2(_botLine.position.y, _topLine.position.y);
    }

    private void FixedUpdate()
    {
        SetPos();
        IsGameOver();
    }

    void SetPos()
    {
        var position = transform.position;
        var normalize = Mathf.InverseLerp(minMaxValue.x, minMaxValue.y, Value);
        var verticalPosition = Mathf.Lerp(_minMaxVerticalPosition.x, _minMaxVerticalPosition.y, normalize);
        var currentVerticalPosition = Mathf.Lerp(transform.position.y, verticalPosition, .1f);
        position.y = currentVerticalPosition;
        transform.position = position;
    }
    
    void IsGameOver()
    {
        if (!(Math.Abs(Math.Abs(transform.position.y) - Math.Abs(_minMaxVerticalPosition.y)) < .05f)) return;
        if(transform.position.y > 0) print("Top Win");
        else print("Bot Win");
        Time.timeScale = 0;
    }
    
    
}
