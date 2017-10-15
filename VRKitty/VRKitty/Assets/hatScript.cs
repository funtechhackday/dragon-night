using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatScript : MonoBehaviour
{
   public Transform target;
    public bool fl;
    // Use this for initialization
    void Start()
    { 
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
            SetTarget();

        if (Input.GetMouseButtonDown(0))
            SetTarget();

       
            
    }
    void SetTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider == null)
                return;

            if (hit.collider.CompareTag("hat"))
            {
                GetComponent<AudioSource>().Play();
            }

            if (target)
                Destroy(target.gameObject);

            if (fl)
            {
                GameObject newTarget = Instantiate(Resources.Load("Dish"), hit.point, Quaternion.identity) as GameObject;
                target = newTarget.transform;
                return;
            }
        }
    }
}