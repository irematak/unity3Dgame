using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenu: MonoBehaviour
{
    
    // oyunu yeniden başlatmak için 
    public void reStart(){
        // MEVCUT SAHNEYİ YUÜKLER:
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadSceneAsync("level1") ;
    }
    /*
    public void start(){
        Button DevamButton = FindObjectOfType<Button>();
        
        ısSeeButton(); // true kayıtlı oyun var onu yükle button gözüksün
        if(!ısSeeButton()) {
            DevamButton.gameObject.SetActive(false); 
        }else{
            // true: kayıtlı oyunu getir
            DevamButton.onClick.AddListener(DevamEt());
        }
    }
     public void DevamEt(){ // buttona ver 
        // button güzüküyor ve basılınca kayıtlı oyunu getir get
        SceneManager.LoadSceneAsync("LEVEL2") ;

     }
     bool  ısSeeButton(){

        // oyunun kayıtlı olup olmadıgını kontrol et
       return true; 
      
    }
     */
}