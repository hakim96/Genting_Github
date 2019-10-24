using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
using System;
using System.IO;
using UnityEngine.UI;

public class VoucherDatabase : MonoBehaviour
{
    public Text test;
    public List<LocationEntity> myList = new List<LocationEntity>();

    // Start is called before the first frame update
    void Start()
    {
        if(!File.Exists(Application.dataPath + "/GENTING_db"))
        {
            //INSERT DATA
            LocationDb mLocationDb = new LocationDb();
            mLocationDb.addData(new LocationEntity("Voucher_1", 90));
            mLocationDb.addData(new LocationEntity("Voucher_2", 25));
            mLocationDb.addData(new LocationEntity("Voucher_3", 10));
            mLocationDb.addData(new LocationEntity("Voucher_4", 100));
            mLocationDb.addData(new LocationEntity("Voucher_5", 90));
            mLocationDb.addData(new LocationEntity("Voucher_6", 90));
            mLocationDb.close();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetData()
    {
        //GET DATA (FETCH)
        LocationDb mLocationDb2 = new LocationDb();
        System.Data.IDataReader reader = mLocationDb2.getAllData();
        while (reader.Read())
        {
            LocationEntity entity = new LocationEntity(int.Parse(reader[0].ToString()),
                                                        reader[1].ToString(),
                                                        int.Parse(reader[2].ToString()));

            Debug.Log("ID: " + entity._id + " & Type: " + entity._type + " & Stock: " + entity._stock);
            myList.Add(entity);
        }
        mLocationDb2.close();
        test.text = "Get Successful!!";
    }

    public void UpdateData(int i)
    {
        myList[i]._stock -= 1;
        //UPDATE DATA
        LocationDb mLocationDb3 = new LocationDb();
        mLocationDb3.updateData(myList[i], myList[i]._id);
        mLocationDb3.close();
        test.text = "Update Successful!!";
    }

    public void CompareDatabase()
    {

    }
}
