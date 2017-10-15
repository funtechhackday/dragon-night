using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    public float speed;
    Transform target;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) SetTarget();
        if (target) Move();
    }

    void SetTarget()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider == null) return;
            GameObject newTarget = Instantiate(Resources.Load("cat"), hit.point, Quaternion.identity) as GameObject;
            target = newTarget.transform; 
        }
    }
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
