using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ExitBtn : MonoBehaviour
{   
    public void ExitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.Exit(0);
#else
       
        Application.Quit();
#endif
    }
}
