using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractShooter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab; // questo si collega alla cartella Assets di unity --> NON VA SOVRASCRITTO
    [SerializeField] private float _shotInterval = 0.5f; // quanti secondi devono passare tra uno sparo e l'altro

    private float _shotTimer = 0;

    private void Update()
    {
        if (_shotTimer < _shotInterval)
        {
            _shotTimer += Time.deltaTime;
        }
    }
    public void TryShoot(Vector3 position, Vector3 direction)
    {
        if (_shotTimer < _shotInterval) return; // --> voglio che la funzione non ritorni nulla

        _shotTimer -= _shotInterval; // potrei anche mettere _shotTimer = 0 di modo da resettare il timer

        // questo crea il riferimento
        Bullet b = Instantiate(_bulletPrefab); // istanzia o clona l'oggetto e ci ritorna il riferimento
        b.Shoot(position, direction);
        
    }
}
