using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            FindObjectOfType<AudioManager>().ExplosionSFX();
            FindObjectOfType<AudioManager>().GameOverSFX();
            FindObjectOfType<GameManager>().Explode();
        }
    }
}