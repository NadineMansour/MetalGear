using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundsScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip walking;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w")|| Input.GetKey("s")|| Input.GetKey("d")|| Input.GetKey("a")|| Input.GetKey("c"))
        {
            audioSource.PlayOneShot(walking);
        }
    }
}
