using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class HealthScript : MonoBehaviour
{
    public Slider slider;
    public ParticleSystem explotion;
    public ParticleSystem burning; 
    public AudioSource exp_sound;
    public GameFlow GameFlow; 
    

    
    private bool isdead;
    private bool isBurning; 


    // Start is called before the first frame update
    
    void Start()
    {
        isdead = false;
        isBurning = false; 
        slider.maxValue = 100;
        slider.minValue = 0;
        slider.value = 100; 
    }

    public void effectHealth(float value)
    {
       // Debug.Log("health"); 
        
        slider.value += value;
        
        if(slider.value <= 0)
        {
            if (!isdead) death();
            
        }
        if (slider.value <= 30 && !isBurning)
        {
            burn();
        }
        if (slider.value > 30 && isBurning)
        {
            isBurning = false;
            burning.transform.position = transform.position;
            burning.gameObject.SetActive(false);
            burning.Stop();
        }


    }
    void death()
    {

        isdead = true; 
        explotion.transform.position = transform.position;


        explotion.transform.parent = null;
        explotion.transform.position = transform.position;
        explotion.Play();
        exp_sound.Play();
        
        if(gameObject.name == "tanktry3")
        {
           // isdead = true;
           
            GameFlow.Lose();
        }
        else
        {
            //isdead = true;
            GameFlow.DeleteTank(); 
        }

      

        //Destroy(explotion);
       // Destroy(burning);

        Destroy(gameObject,1.5f);
      
       

    }
    void burn()
    {
     
        isBurning = true; 
        burning.transform.position = transform.position + new Vector3(0f,2f,0f);
        burning.gameObject.SetActive(true);
        burning.Play();
    }
   

        
}
