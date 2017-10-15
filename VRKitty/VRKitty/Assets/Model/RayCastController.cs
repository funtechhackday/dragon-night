using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RayCastController : MonoBehaviour
{
    public float speed;
    public bool eating;
    Transform target;
    Animator animator;
    public int window;
    public bool et;
    public bool fl = false;
    public AudioClip MyAudio;

    void Start()
    {
        window = 1;
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
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
                et = true;
                return;
            }

            if (target)
                Destroy(target.gameObject);
           // GetComponent<AudioSource>().PlayOneShot(MyAudio);


            if (eating)
            {
                GameObject newTarget = Instantiate(Resources.Load("Dish"), hit.point, Quaternion.identity) as GameObject;
                target = newTarget.transform;
                return;
            }

            if (fl)
            {
                
                GameObject newHat = Instantiate(Resources.Load("hat"), hit.point, Quaternion.identity) as GameObject;
                target = newHat.transform;
                return;
                fl = false;
                
            }
            GameObject newMoveTarget = Instantiate(Resources.Load("Point"), hit.point, Quaternion.identity) as GameObject;
            target = newMoveTarget.transform;
        }
    }
    void Move()
    {
        transform.LookAt(target);
        if (animator.GetBool("bRun") == false)
            animator.SetBool("bRun", true);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        //еслм дошли
        if (transform.position == target.position)
        {
            if (eating)
            {
                Eating();
                return;
            }
            Destroy(target.gameObject);
            animator.SetBool("bRun", false);
        }
    }
    void Eating()
    {
        GetComponent<AudioSource>().Play();
        animator.SetBool("bRun", false);
        Destroy(target.gameObject);
        Debug.Log("Eating!");
        eating = false;
    }
    void OnGUI()
    {
        if (et)
        {
            GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200));
            if (window == 1)
            {
                if (GUI.Button(new Rect(10, 30, 200, 50), "Поесть"))
                {
                    window = 2;
                    
                }
                if (GUI.Button(new Rect(10, 90, 200, 50), "Принести что-то?"))
                {
                    window = 3;
                   
                }

                if (GUI.Button(new Rect(10, 150, 200, 50), "Назад"))
                {
                   
                    window = 4;
                   
                }
            }

            if (window == 2)
            {
                GUI.Label(new Rect(50, 10, 200, 50), "ХОЧУ ЖРАТЬ!");
                if (GUI.Button(new Rect(10, 40, 200, 50), "ДАЙ ЕМУ ПОЖРАТЬ!"))
                {

                    
                    window = 1;
                    eating = true;
                     et = false;
                }

            }

            if (window == 3)
            {
                //GetComponent<AudioSource>().PlayOneShot(MyAudio);
                GUI.Label(new Rect(50, 30, 200,50), "Принеси Шляпу");
                if (GUI.Button(new Rect(10, 160, 200, 50), "Что?!"))
                {
                    GetComponent<AudioSource>().PlayOneShot(MyAudio);
                    et = false;
                    window = 1;
                    fl = true;
                   
                }
            }


            if (window == 4)
            {
               
                GUI.Label(new Rect(50, 10, 200, 50), "Все тлен?");
                if (GUI.Button(new Rect(10, 40, 200, 50), "Да"))
                {
               
                    window = 1;
                    et = false;
                }

            }
            GUI.EndGroup();
        }
    }
}

