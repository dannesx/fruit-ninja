using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSrc;
    public AudioClip[] slices;
    public AudioClip gameOver;
    public AudioClip explosion;

    public void SliceSFX(){
        int randomIndex = Random.Range(0, slices.Length);
        audioSrc.PlayOneShot(slices[randomIndex]);
    }

    public void ExplosionSFX(){
        audioSrc.PlayOneShot(explosion);
    }

    public void GameOverSFX(){
        audioSrc.PlayOneShot(gameOver);
    }
}