using UnityEngine;

public class MagicPowerUp : Powerup
{
    public Inventory playerInventory;
    public float magicValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other) {
        playerInventory.currentMagic += magicValue;
        if (other.gameObject.CompareTag("Player")){
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
