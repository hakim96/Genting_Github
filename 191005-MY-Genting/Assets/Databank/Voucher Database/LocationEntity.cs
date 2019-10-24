using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBank
{
	public class LocationEntity {

        public int _id;
        public string _type;
        public int _stock;
        public string _dateCreated; // Auto generated timestamp

        public LocationEntity(string type, int stock)
        {
            _type = type;
            _stock = stock;
			_dateCreated = "";
        }

        public LocationEntity(int id, string type, int stock)
        {
            _id = id;
            _type = type;
            _stock = stock;
            _dateCreated = "";
        }

        public LocationEntity(int id, string type, int stock, string dateCreated)
        {
            _id = id;
            _type = type;
            _stock = stock;
			_dateCreated = dateCreated;
        }
	}
}
