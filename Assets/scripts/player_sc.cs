using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class player_sc : MonoBehaviour
{
    
    #region Variables        
    [SerializeField] TextMeshProUGUI text;
    //Platform
    [SerializeField] Transform ground1;
    [SerializeField] Transform ground2;    
    bool ground1Move;   
 
    [SerializeField] int can = 5;
    int puan = 0;

    bool canObstacleControl;

    [SerializeField] GameObject endPanel;
    #endregion


    #region Unity Event Functions
    void Start()
    {        
        ground1Move = true;
        canObstacleControl = true;

        
    }    

    #endregion

    #region Triggers

    void OnTriggerEnter(Collider other)
    {                              
        if(other.CompareTag("Untagged") == false)
        {
            ObstacleControl(other.transform); //cani azalt
            if (other.CompareTag("ball")) GetComponent<Renderer>().material.color = other.GetComponent<Renderer>().material.color;
        }             

        #region Platform Control
        if (other.CompareTag("ground2") && ground1Move)
        {
            ground1.transform.position += new Vector3(0, 0, ground2.localScale.z * 2); //Diger platformun uzunlugu kadar ileri git
            ground1Move = false; //otelemeyi yalnizca bir kez yap            
        }
        else if (other.CompareTag("ground1") && ground1Move == false)
        {
            ground2.transform.position += new Vector3(0, 0, ground1.localScale.z * 2); //Diger platformun uzunlugu kadar ileri git
            ground1Move = true; ////otelemeyi yalnizca bir kez yap            
        }
        
        #endregion
    }

    private void OnTriggerExit(Collider other)
    {
        canObstacleControl = true;
    }

    #endregion

    #region Collision
    
    #endregion
    
    
       private void GoNextLevel()
    {
       int siradakiSahne = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCount > siradakiSahne)
       {
        SceneManager.LoadScene(siradakiSahne);
       }
    }



    void ObstacleControl(Transform obj)
    {
        bool isSameColor = obj.GetComponent<Renderer>().material.color == GetComponent<Renderer>().material.color;

         Scene scene = SceneManager.GetActiveScene();
        if (obj.CompareTag("blok") == false && isSameColor)
        {
            print("Same Color");
            transform.localScale += Vector3.one / 4;

            puan += 10;

            obj.gameObject.SetActive(false);
             //anim.play("PlayerFireWorksAnim");
             //anim.Play("bang_anim");
             scene = SceneManager.GetActiveScene();

             if(puan==20 && scene.name=="level1"){
               GoNextLevel();
             }
             

        }
        else if (obj.CompareTag("blok") || (obj.CompareTag("ball") && isSameColor == false)) 
        {
            can --;
            puan -= 10;
            
            transform.localScale -= Vector3.one / 4; //player boyutunu degistir
            if(obj.CompareTag("ball")) obj.gameObject.SetActive(false);
        }      

        canObstacleControl = false;

        if (can == 0 || transform.localScale.x < .5f) GameOver();          
    }
       
    void GameOver()
    {
        
        SceneManager.LoadSceneAsync("GameOver");
        Time.timeScale = 0;
        
    }
}
