using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsBehavior : MonoBehaviour {

    int elektronCount;
    public ElementClass element;
   
	List<int> elektrons = new List<int>();

    public bool ifPrefeb;

	void Start() {

       


        if (ifPrefeb)
        {
           
            elektronCount = element.elektronCaunt;

            ElektronSpawn(elektronCount);

        }



    }


    void Update () {

        Turning();

	}

    //elementi döndürür
    void Turning( ) {

        transform.RotateAround(gameObject.transform.position, gameObject.transform.up, 200 * Time.deltaTime);

        for (int i = 0; i < gameObject.transform.childCount; i++)
          gameObject.transform.GetChild(i).RotateAround(gameObject.transform.position, gameObject.transform.up, -600 * Time.deltaTime);
    }

    //elementin elektronlarını açar
    void ElektronSpawn(int elektronCount)
    {
       gameObject.GetComponent<Renderer>().material = element.elementMaterial;

        if (elektronCount > 2) elektronCount -= 2; elektronCount = elektronCount % 8; if (elektronCount == 0) elektronCount = 8;

        for (int i = 0; i < elektronCount; i++) elektrons.Add(i);
        int choosing;

        for (int i = 0; i < elektronCount;)
        {
            choosing = Random.Range(0, 8);

            if (gameObject.transform.GetChild(choosing).gameObject.activeSelf == false)
            {
                gameObject.transform.GetChild(choosing).gameObject.GetComponent<Renderer>().material = element.elektronMaterial;

                gameObject.transform.GetChild(choosing).gameObject.SetActive(true);
                i++;
            }

        }

    }

}
