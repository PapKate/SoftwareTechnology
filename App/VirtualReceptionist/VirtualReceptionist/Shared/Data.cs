using System;
using System.Collections.Generic;
using System.Linq;

namespace VirtualReceptionist
{
    public static class Data
    {
        #region Floor

        public static IEnumerable<Floor> Floors = new List<Floor>();

        #endregion

        #region Facility

        public static IEnumerable<Facility> Facilities = new List<Facility>();
       
        #endregion

        #region Rooms

        public static IEnumerable<Room> Rooms = new List<Room>();

        #endregion

        #region Staff

        public static IEnumerable<Staff> Staff = new List<Staff>();
        
        #endregion

        #region Event

        public static IEnumerable<Event> Events = new List<Event>();

        #endregion

        #region Hotel

        public static IEnumerable<Hotel> Hotels = new List<Hotel>();

        #endregion
    }
}
