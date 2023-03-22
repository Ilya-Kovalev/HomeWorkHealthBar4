using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthChanger : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;
   
    private float _amountOfChangePerClick = 10;
    private float _timeForChange = 0.001f;

    public void Start()
    {
        _slider.value = _player.GetHealth();
    }

    public void SynchronizeInterface(int directionOfChange) 
    { 
        StartCoroutine(SetSliderValue(directionOfChange));      
    }

    private IEnumerator SetSliderValue(int directionOfChange) 
    {
        float currentValue = _slider.value;
        float targetValue = _player.GetHealth();
        var waightForSomeSeconds = new WaitForSeconds(_timeForChange);
        float time = 0;

        while(_slider.value != _player.GetHealth()) 
        {
            _slider.value = Mathf.MoveTowards(currentValue, targetValue, _amountOfChangePerClick * time);
            time += Time.deltaTime;

            yield return waightForSomeSeconds;
        }
    }
}   


