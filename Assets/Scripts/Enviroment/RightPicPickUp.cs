using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightPicPickUp : MonoBehaviour
{

    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public GameObject theLeftPic;

    public GameObject halfFade;
    public GameObject leftPic;
    public GameObject picText;

    public GameObject fakeWall;
    public GameObject realWall;


    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ExtraCross.SetActive(true);
            ActionText.GetComponent<Text>().text = "Pick up piece of picture";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 3)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
  
                GlobalInventory.rightPic = true;
                StartCoroutine(PicPickedUp());
            }
        }

        void OnMouseExit()
        {
            ExtraCross.SetActive(false);
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
        }

        IEnumerator PicPickedUp()
        {
            fakeWall.SetActive(false);
            realWall.SetActive(true);
            picText.GetComponent<Text>().text = "YOU GOT THE RIGHT PIECE";
            halfFade.SetActive(true);
            leftPic.SetActive(true);
            picText.SetActive(true);
            yield return new WaitForSeconds(3);
            halfFade.SetActive(false);
            leftPic.SetActive(false);
            picText.SetActive(false);
            theLeftPic.SetActive(false);
        }
    }
}