using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clones : MonoBehaviour
{
    public GameObject CPlayer;
    public GameObject PPlayer;
    public GameObject LPlayer;
    public GameObject death;

    private int clones = 0;
    // Start is called before the first frame update
    void Start()
    {
        PPlayer.SetActive(false);
        LPlayer.SetActive(false);
    }
    // Update is called once per frame
    
    void FixedUpdate()
    {
        if (death.GetComponent<Death>().death == true){
            Debug.Log("Died");
            if (clones == 1 ){
                LPlayer.SetActive(true);
                PPlayer.SetActive(true);
                LPlayer.GetComponent<CloneInd>().values = PPlayer.GetComponent<CloneInd>().values;
                LPlayer.GetComponent<CloneInd>().jumps = PPlayer.GetComponent<CloneInd>().jumps;
                LPlayer.GetComponent<CloneInd>().lenght = PPlayer.GetComponent<CloneInd>().lenght;
                PPlayer.GetComponent<CloneInd>().values = PotheadScript.values;
                PPlayer.GetComponent<CloneInd>().jumps = PotheadScript.jumps;
                PPlayer.GetComponent<CloneInd>().lenght = PotheadScript.length;
            } else{
                clones++;
                PPlayer.SetActive(true);
                PPlayer.GetComponent<CloneInd>().values = PotheadScript.values;
                PPlayer.GetComponent<CloneInd>().jumps = PotheadScript.jumps;
                PPlayer.GetComponent<CloneInd>().lenght = PotheadScript.length;
            }
        }
    }
}
