using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 300.0f;
    public Slider healthSlider;
    PlayerMovement playerMovement;
    MouseLook mouseLook;

    void Start()
    {
    	playerMovement = GetComponent<PlayerMovement>();
    	mouseLook = GetComponent<MouseLook>();
    }
    // Update is called once per frame
    void Update()
    {
    	if (playerMovement.victory == false)
    	{
        	health -= Time.deltaTime;
        	healthSlider.value = health;
        }
        if (health <= 0.0f)
        {
        	// Debug.Log("dead");
        	// playerMovement.enabled = false;
        	// mouseLook.enabled = false;
        	// SceneManager.LoadScene("Scene");
        	StartCoroutine(victory());
        }

    }

    IEnumerator victory()
    {
		Debug.Log("dead");
		playerMovement.enabled = false;
		mouseLook.enabled = false;
		yield return new WaitForSeconds(4);
		SceneManager.LoadScene("Scene");
    }
}
