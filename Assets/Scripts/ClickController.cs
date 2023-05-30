using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickController : MonoBehaviour, IPointerDownHandler
{
    int _pullValue;
    bool _isAI, _isBot;

    

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isAI) return;
        Pull();
    }
    void Start()
    {
        if (gameObject.name.Contains("Bot")) _isBot = true;
        _pullValue = GameManager.Instance.pullPower;
        if(gameObject.name.Contains("Top")) _isAI = true;
        if (_isAI) StartCoroutine(AutoClick());
        if(_isBot) _pullValue *= -1; 
    }
    
    IEnumerator AutoClick()
    {
        while (true)
        {
            var data = GameManager.Instance.rangeDelayAI;
            var second = Random.Range(data.x, data.y);
            yield return new WaitForSeconds(second);
            Pull();
        }
    }

    void Pull()
    {
        RopeController.Instance.Value += _pullValue;
    }
}
