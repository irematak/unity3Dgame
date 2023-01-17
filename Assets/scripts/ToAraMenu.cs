using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToAraMenu : MonoBehaviour
{
     public void playScene(){
      SceneManager.LoadSceneAsync("AraMenu");
    }
}
