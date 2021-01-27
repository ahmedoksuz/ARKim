using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBehavior : MonoBehaviour
{
    public ElementClass element;
    public CompoundClass compound;


    public Sprite defaultImage;

    public bool isactive = false;
    public bool isTrigger;



    

    void Start()
    {
       
     
    }


    void Update()
    {
        //kartın frontuna kart görüntüsü koyar
        if (element!=null)
        {

            gameObject.transform.parent.Find("CardImage").gameObject.GetComponent<Image>().sprite= element.cardImageFront;

        }
        else if (compound!=null)
        {
           
           gameObject.transform.parent.Find("CardImage").gameObject.GetComponent<Image>().sprite = compound.cardImageFront;
       
        }
        else if (element==null&&compound==null)
        {
            gameObject.transform.parent.Find("CardImage").gameObject.GetComponent<Image>().sprite = defaultImage;

        }




    }
  

    //kartın trigerlenıp trigerlanmadığını manegere bildirir

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Card")
        {
            isTrigger = true;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Card")
        {
            isTrigger = false;

        }
    }




}
