using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickup : MonoBehaviour
{
    [SerializeField] AudioClip money_pick;
    [SerializeField] float volume = 1.0f;
    [SerializeField] int pointsObtained= 1;
    bool wasCollected = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player" && !wasCollected)
        {
            wasCollected=true;
            FindObjectOfType<GameSession>().AddToScore(pointsObtained);
            AudioSource.PlayClipAtPoint(money_pick,Camera.main.transform.position,volume);
            Destroy(gameObject);
        }
    }
}
