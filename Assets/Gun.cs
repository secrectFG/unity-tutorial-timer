using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    enum FireMode
    {
        Mode1 = 0,
        Mode2 = 1,
    }

    [SerializeField]
    private BulletController _bulletController;
    [SerializeField]
    private FireMode _fireMode = FireMode.Mode1;
    [SerializeField]
    private Transform _firePoint;
    private float _time = 0f;

    private float _fireCycle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        _fireCycle = 1 / GameManager.Instance.FireRate;
        _time = _fireCycle;
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

    void DoFire()
    {
        var bulletController = Instantiate(_bulletController);
        bulletController.transform.SetParent(_firePoint);
        bulletController.transform.localRotation = Quaternion.identity;
        bulletController.transform.position = _firePoint.position;
        bulletController.Fire();
    }
}
