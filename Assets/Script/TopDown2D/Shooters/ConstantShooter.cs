using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantShooter : AbstractShooter
{
    [SerializeField] private Transform _spawnPoint; // è lo spawn point dei proiettili

    private void Update()
    {
        TryShoot(_spawnPoint.position, _spawnPoint.up); // il .up è la direzione che sta guardando l'oggetto (la freccia verde)
        
    }
}
