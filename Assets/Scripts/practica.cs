using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class practica : MonoBehaviour
{
    [Header("4 points")]
    public Transform origin;
    public Vector2 direction;
    public float Distance;
    public LayerMask Layermask;

    [Header("colors")]
    public Color withCollision;
    public Color withoutCollision;

    float horizontal;
    float vertical;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector2 direcxtion = new Vector2(horizontal, vertical);
        Raycats(direcxtion);
    }
    void Raycats(Vector2 newDirection)
    {
        this.direction = newDirection;
        RaycastHit2D hit = Physics2D.Raycast(origin.position,this.direction,Distance,Layermask);
        if (hit.collider != null)
        {
            Debug.DrawRay(origin.position, direction * hit.distance, withCollision);
            Debug.Log("nombre: "+hit.collider.name+"posicion: "+hit.collider.transform.position.x+" "+hit.collider.transform.position.y+
                " Tag "+hit.collider.tag);
            if (hit.collider.tag == "Shape")
            {
                Debug.Log("objeto shape");
            }
            else if (hit.collider.tag=="color")
            {
                Debug.Log("fue a un color");
            }
        }
    }
}