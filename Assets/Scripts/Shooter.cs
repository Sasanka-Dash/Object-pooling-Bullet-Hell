using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public BulletController bullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            BulletController instance = ObjectPooler.DequeueObject<BulletController>("Bullet");
            instance.gameObject.SetActive(true);
            instance.Initialise();
            instance.mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
