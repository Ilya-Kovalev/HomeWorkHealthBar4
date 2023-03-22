using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonActivityDefiner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _buttonTreatment;
    [SerializeField] private Button _buttonDamage;

    private float _minHealth = 0;
    private float _maxHealth = 100;

    public void SynchronizeActivity() 
    {
        DefineButtonActivity(_buttonTreatment, _maxHealth);
        DefineButtonActivity(_buttonDamage, _minHealth);
    }

    private void DefineButtonActivity(Button button, float limitValue)
    {
        button.interactable = true;
        float playerHealth = _player.GetHealth();

        if(playerHealth == limitValue) 
        {
            button.interactable = false;
        }
    }
}
