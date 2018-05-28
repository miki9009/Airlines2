using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airport : MonoBehaviour
{


    public string Name
    {
        get
        {
            return gameObject.name;
        }
    }

    public float Scale
    {
        get
        {
            return transform.localScale.magnitude;
        }

        set
        {
            transform.localScale = Vector3.one * value;
        }
    }

    public Vector2 Position
    {
        get
        {
            return new Vector2(transform.position.x, transform.position.z);
        }

        set
        {
            transform.position = value;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.layer == Layer.PLANE)
        {
            var plane = other.GetComponent<Plane>();
            if (plane.StartAirport != null && plane.StartAirport != this)
                 Destroy(other.gameObject);
        }
    }


    private void Awake()
    {
        Controller.airports.Add(this);
    }




}
