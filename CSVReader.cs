using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Orbit : MonoBehaviour
{
        public float missiontime;
        public float Rx;
        public float Ry;
        public float Rz;
        public float Vx;
        public float Vy;
        public float Vz;
        public float MASS;
        public int WPSA;
        public string BudgetWPSA;
        public int DS54;
        public string BudgetDS54;
        public int DS24;
        public string BudgetDS24;
        public int DS34;
        public string BudgetDS34;

    }
public class CSVReader : MonoBehaviour
{

    public TextAsset textAssetData;


    

    [System.Serializable]
    public class OrbitList
    {
        public Orbit[] orbit;
    }

    [SerializeField] public Vector3[] artimiesPositions;
    [SerializeField] public float[] artimiesSpeed;
    [SerializeField] public int[] antenna1;
    [SerializeField] public int[] antenna2;
    [SerializeField] public int[] antenna3;
    [SerializeField] public int[] antenna4;
    [SerializeField] public float[] budget1;
    [SerializeField] public float[] budget2;
    [SerializeField] public float[] budget3;
    [SerializeField] public float[] budget4;


    public OrbitList myOrbitList = new OrbitList();

    // Start is called before the first frame update
    
    void Awake()
    {
        ReadCSV();
        artimiesPositions = new Vector3[12981];
        artimiesSpeed = new float[12981];
        antenna1 = new int[12981];
        antenna2 = new int[12981];
        antenna3 = new int[12981];
        antenna4 = new int[12981];
        budget1 = new float[12981];
        budget2 = new float[12981];
        budget3 = new float[12981];
        budget4 = new float[12981];

        //artimiesPositions[0] = new Vector3(0,0,0);
        
        for (int i=0; i < 12981; i++)
        {
            artimiesPositions[i] = new Vector3((myOrbitList.orbit[i].Rx)/500, (myOrbitList.orbit[i].Ry)/500, (myOrbitList.orbit[i].Rz)/500);
            artimiesSpeed[i] = Mathf.Sqrt((myOrbitList.orbit[i].Vx * myOrbitList.orbit[i].Vx) + (myOrbitList.orbit[i].Vy * myOrbitList.orbit[i].Vy) + (myOrbitList.orbit[i].Vz * myOrbitList.orbit[i].Vz));
            antenna1[i] = myOrbitList.orbit[i].WPSA;
            antenna2[i] = myOrbitList.orbit[i].DS54;
            antenna3[i] = myOrbitList.orbit[i].DS24;
            antenna4[i] = myOrbitList.orbit[i].DS34;
            if (antenna1[i]==0){
                budget1[i] = 0f;
            }else{
                budget1[i] = float.Parse(myOrbitList.orbit[i].BudgetWPSA);
            }
            if (antenna2[i]==0){
                budget2[i] = 0f;
            }else{
                budget2[i] = float.Parse(myOrbitList.orbit[i].BudgetDS54);
            }
            if (antenna3[i]==0){
                budget3[i] = 0f;
            }else{
                budget3[i] = float.Parse(myOrbitList.orbit[i].BudgetDS24);
            }
            if (antenna4[i]==0){
                budget4[i] = 0f;
            }else{
                budget4[i] = float.Parse(myOrbitList.orbit[i].BudgetDS34);
            }
        }
    }

    void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] { ",", "\n"}, StringSplitOptions.None);

        int tableSize = data.Length / 17 - 1;
        myOrbitList.orbit = new Orbit[tableSize];

        for(int i=0; i<tableSize; i++)
        {
            myOrbitList.orbit[i] = new Orbit();
            myOrbitList.orbit[i].missiontime = float.Parse(data[17 * (i+1)]);
            myOrbitList.orbit[i].Rx = float.Parse(data[17 * (i+1) + 1]);
            myOrbitList.orbit[i].Ry = float.Parse(data[17 * (i+1) + 2]);
            myOrbitList.orbit[i].Rz = float.Parse(data[17 * (i+1) + 3]);
            myOrbitList.orbit[i].Vx = float.Parse(data[17 * (i+1) + 4]);
            myOrbitList.orbit[i].Vy = float.Parse(data[17 * (i+1) + 5]);
            myOrbitList.orbit[i].Vz = float.Parse(data[17 * (i+1) + 6]);
            myOrbitList.orbit[i].MASS = float.Parse(data[17 * (i+1) + 7]);
            myOrbitList.orbit[i].WPSA = int.Parse(data[17 * (i+1) + 8]);
            myOrbitList.orbit[i].BudgetWPSA = data[17 * (i+1) + 9];
            myOrbitList.orbit[i].DS54 = int.Parse(data[17 * (i+1) + 10]);
            myOrbitList.orbit[i].BudgetDS54 = data[17 * (i+1) + 11];
            myOrbitList.orbit[i].DS24 = int.Parse(data[17 * (i+1) + 12]);
            myOrbitList.orbit[i].BudgetDS24 = data[17 * (i+1) + 13];
            myOrbitList.orbit[i].DS34 = int.Parse(data[17 * (i+1) + 14]);
            myOrbitList.orbit[i].BudgetDS34 = data[17 * (i+1) + 15];
        }
    }
}
