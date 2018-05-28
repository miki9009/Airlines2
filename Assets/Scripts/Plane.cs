using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{


    Vector3 destination;
    public Vector3 Destination
    {
        get { return destination; }
        set { destination = value; }
    }

    public Airport StartAirport { get; set; }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, Controller.Instance.planeSpeed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(destination - transform.position);
    }

    public void SetFlight(Airport start, Airport destination)
    {
        transform.position = start.transform.position;
        this.destination = destination.transform.position;
        StartAirport = start;
    }


}
