using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BALL : MonoBehaviour
{
    bool _shot = false;
    int _power = 0;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_shot);
        Debug.Log(_power);
        if(_power >= 50)
        {
            _power = 50;
        }
        if (_shot)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _rb.AddForce(Vector2.up * _power, ForceMode2D.Impulse);
                _power = 0;
            }
        }
    }
    private void FixedUpdate()
    {
        if (_shot)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                _power += 1;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("shot"))
        {
            _shot = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("shot"))
        {
            _shot = false;
        }
    }
}
