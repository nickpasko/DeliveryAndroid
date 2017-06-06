using iPartnerApp.Enums;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPartnerApp.Model
{
    /// <summary>
    /// Data of driver
    /// </summary>
    public class Driver
    {
        public int ProductType { set; get; }
        /// <summary>
        /// Key for access API
        /// </summary>
        public string SecretKey { set; get; }
        /// <summary>
        /// Curent instance driver
        /// </summary>
        public static Driver Current { set; get; }
        /// <summary>
        /// password driver
        /// todo Переделать на HASH
        /// </summary>
        public string Password { set; get; }
        /// <summary>
        /// Email driver
        /// </summary>
        public string Email { set; get; }
        /// <summary>
        /// Id driver
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// Vendor id driver
        /// </summary>
        public int VendorId { set; get; }
        /// <summary>
        /// Zone driver
        /// </summary>
        public int Zone { set; get; }
        /// <summary>
        /// Driver online status
        /// </summary>
        public DriverStatus DriverStatus { set; get; }

        /// <summary>
        /// las position driver
        /// </summary>
        public Position Position { set; get; }
        /// <summary>
        /// last gps status
        /// </summary>
        public GpsStatus GpsStatus { set; get; }
    }
}

