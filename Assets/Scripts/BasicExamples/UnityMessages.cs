using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityMessages : MonoBehaviour
{

    private void Awake()
    {
        Debug.Log($"Awake() di {gameObject.name}");
    }

    void Start()
    {
        Debug.Log($"Start() di {gameObject.name}");
    }

    private void OnEnable()
    {
        Debug.Log($"OnEnable() di {gameObject.name}");
    }

    private void OnDisable()
    {
        Debug.Log($"OnDisable() di {gameObject.name}");
    }

    private void OnDestroy()
    {
        Debug.Log($"OnDestroy() di {gameObject.name}");
    }

    private void OnBecameVisible()
    {
        Debug.Log($"OnBecameVisible() di {gameObject.name}");
    }

    private void OnBecameInvisible()
    {
        Debug.Log($"OnBecameInvisible() di {gameObject.name}");
    }

    //void Update()
    //{
    //    Debug.Log($"Update() di {gameObject.name}");
    //}

    //void LateUpdate()
    //{
    //    Debug.Log($"LateUpdate() di {gameObject.name}");
    //}

    //void FixedUpdate()
    //{
    //    Debug.Log($"FixedUpdate() di {gameObject.name}");
    //}
}
