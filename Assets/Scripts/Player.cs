using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("raycast")]
    public Transform origin;
    public Vector2 direction;
    public float distance;
    public LayerMask layermask;
    [Header("Colors")]
    public Color collisionColor;
    public Color noCollisionColor;

    float Horizontal;
    float Vertical;
    public float velocity=5;
    Rigidbody2D _componentRigibody;
    SpriteRenderer _componentSprite;
    public GameObject player; 

    // Start is called before the first frame update
    void Start()
    {
        _componentRigibody = GetComponent<Rigidbody2D>();
        _componentSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        Vector2 directions = new Vector2(Horizontal,Vertical);
        Raycast(directions);
    }
    private void FixedUpdate()
    {
        _componentRigibody.velocity = new Vector2(Horizontal*velocity,Vertical*velocity);

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shape")
        {
            _componentSprite.sprite = collision.GetComponent<SpriteRenderer>().sprite;
        }
        if (collision.tag == "Color")
        {
            _componentSprite.color = collision.GetComponent<SpriteRenderer>().color;
        }
    }
    public void Raycast(Vector2 newdirection)
    {
        direction = newdirection;
        RaycastHit2D hit = Physics2D.Raycast(origin.position, direction, distance, layermask);
        if(hit.collider != null)
        {
            Debug.DrawRay(origin.position, direction * hit.distance, collisionColor);
            Debug.Log("object: " + hit.collider.name + "/ position: " + hit.collider.transform.position.x +
                " " + hit.collider.transform.position.y + " " + hit.collider.tag);
            if (hit.collider.tag=="Shape")
            {
                Debug.Log("object color");
            }
            else if (hit.collider.tag=="Color")
            {
                Debug.Log("object sprite");
            }
        }
        else
        {
            Debug.DrawRay(origin.position, direction*distance, noCollisionColor);
        }
    }
}
