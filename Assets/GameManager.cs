using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int targetFrameRate = 60;
    [SerializeField]
    private float _fireRate = 1.0f;

    private static GameManager instance;

    public static GameManager Instance { get => instance; set => instance = value; }
    public float FireRate { get => _fireRate; set => _fireRate = value; }

    void Awake()
    {
        Instance = this;
        Application.targetFrameRate = targetFrameRate;
    }
}
