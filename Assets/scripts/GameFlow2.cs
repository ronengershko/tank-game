using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFlow2 : MonoBehaviour
{
    public Text ammo_fire;
    public Text ammo_projectile;
    public Text message;
    public Text BIG;

    public int countTanks = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ammocounter(int fire, int projectile)
    {
        ammo_fire.text = "fire missiles:" + fire.ToString();
        ammo_projectile.text = "projectiles: " + projectile.ToString();


    }

    public void SendMassege(string input)
    {
        message.text = input;


    }
    public void RegisterTank()
    {
        countTanks++;
        Debug.Log(countTanks + 6); 

    }

    public void DeleteTank()
    {
        countTanks--;
        Debug.Log(countTanks);
        SendMassege("good !!" + countTanks.ToString() + " left");
        if (countTanks == 0)
        {
            BIG.text = "VICTORY";
            // Thread.Sleep(2000);  

            SceneManager.LoadScene("EndVictory2");
        }
    }

    public void Lose()
    {

        BIG.text = "YOU LOSE!";
        //Thread.Sleep(1000);
        SceneManager.LoadScene("EndVictory2");
    }
}
