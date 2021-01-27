using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Compound")]
public class CompoundClass : ScriptableObject
{
    public string compoundName;
    public string symbol;
    public string information;
    public ElementClass[] components;
    public Sprite cardImageFront;
    public Sprite cardImageBack;
    public GameObject compundModel;


}
