using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Touch_Hint : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(sceneName);
    }
}
