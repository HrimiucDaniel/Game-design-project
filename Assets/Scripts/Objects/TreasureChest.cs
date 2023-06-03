using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public Item  contents;
    public Inventory playerInventory;
    public bool isOpen;
    public SignalSender raiseItem;
    public GameObject dialogBox;
    private Animator anim;
   public Text dialogText;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && playerInRange) {
            if (!isOpen){
                OpenChest();
            }else{
                ChestAlreadyOpened();
            }

        }
        
    }

    public void OpenChest(){
        dialogBox.SetActive(true);
        dialogText.text = contents.itemDescription;
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        raiseItem.Raise();
        isOpen = true;
        context.Raise();
        anim.SetBool("opened", true);

    }

    public void ChestAlreadyOpened(){
        dialogBox.SetActive(false);
       // playerInventory.currentItem = null;
        raiseItem.Raise();
        
    }

        public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen) {
            playerInRange = true;
            context.Raise();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") &&  !other.isTrigger && !isOpen) {
            context.Raise();
            playerInRange = false;;
        }
    }
    
}
