using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastController : MonoBehaviour
{
    public float speed;
    Transform target;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>(); 
    }
    // Update is called once per frame
    void Update ()
    {
        if (Input.touchCount == 1)
            SetTarget();

        if (Input.GetMouseButtonDown(0))
            SetTarget();

        if (target)
            Move();
    }
    void SetTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider == null)
                return;

            if (hit.collider.CompareTag("Player"))
            {
                return;
            }
            if (target)
                Destroy(target.gameObject);


            GameObject newTarget = Instantiate(Resources.Load("Point"), hit.point, Quaternion.identity) as GameObject;
            target = newTarget.transform;
        }
    }
    void Move()
    {
        transform.LookAt(target);
        if(animator.GetBool("bRun") == false)
            animator.SetBool("bRun", true);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if(transform.position == target.position)
        {
            Destroy(target.gameObject);
            animator.SetBool("bRun", false);
        }
    }
}
