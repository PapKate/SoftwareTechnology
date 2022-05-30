using System;
using System.Collections.Generic;
using System.Linq;

namespace VirtualReceptionist
{
    public static class Data
    {
        #region Floor

        public static IEnumerable<Floor> Floors = new List<Floor>()
        {
            new Floor()
            {
                Name = "Ground floor",
                Level = 0,
                Facilities = Facilities.Where(x => x.Name == "Main Pool" || x.Name == "Lounge" || x.Name == "Ballroom").ToList()
            },
            new Floor()
            {
                Name = "Level 1",
                Level = 1,
                Facilities = Facilities.Where(x => x.Name == "Gym" || x.Name == "Restaurant").ToList()
            },
            new Floor()
            {
                Name = "Level 2",
                Level = 2,
                Facilities = Facilities.Where(x => x.Name == "Conference Room").ToList()
            },
            new Floor()
            {
                Name = "Level 3",
                Level = 3,
                Facilities = Facilities.Where(x => x.Name == "Roof Garden").ToList()
            }
        };

        #endregion

        #region Facility

        public static IEnumerable<Facility> Facilities = new List<Facility>() 
        {
            new Facility()
            { 
                Name = "Roof Garden",
                Image = new Uri("https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg"),
                Area = 230,
                Capacity = 150,
                IsOccupied = false,
                Description = "Cocktail, Wine, Food and pool time",
                Floor = Floors.First(x => x.Level == 3)
            },
            new Facility()
            {
                Name = "Main Pool",
                Image = new Uri("https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg"),
                Area = 230,
                Capacity = 1500,
                IsOccupied = false,
                Description = "Cocktail, Wine, Food and pool time",
                Floor = Floors.First(x => x.Level == 0)
            },
            new Facility()
            {
                Name = "Ballroom",
                Image = new Uri("https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg"),
                Area = 230,
                Capacity = 150,
                IsOccupied = false,
                Description = "Cocktail, Wine, Food and pool time",
                Floor = Floors.First(x => x.Level == 0)
            },
            new Facility()
            {
                Name = "Restaurant",
                Image = new Uri("https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg"),
                Area = 230,
                Capacity = 150,
                IsOccupied = false,
                Description = "Cocktail, Wine, Food and pool time",
                Floor = Floors.First(x => x.Level == 1)
            },
            new Facility()
            {
                Name = "Gym",
                Image = new Uri("https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg"),
                Area = 230,
                Capacity = 150,
                IsOccupied = false,
                Description = "Cocktail, Wine, Food and pool time",
                Floor = Floors.First(x => x.Level == 1)
            },
            new Facility()
            {
                Name = "Lounge",
                Image = new Uri("https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg"),
                Area = 230,
                Capacity = 150,
                IsOccupied = false,
                Description = "Cocktail, Wine, Food and pool time",
                Floor = Floors.First(x => x.Level == 0)
            },
            new Facility()
            {
                Name = "Conference Room",
                Image = new Uri("https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg"),
                Area = 230,
                Capacity = 150,
                IsOccupied = false,
                Description = "Cocktail, Wine, Food and pool time",
                Floor = Floors.First(x => x.Level == 2)
            }
        };

        #endregion

        #region Rooms

        public static IEnumerable<Room> Rooms = new List<Room>()
        {
            new Room()
            {
                Name = "101",
                Price = 150,
                Image = new Uri("https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg"),
                Area = 55,
                Capacity = 2,
                IsOccupied = false,
                Description = "Cocktail, Wine, Food and pool time",
                Floor = Floors.First(x => x.Level == 1)
            },
            new Room()
            {
                Name = "102",
                Price = 120,
                Image = new Uri("https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg"),
                Area = 45,
                Capacity = 2,
                IsOccupied = true,
                Description = "Cocktail, Wine, Food and pool time",
                Floor = Floors.First(x => x.Level == 1)
            },
            new Room()
            {
                Name = "201",
                Price = 200,
                Image = new Uri("https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg"),
                Area = 55,
                Capacity = 2,
                IsOccupied = false,
                Description = "Cocktail, Wine, Food and pool time",
                Floor = Floors.First(x => x.Level == 2)
            },
        };

        #endregion

        #region Staff

        public static IEnumerable<Staff> Staff = new List<Staff>()
        {
            new Staff()
            {
                FirstName = "Τριαντάφυλλος",
                LastName = "Πράππας",
                Email = "lime@gmail.com",
                Pin = new Pin()
                {
                    Code = 12345678,
                    IsActive = true,
                },
                Phone = new Phone()
                {
                    CountryCode = 30,
                    PhoneNumber = "6978020324"
                },
                DateCreated = new DateTime(2020, 03, 21),
                Hotel = Hotels.First()
            },
            new Staff()
            {
                FirstName = "Αικατερίνη",
                LastName = "Παπαδοπούλου",
                Email = "magenta@gmail.com",
                Pin = new Pin()
                {
                    Code = 24082000,
                    IsActive = true,
                },
                Phone = new Phone()
                {
                    CountryCode = 30,
                    PhoneNumber = "6978020324"
                },
                DateCreated = new DateTime(2020, 03, 21),
                Hotel = Hotels.First()
            },
            new Staff()
            {
                FirstName = "Κωνσταντίνα",
                LastName = "Ρο",
                Email = "lightBlue@gmail.com",
                Pin = new Pin()
                {
                    Code = 24082000,
                    IsActive = true,
                },
                Phone = new Phone()
                {
                    CountryCode = 30,
                    PhoneNumber = "6978020324"
                },
                DateCreated = new DateTime(2020, 03, 21),
                Hotel = Hotels.First()
            }
        };

        #endregion

        #region Event

        public static IEnumerable<Event> Events = new List<Event>()
        {
            new Event()
            {
                Name = "Pool Party",
                Description = "Gather up your pals for a 6.00 pm arrival where you'll enjoy grazing on a sumptuous two-course meal together in The Lounge. Once your appetite has been pleasantly satisfied, make your way to The Relaxation Burrow as your private DJ will be hitting the decks from 18.00pm to 11.30pm.",
                Facility = Facilities.First(x => x.Name == "Main Pool"),
                Price = 50,
                MaxNumberOfGuests = 1000,
                DateStart = new DateTime(2022, 05, 29),
                Duration = new TimeSpan(8, 0, 0),
                Pin = new Pin() 
                {
                    Code = 11111111,
                    IsActive = true,
                },
                IsPrivate = false,
            }
        };

        #endregion

        #region Hotel

        public static IEnumerable<Hotel> Hotels = new List<Hotel>()
        {
            new Hotel()
            {
                Name = "Sahara Resort",
                DateCreated = new DateTime(2020, 03, 21),
                Pin = new Pin()
                {
                    IsActive = true,
                    Code = 26240118
                },
                Floors = Floors,
                Staff = Staff,
            }
        };

        #endregion
    }
}
