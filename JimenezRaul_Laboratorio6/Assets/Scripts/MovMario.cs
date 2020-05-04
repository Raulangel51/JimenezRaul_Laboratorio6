using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovMario : MonoBehaviour
{
    //variables
    private Rigidbody2D rgb2d;
    public int force;
    public int jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(rgb2d)
        {
            Vector3 newScale = transform.localScale;
            if (Input.GetAxis("Horizontal") > 0) 
            {
                rgb2d.AddForce(new Vector2(Input.GetAxis("Horizontal") * force, 0));
                newScale.x = -8.0f;
            }
            if (Input.GetAxis("Horizontal") < 0) 
            {
                rgb2d.AddForce(new Vector2(Input.GetAxis("Horizontal") * force, 0));
                newScale.x = 8.0f;
            }
            if (Input.GetAxis("Vertical") > 0) 
            {
                jump();
            }
            transform.localScale = newScale;
            
        }
    }

    void jump()
    {
        if(rgb2d)
        {
            if (Mathf.Abs(rgb2d.velocity.y) < 0.25f)
            {
                rgb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }
}
