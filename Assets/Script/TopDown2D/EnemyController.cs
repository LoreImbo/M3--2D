using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private TopDownMover2D _mover;
    //private PlayerController _player;
    [SerializeField] private Transform _target; // in questo modo si inizializza una variabile _target che può appunto cambiare volendo
    // Start is called before the first frame update
    void Start()
    {
        _mover = GetComponent<TopDownMover2D>();
        //_player = FindAnyObjectByType<PlayerController>(FindObjectsInactive.Include);

        if (_target == null)
        {
            PlayerController player = FindAnyObjectByType<PlayerController>(FindObjectsInactive.Include);
            _target = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (_player == null) return;
        //_mover.UpdateDirection(_player.transform.position - _mover.transform.position);

        if (_target == null) return;
        _mover.UpdateDirection(_target.position - _mover.transform.position);

    }
}
