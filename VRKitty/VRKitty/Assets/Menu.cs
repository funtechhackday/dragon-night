using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public int window;

    void Start()
    {
        window = 1;
    }

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200));
        if (window == 1)
        {
            if (GUI.Button(new Rect(10, 30, 180, 30), "Поесть"))
            {
                window = 2;
            }
            if (GUI.Button(new Rect(10, 70, 180, 30), "Что-то сказать"))
            {
                window = 3;
            }
           
            if (GUI.Button(new Rect(10, 150, 180, 30), "Назад"))
            {
                window = 4;
            }
        }

        if (window == 2)
        {
            GUI.Label(new Rect(50, 10, 180, 30), "ХОЧУ ЖРАТЬ!");
            if (GUI.Button(new Rect(10, 40, 180, 30), "ДАЙ ЕМУ ПОЖРАТЬ!"))
            {
                SceneManager.LoadScene("FirstScene");
            }
           
        }

        if (window == 3)
        {
            GUI.Label(new Rect(50, 30, 180, 50), "Как говорил мой батя:\n МЯУ МЯУ МЯУ!");
            if (GUI.Button(new Rect(10, 160, 180, 30), "АЖ ДО СЛЕЗ!"))
            {
                SceneManager.LoadScene("FirstScene");
            }
        }


        if (window == 4)
        {
            GUI.Label(new Rect(50, 10, 180, 30), "Все тлен?");
            if (GUI.Button(new Rect(10, 40, 180, 30), "Да"))
            {
                SceneManager.LoadScene("FirstScene");
            }
            
        }
        GUI.EndGroup();
    }
}