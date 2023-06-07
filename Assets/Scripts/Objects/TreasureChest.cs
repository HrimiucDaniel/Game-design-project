using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    [Header("Contents")]
    public Item  contents;
    public Inventory playerInventory;
    public bool isOpen;
    public BoolValue storedOpen;

    [Header("Signals and dialog")]
    public SignalSender raiseItem;
    public GameObject dialogBox;
    public Text dialogText;

    [Header("Animator")]
    private Animator anim;
   
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = storedOpen.RuntimeValue;
        if (isOpen)
        {
            anim.SetBool("opened", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && playerInRange)
        {
            if (!isOpen)
            {
                OpenChest();
            }
            else
            {
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
        storedOpen.RuntimeValue=isOpen;
    }

    public void ChestAlreadyOpened(){
        dialogBox.SetActive(false);
       // playerInventory.currentItem = null;
        raiseItem.Raise();
    }

    public new void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            playerInRange = true;
            context.Raise();
        }
    }

    public new void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") &&  !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = false;;
        }
    }
}
