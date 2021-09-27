using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneManager : MonoBehaviour
{
    public GameObject droneObj;

    public float createDroneDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateDrone());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CreateDrone()
    {
        while (true)
        {
            yield return new WaitForSeconds(createDroneDelay);
            GameObject drone = Instantiate(droneObj);
            drone.transform.position = transform.position;
        }
    }
}
