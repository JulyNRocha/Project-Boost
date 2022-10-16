using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainBoosterParticle;
    [SerializeField] ParticleSystem RightBoosterParticle;
    [SerializeField] ParticleSystem LeftBoosterParticle;

    Rigidbody rb;
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            
            if (!audioSource.isPlaying)
            {    
                audioSource.PlayOneShot(mainEngine);
            }
            if (!mainBoosterParticle.isPlaying)
            {
                mainBoosterParticle.Play();
            }
            
        }
        else
        {
            audioSource.Stop();
            mainBoosterParticle.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
            if (!RightBoosterParticle.isPlaying)
            {
                RightBoosterParticle.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
            if (!LeftBoosterParticle.isPlaying)
            {
                LeftBoosterParticle.Play();
            }
        }
        else
        {
            LeftBoosterParticle.Stop();
            RightBoosterParticle.Stop();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
         rb.freezeRotation = false;
    }
}
