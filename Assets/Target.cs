using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public GameObject waypoint1, waypoint2;

    public int speed = 1;

    public bool isHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    transform.position = Vector3.Lerp (waypoint1.transform.position, waypoint2.transform.position, Mathf.PingPong(Time.time*speed, 1.0f));

    }

    private void OnTriggerEnter(Collider other)
    {
        print("Acertou o target");
        isHit = true;
    }
}
