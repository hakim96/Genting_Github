using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataBank
{
    public class UserDb : SqliteHelper
    {
        private const String CodistanTag = "Codistan: UserDb:\t";

        private const String TABLE_NAME = "User_Redeem";
        private const String KEY_ID = "id";
        private const String KEY_NAME = "name";
        private const String KEY_PHONE = "phone";
        private const String KEY_EMAIL = "email";
        private const String KEY_STATUS = "status";
        private const String KEY_MEMBERID = "memberid";
        private const String KEY_VOUCHERNUMBER = "vouchernumber";
        private const String KEY_VOUCHERPRIZE = "voucherprize";
        private const String KEY_DATE = "date";
        private String[] COLUMNS = new String[] { KEY_ID, KEY_NAME, KEY_PHONE, KEY_DATE };

        public UserDb() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                KEY_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                KEY_NAME + " TEXT, " +
                KEY_PHONE + " TEXT, " +
                KEY_EMAIL + " TEXT, " +
                KEY_STATUS + " TEXT, " +
                KEY_MEMBERID + " TEXT, " +
                KEY_VOUCHERNUMBER + " TEXT, " +
                KEY_VOUCHERPRIZE + " TEXT, " +
                KEY_DATE + " DATETIME DEFAULT CURRENT_TIMESTAMP )";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(UserEntity user)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + TABLE_NAME
                + " ( "
                + KEY_NAME + ", "
                + KEY_PHONE + ", "
                + KEY_EMAIL + ", "
                + KEY_STATUS + ", "
                + KEY_MEMBERID + ", "
                + KEY_VOUCHERNUMBER + ", "
                + KEY_VOUCHERPRIZE + " ) "

                + "VALUES ( '"
                + user._name + "', '"
                + user._phone + "', '"
                + user._email + "', '"
                + user._status + "', '"
                + user._memberid + "', '"
                + user._vouchernumber + "', '"
                + user._voucherprize + "' )";
            dbcmd.ExecuteNonQuery();
        }

        public void updateData(UserEntity user)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "UPDATE " + TABLE_NAME
                + " SET "
                + KEY_STATUS + "='"
                + user._status + "'"
                + "WHERE "
                + KEY_ID + "='"
                + user._id.ToString() + "'";

            Debug.Log("Update Data : " + KEY_PHONE + ": " + user._phone);
            Debug.Log("UPDATE ID : " + user._id);

            dbcmd.ExecuteNonQuery();
        }

        public override IDataReader getDataById(int id)
        {
            return base.getDataById(id);
        }

        public override IDataReader getDataByString(string str)
        {
            Debug.Log(CodistanTag + "Getting user: " + str);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + str + "'";
            return dbcmd.ExecuteReader();
        }

        public override void deleteDataByString(string id)
        {
            Debug.Log(CodistanTag + "Deleting user: " + id);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "DELETE FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + id + "'";
            dbcmd.ExecuteNonQuery();
        }

        public override void deleteDataById(int id)
        {
            base.deleteDataById(id);
        }

        public override void deleteAllData()
        {
            Debug.Log(CodistanTag + "Deleting Table");

            base.deleteAllData(TABLE_NAME);
        }

        public override IDataReader getAllData()
        {
            return base.getAllData(TABLE_NAME);
        }

        public IDataReader getLatestTimeStamp()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " ORDER BY " + KEY_DATE + " DESC LIMIT 1";
            return dbcmd.ExecuteReader();
        }
    }
}
