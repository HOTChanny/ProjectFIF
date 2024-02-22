using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorstScene : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("WorstEndScene");
    }
}
