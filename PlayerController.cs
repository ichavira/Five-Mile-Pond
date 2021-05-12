using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D playerRb;
    private DialogueManager dm;
    private ItemManager im;
    private Journal journal;
    private Animator anim;

    private Vector2 boxSize = new Vector2(0.1f, 1f);

    //private static bool playerExists;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        dm = DialogueManager.instance;
        im = ItemManager.instance;
        journal = Journal.instance;
        anim = GetComponent<Animator>();
        /*
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            Destroy(gameObject);
        }
        */
        
    }

    void FixedUpdate()
    {
        //Stop player movement and actions during dialogue
        if (dm.isActive || im.isActive || journal.isActive)
        {
            playerRb.velocity = Vector2.zero;
            return;
        }

        //Object Interaction 
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKey(KeyCode.E))
        {
            CheckInteraction();
        }

        //Player movement
        float moveH = Input.GetAxisRaw("Horizontal");
        float moveV = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(moveH * speed * Time.deltaTime, moveV * speed * Time.deltaTime, 0f));

        anim.SetFloat("MoveX", moveH);
        anim.SetFloat("MoveY", moveV);
    }

    private void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);
        if(hits.Length > 0)
        {
            foreach(RaycastHit2D rc in hits)
            {
                if (rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact();
                    return;
                }
            }
        }
    }
}
