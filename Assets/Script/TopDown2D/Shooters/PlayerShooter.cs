using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : AbstractShooter
{
    private Camera _cam;

    private void Awake()
    {
        _cam = Camera.main; // non va bene quando la camera cambia   
    }

    // Update is called once per frame
    void Update() // mi serve per intercettare quando il giocatore preme per sparare
    {
        if (Input.GetMouseButtonDown(0))// && CanShot()) --> fz da aggiungere alla classe abstract di modo da evitare tutti questi calcoli e sparare solo quando si può
        {
            Vector3 screenPos = Input.mousePosition; // otteniamo le coordinate di dove sta il mouse in PIXEL --> il pixel in basso a sinistra è (0,0); in alto a destra è il valore max
                                                     // ora devo risalire alla posizione del mouse nella scena --> ho bisogno dell'oggetto CAMERA

            screenPos.z = _cam.nearClipPlane; // questo è il tema del near plane

            Vector3 worldPos = _cam.ScreenToWorldPoint(screenPos); // passo le coordinate dello schermo e restituisce le coordinate del mondo/scena
                                                                   // ha effetti diversi in base alla proiezione della camera (ortografica o prospettica) --> nel secondo caso usa la prospettiva
                                                                   // questa scelta influisce su come vengono restituite queste coordinate (near plane)

            worldPos.z = 0; // in un gioco 2D molto prob posso ridurre a 0 la Z
            worldPos.z = transform.position.z; // --> stessa coordinata Z di questo oggetto --> in questo caso è la stessa cosa

            Vector3 shootDirection = worldPos - transform.position; // transform.position è la posizione nostra dell'oggetto
            
            TryShoot(transform.position, shootDirection);
        }
    }
}
