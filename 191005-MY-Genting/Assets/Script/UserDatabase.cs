﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
using System;
using System.IO;
using UnityEngine.UI;

public class UserDatabase : MonoBehaviour
{
    public List<UserEntity> myList = new List<UserEntity>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void InsertData(string name, string phone, string email, string memberid, string vouchernumber, string voucherprize)
    {
        UserDb mLocationDb = new UserDb();
        mLocationDb.addData(new UserEntity(name, phone, email, memberid, vouchernumber, voucherprize));
        mLocationDb.close();
    }

    public void UpdateData(int i)
    {
        myList[i]._status = "new";
        UserDb mLocationDb2 = new UserDb();
        mLocationDb2.updateData(myList[i]);
        mLocationDb2.close();
    }

    public void GetData()
    {
        UserDb mLocationDb3 = new UserDb();
        System.Data.IDataReader reader = mLocationDb3.getAllData();
        while (reader.Read())
        {
            UserEntity entity = new UserEntity(int.Parse(reader[0].ToString()),
                                               reader[1].ToString(),
                                               reader[2].ToString(),
                                               reader[3].ToString(),
                                               reader[4].ToString(),
                                               reader[5].ToString(),
                                               reader[6].ToString(),
                                               reader[7].ToString(),
                                               reader[8].ToString());

            myList.Add(entity);
        }
        mLocationDb3.close();
    }
}
