using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBank
{
    public class UserEntity
    {

        public int _id;
        public string _name;
        public string _phone;
        public string _email;
        public string _status;
        public string _memberid;
        public string _vouchernumber;
        public string _voucherprize;
        public string _dateCreated; // Auto generated timestamp

        //for inserting user after given voucher
        public UserEntity(string name, string phone, string email, string memberid, string vouchernumber, string voucherprize)
        {
            _name = name;
            _phone = phone;
            _email = email;
            _status = "new";
            _memberid = memberid;
            _vouchernumber = vouchernumber;
            _voucherprize = voucherprize;
            _dateCreated = "";
        }

        //for getting data
        public UserEntity(int id2, string name2, string phone2, string email2, string status2, string memberid2, string vouchernumber2, string voucherprize2, string dateCreated2)
        {
            _id = id2;
            _name = name2;
            _phone = phone2;
            _email = email2;
            _status = status2;
            _memberid = memberid2;
            _vouchernumber = vouchernumber2;
            _voucherprize = voucherprize2;
            _dateCreated = dateCreated2;
        }

    }
}
