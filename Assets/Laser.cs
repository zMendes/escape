using System.Collections;

using System.Collections.Generic;

using UnityEngine;


using UnityEngine.EventSystems;

using Valve.VR.Extras;


public class Laser : MonoBehaviour

{

     private SteamVR_LaserPointer steamVrLaserPointer;

 

     private void Awake()

     {

         steamVrLaserPointer = gameObject.GetComponent<SteamVR_LaserPointer>();

         steamVrLaserPointer.PointerIn += OnPointerIn;

         steamVrLaserPointer.PointerOut += OnPointerOut;

         steamVrLaserPointer.PointerClick += OnPointerClick;

     }

 

     private void OnPointerClick(object sender, PointerEventArgs e)

     {

         Debug.Log("objeto clicado com o laser " + e.target.name);
         StartCoroutine(MoveFromTo(e.target.transform, e.target.transform.position, transform.position, 8.0f));



     }

 

     private void OnPointerOut(object sender, PointerEventArgs e)

     {

        Debug.Log("laser saiu do objeto " + e.target.name);

     }

 

     private void OnPointerIn(object sender, PointerEventArgs e)

     {

         Debug.Log("laser entrou do objeto " + e.target.name);

     }


    IEnumerator MoveFromTo(Transform objectToMove, Vector3 a, Vector3 b, float speed)

    {

        float step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;

        float t = 0;

        while (t <= 1.0f)

        {

            t += step;

            objectToMove.position = Vector3.Lerp(a, b, t);

            yield return new WaitForFixedUpdate();

        }

        objectToMove.position = b;

    }

 }