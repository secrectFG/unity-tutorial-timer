using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    enum FireMode
    {
        Mode1 = 0,
        Mode2,
        Mode3,
        Mode4,
        Mode5,
        Mode6,
    }

    [SerializeField]
    private BulletController _bulletController;
    [SerializeField]
    private FireMode _fireMode = FireMode.Mode1;
    [SerializeField]
    private Transform _firePoint;
    private float _time = 0f;

    private float _fireCycle = 0f;

    private int bulletCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        _fireCycle = 1 / GameManager.Instance.FireRate;
        _time = _fireCycle;
        if (_fireMode == FireMode.Mode3 || _fireMode == FireMode.Mode4)
        {
            _time = Time.time - _fireCycle;
        }
        if(_fireMode == FireMode.Mode5)
        {
            StartCoroutine(FireMode5());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (_fireMode)
        {
            case FireMode.Mode1:
                FireMode1();
                break;
            case FireMode.Mode2:
                FireMode2();
                break;
            case FireMode.Mode3:
                FireMode3();
                break;
            case FireMode.Mode4:
                FireMode4();
                break;
        }
    }

    void FireMode1()
    {
        _time += Time.deltaTime;
        if (_time > _fireCycle)
        {
            _time = 0;
            DoFire();
        }
    }

    void FireMode2()
    {
        _time += Time.deltaTime;
        if (_time > _fireCycle)
        {
            _time -= _fireCycle;
            DoFire();
        }
    }

    void FireMode3()
    {
        if(Time.time - _time >= _fireCycle)
        {
            _time = Time.time;
            DoFire();
        }
    }

    void FireMode4()
    {
        var dt = Time.time - _time - _fireCycle;
        if (dt >= 0)
        {
            _time = Time.time - dt;
            DoFire();
        }
    }

    IEnumerator FireMode5()
    {
        while (true)
        {
            DoFire();
            yield return new WaitForSeconds(_fireCycle);
        }
    }

    void DoFire()
    {
        bulletCount++;
        var bulletController = Instantiate(_bulletController);
        bulletController.transform.SetParent(_firePoint);
        bulletController.transform.localRotation = Quaternion.identity;
        bulletController.transform.position = _firePoint.position;
        bulletController.Fire();
        bulletController.GetComponentInChildren<TextMeshProUGUI>().text = bulletCount.ToString();
    }
}
