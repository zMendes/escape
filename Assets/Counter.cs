using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class Counter : MonoBehaviour
{

    public GameObject target1_;
    public GameObject target2_;
    public GameObject target3_;

    public GameObject hint1;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;

    Target target1;
    Target target2;
    Target target3;

    bool isHit1, isHit2, isHit3;

    // Start is called before the first frame update
    void Start()
    {
        target1 = target1_.GetComponent<Target>();
        target2 = target2_.GetComponent<Target>();
        target3 = target3_.GetComponent<Target>();

    }

    // Update is called once per frame
    void Update()
    {
        if (target1.isHit){
            text1.SetActive(true);
        }
        if (target2.isHit){
            text2.SetActive(true);
        }
        if (target3.isHit){
            text3.SetActive(true);
        }
        //Para cada filho, se todos estiverem true, clear the area
        if (target1.isHit && target2.isHit && target3.isHit){
            print("All clear");
            hint1.SetActive(true);
            text2.SetActive(true);
            text3.SetActive(true);
        } 
        
    }
}
