using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[DefaultExecutionOrder(-900)]
public class Controller : MonoBehaviour
{
    public static List<Airport> airports = new List<Airport>();

    public static Controller Instance { get; private set; }


    public float timeBetweenFlights = 1;
    public GameObject planePrefab;
    public float planeSpeed = 1;

    public static Airport GetAirport(int index)
    {
        if (index < airports.Count)
            return airports[index];
        else
            return airports[0];
    }

    private void Awake()
    {
        Instance = this;
    }


    void Start ()
    {
        StartCoroutine(Flights());
	}

    IEnumerator Flights()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenFlights);
            CreatePlane();
        }
    }

    void CreatePlane()
    {
        if (airports.Count < 2) return;
        var airport = airports[Random.Range(0, airports.Count - 1)];
        Airport destinationAirport = null;
        while (destinationAirport == null || destinationAirport == airport)
        {
            destinationAirport = airports[Random.Range(0, airports.Count - 1)];
        }
        var plane = Instantiate(planePrefab, airport.transform.position, Quaternion.identity).GetComponent<Plane>();
        plane.SetFlight(airport, destinationAirport);
    }
}
