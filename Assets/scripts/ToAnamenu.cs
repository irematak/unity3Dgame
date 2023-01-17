using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToAnamenu : MonoBehaviour
{
     public void playScene(){
      SceneManager.LoadSceneAsync("MainMenu");
    }
}
