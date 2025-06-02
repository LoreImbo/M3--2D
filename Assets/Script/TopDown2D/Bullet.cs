using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 3;
    [SerializeField] private float _lifeSpan = 5;
    [SerializeField] private float _speed = 5;

    public void Shoot(Vector3 origin, Vector3 direction)
    {
        transform.position = origin;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        Vector2 dir = direction; // conversione automatica da Vector3 a Vector2
        float sqrLenght = dir.sqrMagnitude;
        if (sqrLenght > 1)
        {
            dir /= Mathf.Sqrt(sqrLenght);
        }

        rb.velocity = dir * _speed;
    }

    void Start()
    {
        Destroy(gameObject, _lifeSpan);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Questo APPROCCIO è ottimo se siamo sicuri che il collider si trova sullo stesso GameObject che ha LifeController
        //LifeController life; // così è solo dichiarata
        //bool result = collision.collider.TryGetComponent<LifeController>(out life); // altro metodo --> modalità out significa che assegna il valore alla variabile life solo dichiarata --> con out non fa copia, ma modifica direttamente la stessa variabile (è l'opposto della keyword ref)
        // si può fare anche cosi --> bool result = collision.collider.TryGetComponent<LifeController>(out LifeController life); quindi senza dichiararla prima 
        // --> con questa casistica si può anche inserire direttamente come condizione dell'if dato che è un bool

        // Questo APPROCCIO è ottimo se il collider potrebbe essere su uno dei child del GameObject che ha il LifeController
        LifeController life = collision.collider.GetComponentInParent<LifeController>(); // cerca la componente su quel GameObject --> se non trovano niente, restituiscono null
        if (life != null)
        {
            life.AddHp(-_damage);
        }
        Destroy(gameObject); // si distrugge quando collide con qualcosa
    }
}
