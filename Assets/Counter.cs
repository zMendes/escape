using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{

    public GameObject target1_;
    public GameObject target2_;
    public GameObject target3_;

    public GameObject hint1;

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
        //Para cada filho, se todos estiverem true, clear the area
        if (target1.isHit && target2.isHit && target3.isHit){
            print("All clear");
            hint1.SetActive(true);
        } 
        
    }
}
