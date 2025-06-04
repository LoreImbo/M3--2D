using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMover2D : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;

    [SerializeField] private float _speed;

    private Rigidbody2D _rb;
    private bool _jumpPressed = false;
    private float _jumpTimer = 0;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump")) // <- true nel frame in cui iniziamo a preme [SPACE]
        {
            Debug.Log("Jump Button Down");
            _jumpPressed = true;
            _jumpTimer += Time.deltaTime;

            // in un platformer potrei fare..
            //Vector2 velocity = _rb.velocity;
            //velocity.y = 5;
            //_rb.velocity = velocity;

            //_rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

        }
        else if (Input.GetButtonUp("Jump")) // <- true nel frame in cui rilasciamo [SPACE]
        {
            Debug.Log("Jump Button Up");
            _jumpPressed = false;
        }
        else if (_jumpPressed)
        {
            _jumpTimer += Time.deltaTime;
        }

        if (Input.GetButton("Jump")) // <- true in tutti i frame in cui sto tenendo premuto [SPACE]
        {
            Debug.Log("Jump Button Pressed");
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Get Mouse Button Down - LEFT BUTTON");
        }

        //Debug.Log("Mouse position " + Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Pressed [L]");
        }


        if (Input.GetButtonDown("Fire1"))
        {
            Bullet clone = Instantiate(_bulletPrefab); // <- clona il prefab e mette il clone in scena
            clone.transform.position = transform.position + Vector3.right * 1.5f; // <- lo spawno un po' a destra
            // e poi accedo al suo Rigidbody2D per applicare una "schicchera" (un impulso) verso destar
            Rigidbody2D bulletRb = clone.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(Vector3.right * 10, ForceMode2D.Impulse);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position += new Vector3(1, 0, 0); // <- si muove di 1 metro PER FRAME!

        //Vector3 movement = new Vector3(1, 0, 0);
        //movement = movement * Time.deltaTime; // <- diventa un movimento "al secondo"
        //transform.position += movement;

        //transform.position += new Vector3(1, 0, 0) * Time.deltaTime;

        float h = Input.GetAxis("Horizontal");  // <- -1 se l'utente preme sx, +1 se preme dx, 0 altrimenti
        float v = Input.GetAxis("Vertical"); // <- -1 se preme giù, +1 se preme su

        Vector2 dir = new Vector2(h, v);

        if (h != 0 || v != 0)
        {
            float length = dir.magnitude; // <- lunghezza del vettore

            if (length > 1)
            {
                //dir.Normalize(); // <- qui calcolerebbe di nuovo la lunghezza
                dir = dir / length; // <- allora normalizziamolo manualmente usando quella che avevamo gia' calcolato
            }

            // pos nuova       =    pos vecchia     + direzione * velocita' (al secondo)
            //transform.position = transform.position + dir * (_speed * Time.deltaTime);

            // Rigibody.MovePosition( Vector2 newPosition ); muove l'oggetto tramite Rigidbody ed e' piu' preciso nel valutare le collisioni
            //_rb.MovePosition( _rb.position + dir * (_speed* Time.deltaTime)); 
        }

        // Se stessimo facendo un Platformer
        //Vector2 velocity = _rb.velocity;
        //velocity.x = dir.x * _speed; // <- NON METTO Time.deltaTime, perche' velocity e' gia' una velocita' AL SECONDO
        //_rb.velocity = velocity; // <- avendo modificato solo x non perdo le informazioni della gravita'

        // Per un topdown
        Vector2 velocity = dir * _speed; // <- NON METTO Time.deltaTime, perche' velocity e' gia' una velocita' AL SECONDO
        _rb.velocity = velocity; // <- sostituisco sia x che y
    }
}
