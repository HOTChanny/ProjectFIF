using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_3_SceneChanger : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("StartScene");
    }
}
