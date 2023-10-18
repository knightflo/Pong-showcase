using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddlecontroller : MonoBehaviour
{
    public float limit = 2.69f;
    public float speed = 6f;
    public string leftOrRightPaddle;

    void movepaddle(KeyCode up, KeyCode down)
    {
        if (Input.GetKey(up) && transform.position.y < limit)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(down) && transform.position.y > -limit)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(leftOrRightPaddle == "left")
        {
            //movepaddle(KeyCode.W, KeyCode.S);
            
            
            movepaddle(KeyCode.W,KeyCode.S);
            /*
            if (!Input.GetKey(KeyCode.Space)&& transform.position.y > -limit)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            */
        }
        else if (leftOrRightPaddle == "right")
        {
            movepaddle(KeyCode.UpArrow, KeyCode.DownArrow);
            /*
            if (!Input.GetKey(KeyCode.UpArrow) && transform.position.y > -limit)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            */
        }
    }
}
