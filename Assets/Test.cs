using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private CoolDownDemo _timerTest;
    private Timer _timer;
    private void Start()
    {
        _timerTest = GetComponent<CoolDownDemo>();
        _timer = GameObject.Find("Timer").GetComponent<Timer>();
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 50), "ʹ�ü���"))
        {
            _timerTest.OnUseSkill();
        }
        if (GUI.Button(new Rect(10, 60, 100, 50), "����Buff"))
        {
            _timer.TimeScale = 3;
            _timer.Complete = () =>
            {
                _timer.TimeScale = 1;
            };
        }

    }
}
