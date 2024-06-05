using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float speed = 5.0f;
    public Vector3 mousePosition;

    float lifetime = 3.0f;
    
    public void Initialise()
    {
        //Get the mouse position in the world spce
        mousePosition.z = 0f;

        //Calculate the direction from the current position to the mouse position
        Vector3 direction = (mousePosition - transform.position).normalized;

        //Move theobject towards the mouse position
        GetComponent<Rigidbody2D>().velocity = direction * speed;

        //Rotate the object towards the mouse position
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        lifetime = 3.0f;
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;

        if(lifetime < 0.0f)
        {
            ObjectPooler.EnqueueObject(this, "Bullet");
        }
    }

    
}
