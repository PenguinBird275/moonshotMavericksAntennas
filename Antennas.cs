using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antennas : MonoBehaviour
{
    CSVReader csv;
    public GameObject gameObj;
    Renderer ren;
    public int[] antenna1;
    public int[] antenna2;
    public int[] antenna3;
    public int[] antenna4;
    public float[] budget1;
    public float[] budget2;
    public float[] budget3;
    public float[] budget4;
    public bool a1cn;
    public bool a2cn;
    public bool a3cn;
    public bool a4cn;
    public float mnum = 0f;
    public List<bool> cns;
    public List<float> nums;
    public int cni = 0;
    public int aindex = 0;
    /*public static float max(params float[] nums){
        mnum = 0f;
        foreach(float num in nums){
            if (num > mnum){
                mnum = num;
            }
        }
        return mnum;
    }*/

    void Awake()
    {
        csv = gameObj.GetComponent<CSVReader>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ren = GetComponent<Renderer>();
        antenna1 = csv.antenna1;
        antenna2 = csv.antenna2;
        antenna3 = csv.antenna3;
        antenna4 = csv.antenna4;
        budget1 = csv.budget1;
        budget2 = csv.budget2;
        budget3 = csv.budget3;
        budget4 = csv.budget4;
    }

    // Update is called once per frame
    void Update()
    {
        antenna1 = csv.antenna1;
        antenna2 = csv.antenna2;
        antenna3 = csv.antenna3;
        antenna4 = csv.antenna4;
        budget1 = csv.budget1;
        budget2 = csv.budget2;
        budget3 = csv.budget3;
        budget4 = csv.budget4;
        if (aindex <= antenna1.Length - 1){
            a1cn = (antenna1[aindex]==1);
            a2cn = (antenna2[aindex]==1);
            a3cn = (antenna3[aindex]==1);
            a4cn = (antenna4[aindex]==1);
            cns.Clear();
            cns.Add(a1cn);
            cns.Add(a2cn);
            cns.Add(a3cn);
            cns.Add(a4cn);
            mnum = 0f;
            nums.Clear();
            nums.Add(budget1[aindex]);
            nums.Add(budget2[aindex]);
            nums.Add(budget3[aindex]);
            nums.Add(budget4[aindex]);
            foreach(float num in nums){
                if (num > mnum){
                    mnum = num;
                }
            }
            if(mnum.Equals(0f)){
                ren.material.color = Color.white;
            }else if(mnum.Equals(budget1[aindex])){
                cni = 0;
                ren.material.color = Color.red;
            }else if(mnum.Equals(budget2[aindex])){
                cni = 1;
                ren.material.color = Color.green;
            }else if(mnum.Equals(budget3[aindex])){
                cni = 2;
                ren.material.color = Color.blue;
            }else if(mnum.Equals(budget4[aindex])){
                cni = 3;
                ren.material.color = Color.black;
            }
            /*if (!cns[cni]){
                if (a1cn){
                    cni = 0;
                    ren.material.color = Color.red;
                }else if (a2cn){
                    cni = 1;
                    ren.material.color = Color.green;
                }else if (a3cn){
                    cni = 2;
                    ren.material.color = Color.blue;
                }else if (a4cn){
                    cni = 3;
                    ren.material.color = Color.black;
                }else{
                    ren.material.color = Color.white;
                }
            }*/
        }
        aindex++;
    }
}
