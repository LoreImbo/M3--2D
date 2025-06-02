using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMover2D : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    private Rigidbody2D _rb;
    private Vector2 _direction;

    public void UpdateDirection(Vector2 direction)
    {
        float lenght = direction.magnitude; // si può fare anche float sqrLenght = direction.sqrMagnitude perché calcolare radice quadrata è più complesso 
        if (lenght > 1)  // poi andrebbe fatto sqrLenght > 1
        {
            direction /= lenght; // e qua dividere per Mathf.sqr(sqrLenght)
        }
        _direction = direction;
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void FixedUpdate() // meglio FixedUpdate di Update
    {
        if (_direction != Vector2.zero)
        {
            _rb.MovePosition(_rb.position + _direction * (_speed * Time.deltaTime));
        }
    }
}
