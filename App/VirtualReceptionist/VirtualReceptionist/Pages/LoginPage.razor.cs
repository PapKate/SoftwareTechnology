using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualReceptionist
{
    public partial class LoginPage
    {
        #region Protected Properties

        /// <summary>
        /// The navigation manager
        /// </summary>
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginPage() : base()
        {

        }

        #endregion

        #region Protected Methods

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                var hotels = new List<Hotel>()
                {
                    new Hotel()
                    {
                        Name = "Sahara Resort",
                        DateCreated = new DateTime(2020, 03, 21),
                        Pin = new Pin()
                        {
                            IsActive = true,
                            Code = 26240118
                        }
                    },
                    new Hotel()
                    {
                        Name = "Dubai Resort",
                        DateCreated = new DateTime(2020, 03, 25),
                        Pin = new Pin()
                        {
                            IsActive = true,
                            Code = 09080604
                        }
                    }
                };

                var staff = new List<Staff>()
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
                        Hotel = hotels.First()
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
                        Hotel = hotels.First()
                    },
                    new Staff()
                    {
                        FirstName = "Κωνσταντίνα",
                        LastName = "Ρο",
                        Email = "LightBlue@gmail.com",
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
                        Hotel = hotels.First()
                    }
                };

                hotels.First().Staff = staff;

                var floors = new List<Floor>()
                {
                    new Floor()
                    {
                        Name = "Ground floor",
                        Level = 0,
                    },
                    new Floor()
                    {
                        Name = "Level 1",
                        Level = 1,
                    },
                    new Floor()
                    {
                        Name = "Level 2",
                        Level = 2,
                    },
                    new Floor()
                    {
                        Name = "Level 3",
                        Level = 3,
                    }
                };

                var facilities = new List<Facility>()
                {
                    new Facility()
                    {
                        Name = "Roof Garden",
                        Image = new Uri("https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg"),
                        Area = 230,
                        Capacity = 150,
                        IsOccupied = false,
                        Description = "Cocktail, Wine, Food and pool time",
                        Floor = floors.First(x => x.Level == 3)
                    },
                    new Facility()
                    {
                        Name = "Main Pool",
                        Image = new Uri("https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg"),
                        Area = 230,
                        Capacity = 1500,
                        IsOccupied = false,
                        Description = "Cocktail, Wine, Food and pool time",
                        Floor = floors.First(x => x.Level == 0)
                    },
                    new Facility()
                    {
                        Name = "Ballroom",
                        Image = new Uri("https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg"),
                        Area = 230,
                        Capacity = 150,
                        IsOccupied = false,
                        Description = "Cocktail, Wine, Food and pool time",
                        Floor = floors.First(x => x.Level == 0)
                    },
                    new Facility()
                    {
                        Name = "Restaurant",
                        Image = new Uri("https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg"),
                        Area = 230,
                        Capacity = 150,
                        IsOccupied = false,
                        Description = "Cocktail, Wine, Food and pool time",
                        Floor = floors.First(x => x.Level == 1)
                    },
                    new Facility()
                    {
                        Name = "Gym",
                        Image = new Uri("https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg"),
                        Area = 230,
                        Capacity = 150,
                        IsOccupied = false,
                        Description = "Cocktail, Wine, Food and pool time",
                        Floor = floors.First(x => x.Level == 1)
                    },
                    new Facility()
                    {
                        Name = "Lounge",
                        Image = new Uri("https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg"),
                        Area = 230,
                        Capacity = 150,
                        IsOccupied = false,
                        Description = "Cocktail, Wine, Food and pool time",
                        Floor = floors.First(x => x.Level == 0)
                    },
                    new Facility()
                    {
                        Name = "Conference Room",
                        Image = new Uri("https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg"),
                        Area = 230,
                        Capacity = 150,
                        IsOccupied = false,
                        Description = "Cocktail, Wine, Food and pool time",
                        Floor = floors.First(x => x.Level == 2)
                    }
                };

                var rooms = new List<Room>()
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
                        Floor = floors.First(x => x.Level == 1)
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
                        Floor = floors.First(x => x.Level == 1)
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
                        Floor = floors.First(x => x.Level == 2)
                    }
                };

                var events = new List<Event>()
                {
                    new Event()
                    {
                        Name = "Pool Party",
                        Description = "Gather up your pals for a 6.00 pm arrival where you'll enjoy grazing on a sumptuous two-course meal together in The Lounge. Once your appetite has been pleasantly satisfied, make your way to The Relaxation Burrow as your private DJ will be hitting the decks from 18.00pm to 11.30pm.",
                        Facility = facilities.First(x => x.Name == "Main Pool"),
                        Price = 50,
                        Image = "./images/poolParty.jpg",
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

                facilities.First(x => x.Name == "Main Pool").Events = events;

                floors.First(x => x.Level == 1).Rooms = rooms.Where(x => x.Name.StartsWith("1")).ToList();
                floors.First(x => x.Level == 2).Rooms = rooms.Where(x => x.Name.StartsWith("2")).ToList();

                floors.First(x => x.Level == 0).Facilities = facilities.Where(x => x.Name == "Main Pool" || x.Name == "Lounge" || x.Name == "Ballroom").ToList();
                floors.First(x => x.Level == 1).Facilities = facilities.Where(x => x.Name == "Gym" || x.Name == "Restaurant").ToList();
                floors.First(x => x.Level == 2).Facilities = facilities.Where(x => x.Name == "Conference Room").ToList();
                floors.First(x => x.Level == 3).Facilities = facilities.Where(x => x.Name == "Roof Garden").ToList();

                var floors1 = floors;
                var floors2 = floors;

                floors1.ForEach(x => x.Hotel = hotels.First());
                floors2.ForEach(x => x.Hotel = hotels.Last());

                hotels.First().Floors = floors1;                hotels.Last().Floors = floors2;

                Data.Hotels = hotels;
                Data.Events = events;   
                Data.Staff = staff;
                Data.Floors = floors;
                Data.Rooms = rooms;
                Data.Facilities = facilities;
            }
        }

        #endregion

        #region Private Methods

        private void Visitor_OnClick()
        {
            GlobalData.UserType = UserType.Visitor;
            NavigationManager.Visitor_NavigateToEventsPage();
        }

        private void Customer_OnClick()
        {
            GlobalData.UserType = UserType.Customer;
            NavigationManager.Customer_NavigateToMyRoomPage();
        }

        private void Staff_OnClick()
        {
            GlobalData.UserType = UserType.Staff;
            NavigationManager.Staff_NavigateToRoomsPage();
        }

        #endregion
    }
}
