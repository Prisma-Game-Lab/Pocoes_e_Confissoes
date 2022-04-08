using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEscController : MonoBehaviour
{
    public GameObject main;
    public GameObject settings;
    public GameObject credits;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settings.activeSelf)
            {
                settings.SetActive(false);
                main.SetActive(true);
            }
            else if (credits.activeSelf)
            {
                credits.SetActive(false);
                main.SetActive(true);
            }
        }
    }
}
