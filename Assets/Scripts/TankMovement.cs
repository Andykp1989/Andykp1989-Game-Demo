using UnityEngine;

public class TankMovement : MonoBehaviour
{
    // Speed of the tank
    public float speed = 5f;


    //input for moving the tank to the left and right
    void Update()
    {


        //move the tank right.
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        //move the tank left.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

            //make the tank jump when space is pressed
            if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
}
