using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsManager : MonoBehaviour
{
    [SerializeField] private Pickup[] _pickups;
    void Start()
    {
        _pickups = GetComponentsInChildren<Pickup>();
    }

}
