using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuGameController : MonoBehaviour
{
    private Button GameArrow;
    private Button GameColor;

    private void BtnGameArrow()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainArrow");

    }
    private void BtnGameColor()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainColor");

    }
}
