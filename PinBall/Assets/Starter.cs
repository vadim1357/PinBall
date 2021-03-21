using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Starter : MonoBehaviour
{
    float power;
    float minPower = 0;
    [SerializeField] float maxPower = 100;
    [SerializeField] float powerStep = 5000;
    [SerializeField] Slider powerSlider;
    Rigidbody ball = null;
    bool ballReady;
    private void Start()
    {
        powerSlider.minValue = minPower;
        powerSlider.maxValue = maxPower;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            ball = other.gameObject.GetComponent<Rigidbody>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            ball = null;
            
        }
    }
    private void Update()
    {
        if(ball!= null)
        {
            ballReady = true;
            if(Input.GetKey(KeyCode.Space))
            {
                if(power <= maxPower)
                {
                    power += powerStep * Time.deltaTime;
                }
               
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                ball.AddForce(power * Vector3.forward);
            }
        }
        else
        {
            ballReady = false;
                power = minPower;
        }
        powerSlider.gameObject.SetActive(ballReady);
        powerSlider.value = power;
    }
}
