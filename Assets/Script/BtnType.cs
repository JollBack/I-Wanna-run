using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BtnType : MonoBehaviour
{
    public BTNType currentType;
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.New:
                SceneManager.LoadScene("Wanna");

                break;
            case BTNType.Quit:
                Application.Quit();
                break;
        }
    }
}
