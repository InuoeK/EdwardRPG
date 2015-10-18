using UnityEngine;
using System.Collections;

public class ComputerControls : MonoBehaviour
{

    public Animator anim;

    public bool isIdle;
	bool isInventoryOut;
    bool isMoving;
    bool isAttacking;
    bool facingRight;
    float moveSpeed = 0.05f;

	public GameObject inventory;
    // Use this for initialization
    void Start()
    {
        CheckPlatform();
        isMoving = false;
        isAttacking = false;
        facingRight = true;

    }

    // Update is called once per frame
    void Update()
    {
        CheckControls();
        CheckIdle();

        MoveEdward_Root();
        anim.SetBool("isMoving", isMoving);
    }

    void CheckPlatform()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            GameObject.Find("UI_Controls").SetActive(false);
            GameObject.Find("AndroidControls").SetActive(false);
        }
          
    }

    void CheckIdle()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
            isMoving = true;
        else
            isMoving = false;
    }

    void CheckControls()
    {
        if (Input.GetMouseButtonDown(0))
            isAttacking = true;
        else
            isAttacking = false;
    }

    void MoveEdward_Root()
    {
        if (Input.GetKey("w"))
            GameObject.Find("Edward_Root").transform.position += new Vector3(0, moveSpeed);
        if (Input.GetKey("a"))
            GameObject.Find("Edward_Root").transform.position += new Vector3(-moveSpeed, 0);
        if (Input.GetKey("s"))
            GameObject.Find("Edward_Root").transform.position += new Vector3(0, -moveSpeed);
        if (Input.GetKey("d"))
            GameObject.Find("Edward_Root").transform.position += new Vector3(moveSpeed, 0);
        if ((Input.GetKey("a") & facingRight) || (Input.GetKey("d") & !facingRight))
            Flip();

		if (Input.GetKeyDown ("i")) 
			ShowHideInventory ();
    }

	void ShowHideInventory()
	{
		if (isInventoryOut == false) {
			inventory.SetActive(true);
			isInventoryOut = true;
		} else 
		{
			inventory.SetActive(false);
			isInventoryOut = false;
		}
	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = GameObject.Find("Edward_Root").transform.localScale;
        scale.x *= -1;
        GameObject.Find("Edward_Root").transform.localScale = scale;
    }


}
