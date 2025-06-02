using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private TopDownMover2D _mover;
    // Start is called before the first frame update
    void Start()
    {
        _mover = GetComponent<TopDownMover2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(h, v);
        _mover.UpdateDirection(dir);
    }
}
