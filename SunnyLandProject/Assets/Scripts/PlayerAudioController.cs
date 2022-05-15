using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{

    AudioSource[] allSources;

    AudioSource SaltarSource;
    AudioSource AterrizarSource;
    AudioSource AgacharseSource;
    AudioSource CerezaSource;
    AudioSource CorrerSource;

    // keep track of the jumping state ... 
    bool isJumping = false;
    // make sure to keep track of the movement as well !

    Rigidbody2D rb; // note the "2D" prefix 

    bool isPlaying = false;
    
    // Start is called before the first frame update
    void Start()
    {

	rb = GetComponent<Rigidbody2D>();

	// get the references to your audio sources here !  

    allSources = GetComponents<AudioSource>();

    AterrizarSource = allSources[0];
    SaltarSource = allSources[1];
    AgacharseSource = allSources[2];
    CerezaSource = allSources[3];
    CorrerSource = allSources[4];

    }

    // FixedUpdate is called whenever the physics engine updates
    void FixedUpdate()
    {

    float v = rb.velocity.magnitude;

    if (v > 1 && !isPlaying) {
        CorrerSource.Play();
        isPlaying = true;
    }
    else if (v < 1 && isPlaying) {
        CorrerSource.Stop();
        isPlaying = false;
    }
    if (isJumping) {
        CorrerSource.Stop();
    }

    }
    
    // trigger your landing sound here !
    public void OnLanding() {

        int x = Random.Range(1,100);
    if (x<=50){
        AterrizarSource.pitch=1;
        AterrizarSource.Play();
    }
    else if (x>=50){
        AterrizarSource.pitch=x/20;
        AterrizarSource.Play();
    }

        isJumping = false;
        print("the fox has landed");
    }

    // trigger your crouching sound here
    public void OnCrouching() {
        print("the fox is crouching");

        AgacharseSource.Play();
    }
 
    // trigger your jumping sound here !
    public void OnJump() {
        int x = Random.Range(1,100);
        isJumping = true;
        print("the fox has jumped");

    if (x<=50){
        SaltarSource.pitch=1;
        SaltarSource.Play();
    }
    else if (x>=50){
        SaltarSource.pitch=x/20;
        SaltarSource.Play();
    }
    
    }

    // trigger your cherry collection sound here !
    public void OnCherryCollect() {
        print("the fox has collected a cherry");

        CerezaSource.Play();
    }
}
