using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownDemo : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private float _cooldownDuration;


    private void Update()
    {
        //if(timer.IsRunning)
            image.fillAmount = timer.GetRatioComplete();
    }

    public void OnUseSkill()
    {
        Debug.Log("OnUseSkill");
        timer.Duration = _cooldownDuration;
        timer.StartTimer();
    }
    
}
