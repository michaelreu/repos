﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_FlightSimulator.Models
{
    /*
     * this class will parse the data of the flight simulator by ',' and returns an array of values. 
     */
    class ClientHandlerFilghtParser : ClientHandler
    {
        public double handleClient(string data, int index)
        {

            string[] dataArray = data.Split(',');
            return Double.Parse(dataArray[index]);
        }
    }
}
