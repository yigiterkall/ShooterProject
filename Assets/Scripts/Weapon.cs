using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotDot;
    public float timeBtwShots;
    private float shotTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 drection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(drection.y, drection.x) * Mathf.Rad2Deg;
        Quaternion rotate = Quaternion.AngleAxis(angle -90, Vector3.forward);
        transform.rotation = rotate;

        if (Input.GetMouseButton(0))
        {
            if(Time.time >= shotTime)
            {
                Instantiate(projectile, shotDot.position, transform.rotation);
                shotTime = Time.time + timeBtwShots;
            }
        }
    }
}
