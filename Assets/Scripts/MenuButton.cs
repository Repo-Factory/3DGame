using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MenuButton : MonoBehaviour
{
    public GameObject Menu;
    public void enableMenu()
    {
        Menu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void disableMenu()
    {
        Menu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}