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
                        Hotel = hotels.Last()
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
                        LastName = "Ρόμπολα",
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

                var customers = new List<CustomerUser>()
                {
                    new CustomerUser()
                    {
                    Phone = new Phone()
                    {
                        CountryCode = 30,
                        PhoneNumber = "6970030425"
                    },
                    Pin = new Pin()
                    {
                        Code = 25052030,
                        IsActive = true,
                    },
                    DateCreated = new DateTime(2022, 03, 21)
                    },
                    new CustomerUser()
                    {
                    Phone = new Phone()
                    {
                        CountryCode = 30,
                        PhoneNumber = "6970539442"
                    },
                    Pin = new Pin()
                    {
                        Code = 25742530,
                        IsActive = true,
                    },
                    DateCreated = new DateTime(2022, 03, 21)
                    }
                };

                var floorsOne = new List<Floor>()
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
                    },
                    new Floor()
                    {
                        Name = "Level 4",
                        Level = 4
                    },
                    new Floor()
                    {
                        Name = "Level 5",
                        Level = 5
                    }
                };

                var floorsTwo = new List<Floor>()
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
                    },
                    new Floor()
                    {
                        Name = "Level 4",
                        Level = 4
                    },
                    new Floor()
                    {
                        Name = "Level 5",
                        Level = 5
                    },
                    new Floor()
                    {
                        Name = "Level 6",
                        Level = 6
                    }
                };

                var facilitiesOne = new List<Facility>()
                {
                    new Facility()
                    {
                        Name = "Roof Garden",
                        Image = "~/images/roofGarden.jpg",
                        Area = 230,
                        Capacity = 150,
                        IsOccupied = false,
                        Description = "Cocktail, Wine and Food",
                        Floor = floorsOne.First(x => x.Level == 5)
                    },
                    new Facility()
                    {
                        Name = "Main Pool",
                        Image = "~/images/poolParty.jpg",
                        Area = 230,
                        Capacity = 1500,
                        IsOccupied = false,
                        Description = "Cocktail, Wine, Food and pool time",
                        Floor = floorsOne.First(x => x.Level == 0)
                    },
                    new Facility()
                    {
                        Name = "Ballroom",
                        Image = "~/images/ballroom.jpg",
                        Area = 230,
                        Capacity = 150,
                        IsOccupied = false,
                        Description = "Come dance with us",
                        Floor = floorsOne.First(x => x.Level == 3)
                    },
                    new Facility()
                    {
                        Name = "Restaurant",
                        Image = "~/images/restaurant.jpg",
                        Area = 230,
                        Capacity = 150,
                        IsOccupied = false,
                        Description = "Experience new flavours",
                        Floor = floorsOne.First(x => x.Level == 1)
                    },
                    new Facility()
                    {
                        Name = "Gym",
                        Image = "~/images/gym.jpg",
                        Area = 230,
                        Capacity = 150,
                        IsOccupied = false,
                        Description = "Workout with us",
                        Floor = floorsOne.First(x => x.Level == 2)
                    },
                    new Facility()
                    {
                        Name = "Lounge",
                        Image = "~/images/lounge.jpg",
                        Area = 230,
                        Capacity = 150,
                        IsOccupied = false,
                        Description = "Caffe and bar",
                        Floor = floorsOne.First(x => x.Level == 0)
                    },
                    new Facility()
                    {
                        Name = "Conference Room",
                        Image = "~/images/conferenceRoom.jpg",
                        Area = 230,
                        Capacity = 150,
                        IsOccupied = false,
                        Description = "Meetings and Conferences",
                        Floor = floorsOne.First(x => x.Level == 4)
                    }
                };

                var facilitiesTwo = new List<Facility>()
                {
                    new Facility()
                    {
                        Name = "Roof Garden",
                        Image = "~/images/roofGarden.jpg",
                        Area = 230,
                        Capacity = 150,
                        IsOccupied = false,
                        Description = "Cocktail, Wine and Food",
                        Floor = floorsTwo.Last(x => x.Level == 6)
                    },
                    new Facility()
                    {
                        Name = "Main Pool",
                        Image = "~/images/poolParty.jpg",
                        Area = 230,
                        Capacity = 1500,
                        IsOccupied = false,
                        Description = "Cocktail, Wine, Food and pool time",
                        Floor = floorsTwo.Last(x => x.Level == 6)
                    },
                    new Facility()
                    {
                        Name = "Ballroom",
                        Image = "~/images/ballroom.jpg",
                        Area = 230,
                        Capacity = 150,
                        IsOccupied = false,
                        Description = "Come dance with us",
                        Floor = floorsTwo.Last(x => x.Level == 3)
                    },
                    new Facility()
                    {
                        Name = "Restaurant",
                        Image = "~/images/restaurant.jpg",
                        Area = 230,
                        Capacity = 150,
                        IsOccupied = false,
                        Description = "Experience new flavours",
                        Floor = floorsTwo.Last(x => x.Level == 2)
                    },
                    new Facility()
                    {
                        Name = "Gym",
                        Image = "~/images/gym.jpg",
                        Area = 230,
                        Capacity = 150,
                        IsOccupied = false,
                        Description = "Workout with us",
                        Floor = floorsTwo.Last(x => x.Level == 1)
                    },
                    new Facility()
                    {
                        Name = "Lounge",
                        Image = "~/images/lounge.jpg",
                        Area = 230,
                        Capacity = 150,
                        IsOccupied = false,
                        Description = "Caffe and bar",
                        Floor = floorsTwo.Last(x => x.Level == 0)
                    },
                    new Facility()
                    {
                        Name = "Conference Room",
                        Image = "~/images/conferenceRoom.jpg",
                        Area = 230,
                        Capacity = 150,
                        IsOccupied = false,
                        Description = "Meetings and Conferences",
                        Floor = floorsOne.First(x => x.Level == 4)
                    }
                };

                var roomsOne = new List<Room>()
                {
                    new Room()
                    {
                        Name = "101",
                        Price = 150,
                        Image = "https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg",
                        Area = 55,
                        Capacity = 2,
                        IsOccupied = false,
                        Description = "Standard rooms, are modern decorated that can accommodate up to 2 persons, totally soundproofed and equipped with high tech comforts such as high speed internet access, USB ports , smart TV and room cleaning touch system.",
                        Floor = floorsOne.First(x => x.Level == 1)
                    },
                    new Room()
                    {
                        Name = "102",
                        Price = 120,
                        Image = "https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg",
                        Area = 45,
                        Capacity = 2,
                        IsOccupied = true,
                        Description = "Standard rooms, are modern decorated that can accommodate up to 2 persons, totally soundproofed and equipped with high tech comforts such as high speed internet access, USB ports , smart TV and room cleaning touch system.",
                        Floor = floorsOne.First(x => x.Level == 1)
                    },
                    new Room()
                    {
                        Name = "201",
                        Price = 200,
                        Image = "https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg",
                        Area = 55,
                        Capacity = 3,
                        IsOccupied = false,
                        Description = "Standard rooms, are modern decorated that can accommodate up to 2 persons, totally soundproofed and equipped with high tech comforts such as high speed internet access, USB ports , smart TV and room cleaning touch system.",
                        Floor = floorsOne.First(x => x.Level == 2)
                    },
                    new Room()
                    {
                        Name = "202",
                        Price = 200,
                        Image = "https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg",
                        Area = 55,
                        Capacity = 4,
                        IsOccupied = false,
                        Description = "Standard rooms, are modern decorated that can accommodate up to 2 persons, totally soundproofed and equipped with high tech comforts such as high speed internet access, USB ports , smart TV and room cleaning touch system.",
                        Floor = floorsOne.First(x => x.Level == 2)
                    },
                    new Room()
                    {
                        Name = "301",
                        Price = 200,
                        Image = "https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg",
                        Area = 55,
                        Capacity = 2,
                        IsOccupied = false,
                        Description = "Standard rooms, are modern decorated that can accommodate up to 2 persons, totally soundproofed and equipped with high tech comforts such as high speed internet access, USB ports , smart TV and room cleaning touch system.",
                        Floor = floorsOne.First(x => x.Level == 3)
                    },
                    new Room()
                    {
                        Name = "302",
                        Price = 300,
                        Image = "https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg",
                        Area = 100,
                        Capacity = 5,
                        IsOccupied = false,
                        Description = "Standard rooms, are modern decorated that can accommodate up to 2 persons, totally soundproofed and equipped with high tech comforts such as high speed internet access, USB ports , smart TV and room cleaning touch system.",
                        Floor = floorsOne.First(x => x.Level == 3)
                    },
                    new Room()
                    {
                        Name = "401",
                        Price = 250,
                        Image = "https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg",
                        Area = 75,
                        Capacity = 2,
                        IsOccupied = false,
                        Description = "Standard rooms, are modern decorated that can accommodate up to 2 persons, totally soundproofed and equipped with high tech comforts such as high speed internet access, USB ports , smart TV and room cleaning touch system.",
                        Floor = floorsOne.First(x => x.Level == 4)
                    }, 
                    new Room()
                    {
                        Name = "402",
                        Price = 200,
                        Image = "https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg",
                        Area = 105,
                        Capacity = 6,
                        IsOccupied = false,
                        Description = "Standard rooms, are modern decorated that can accommodate up to 2 persons, totally soundproofed and equipped with high tech comforts such as high speed internet access, USB ports , smart TV and room cleaning touch system.",
                        Floor = floorsOne.First(x => x.Level == 4)
                    }
                };

                var roomsTwo = new List<Room>()
                {
                    new Room()
                    {
                        Name = "201",
                        Price = 150,
                        Image = "https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg",
                        Area = 55,
                        Capacity = 2,
                        IsOccupied = false,
                        Description = "Standard rooms, are modern decorated that can accommodate up to 2 persons, totally soundproofed and equipped with high tech comforts such as high speed internet access, USB ports , smart TV and room cleaning touch system.",
                        Floor = floorsTwo.Last(x => x.Level == 2)
                    },
                    new Room()
                    {
                        Name = "202",
                        Price = 120,
                        Image = "https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg",
                        Area = 45,
                        Capacity = 2,
                        IsOccupied = true,
                        Description = "Standard rooms, are modern decorated that can accommodate up to 2 persons, totally soundproofed and equipped with high tech comforts such as high speed internet access, USB ports , smart TV and room cleaning touch system.",
                        Floor = floorsTwo.Last(x => x.Level == 2)
                    },
                    new Room()
                    {
                        Name = "401",
                        Price = 200,
                        Image = "https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg",
                        Area = 55,
                        Capacity = 3,
                        IsOccupied = false,
                        Description = "Standard rooms, are modern decorated that can accommodate up to 2 persons, totally soundproofed and equipped with high tech comforts such as high speed internet access, USB ports , smart TV and room cleaning touch system.",
                        Floor = floorsTwo.Last(x => x.Level == 4)
                    },
                    new Room()
                    {
                        Name = "402",
                        Price = 200,
                        Image = "https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg",
                        Area = 55,
                        Capacity = 4,
                        IsOccupied = false,
                        Description = "Standard rooms, are modern decorated that can accommodate up to 2 persons, totally soundproofed and equipped with high tech comforts such as high speed internet access, USB ports , smart TV and room cleaning touch system.",
                        Floor = floorsTwo.Last(x => x.Level == 4)
                    },
                    new Room()
                    {
                        Name = "403",
                        Price = 200,
                        Image = "https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg",
                        Area = 55,
                        Capacity = 2,
                        IsOccupied = false,
                        Description = "Standard rooms, are modern decorated that can accommodate up to 2 persons, totally soundproofed and equipped with high tech comforts such as high speed internet access, USB ports , smart TV and room cleaning touch system.",
                        Floor = floorsTwo.Last(x => x.Level == 4)
                    },
                    new Room()
                    {
                        Name = "501",
                        Price = 300,
                        Image = "https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg",
                        Area = 100,
                        Capacity = 5,
                        IsOccupied = false,
                        Description = "Standard rooms, are modern decorated that can accommodate up to 2 persons, totally soundproofed and equipped with high tech comforts such as high speed internet access, USB ports , smart TV and room cleaning touch system.",
                        Floor = floorsTwo.Last(x => x.Level == 5)
                    },
                    new Room()
                    {
                        Name = "502",
                        Price = 250,
                        Image = "https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg",
                        Area = 75,
                        Capacity = 2,
                        IsOccupied = false,
                        Description = "Standard rooms, are modern decorated that can accommodate up to 2 persons, totally soundproofed and equipped with high tech comforts such as high speed internet access, USB ports , smart TV and room cleaning touch system.",
                        Floor = floorsTwo.Last(x => x.Level == 5)
                    },
                    new Room()
                    {
                        Name = "503",
                        Price = 200,
                        Image = "https://kataskevi.gr/images/2021/03/19/IMG_5443.jpg",
                        Area = 105,
                        Capacity = 6,
                        IsOccupied = false,
                        Description = "Standard rooms, are modern decorated that can accommodate up to 2 persons, totally soundproofed and equipped with high tech comforts such as high speed internet access, USB ports , smart TV and room cleaning touch system.",
                        Floor = floorsTwo.Last(x => x.Level == 5)
                    }
                };


                var eventsOne = new List<Event>()
                {
                    new Event()
                    {
                        Name = "Pool Party",
                        Description = "Gather up your pals for a 6.00 pm arrival where you'll enjoy grazing on a sumptuous two-course meal together in The Lounge. Once your appetite has been pleasantly satisfied, make your way to The Relaxation Burrow as your private DJ will be hitting the decks from 18.00pm to 11.30pm.",
                        Facility = facilitiesOne.First(x => x.Name == "Main Pool"),
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
                    },
                    new Event()
                    {
                        Name = "Thai Night",
                        Description = "Thai dishes are sweet, salty, spicy or sour. There are many dishes with thick noodles,vegetables, lettuce, and chicken, lamb, shrimp, or beef. Some dishes are more rice geared or contain fruits such as pineapple or papaya. Come to our restaurant to try traditional dishes from Thailand!",
                        Facility = facilitiesOne.First(x => x.Name == "Restaurant"),
                        Price = 50,
                        Image = "./images/restaurant.jpg",
                        MaxNumberOfGuests = 500,
                        DateStart = new DateTime(2022, 06, 29),
                        Duration = new TimeSpan(8, 0, 0),
                        Pin = new Pin()
                        {
                            Code = 12111111,
                            IsActive = true,
                        },
                        IsPrivate = false,
                    },
                    new Event()
                    {
                        Name = "Jazz Night",
                        Description = "Gather all your friends and come to our hotel's roof garden to enjoy a drink while listening to Jazz music performed by The Shooters, a talented local band!",
                        Facility = facilitiesOne.First(x => x.Name == "Roof Garden"),
                        Price = 25,
                        Image = "./images/roofGarden.jpg",
                        MaxNumberOfGuests = 200,
                        DateStart = new DateTime(2022, 07, 29),
                        Duration = new TimeSpan(8, 0, 0),
                        Pin = new Pin()
                        {
                            Code = 11311111,
                            IsActive = true,
                        },
                        IsPrivate = false,
                    }
                };

                var eventsTwo = new List<Event>()
                {
                    new Event()
                    {
                        Name = "Gym Session",
                        Description = "Group Session for everyone",
                        Facility = facilitiesTwo.First(x => x.Name == "Gym"),
                        Price = 50,
                        Image = "./images/gym.jpg",
                        MaxNumberOfGuests = 300,
                        DateStart = new DateTime(2022, 05, 29),
                        Duration = new TimeSpan(8, 0, 0),
                        Pin = new Pin()
                        {
                            Code = 11141111,
                            IsActive = true,
                        },
                        IsPrivate = false,
                    },
                    new Event()
                    {
                        Name = "Jane & Chad's Wedding",
                        Description = "Mrs. Jane Smith and Mr. Chad Jones request the honor of your presence as the exchange their marriage vows. On this day they will marry the one they laugh with,live for, dream with, love!",
                        Facility = facilitiesTwo.Last(x => x.Name == "Ballroom"),
                        Price = 50,
                        Image = "./images/ballroom.jpg",
                        MaxNumberOfGuests = 500,
                        DateStart = new DateTime(2022, 06, 29),
                        Duration = new TimeSpan(8, 0, 0),
                        Pin = new Pin()
                        {
                            Code = 11111118,
                            IsActive = true,
                        },
                        IsPrivate = true,
                    },
                    new Event()
                    {
                        Name = "Cocktail Night",
                        Description = "Gather up your pals for a 6.00 pm arrival where you'll enjoy grazing on a sumptuous two-course meal together in The Lounge. Once your appetite has been pleasantly satisfied, make your way to The Relaxation Burrow as your private DJ will be hitting the decks from 18.00pm to 11.30pm.",
                        Facility = facilitiesTwo.Last(x => x.Name == "Lounge"),
                        Price = 25,
                        Image = "./images/lounge.jpg",
                        MaxNumberOfGuests = 200,
                        DateStart = new DateTime(2022, 07, 29),
                        Duration = new TimeSpan(8, 0, 0),
                        Pin = new Pin()
                        {
                            Code = 11111171,
                            IsActive = true,
                        },
                        IsPrivate = false,
                    }
                };
                
                var reservationsOne = new List<EventReservation>()
                {
                    new EventReservation()
                    {
                        FirstName = "Μαρία",
                        LastName = "Τσαβέα",
                        Phone = new Phone()
                        {
                            CountryCode = 30,
                            PhoneNumber = "6975537825"
                        },
                        NumberOfGuests = 4,
                        IsPaid = false,
                        Event = eventsOne.First(),
                        
                    }
                };

                var reservationTwo = new List<CustomerEventReservation>()
                {
                    new CustomerEventReservation()
                    {
                        FirstName = "Γιώργος",
                        LastName = "Παπανδρέου",
                        Phone = new Phone()
                        {
                            CountryCode = 30,
                            PhoneNumber = "6970030425"
                        },
                        NumberOfGuests = 6,
                        IsPaid = true,
                        Event = eventsTwo.Last(),
                        Customer = customers.First(),
                    }
                };

                var checkInOne = new List<EventChekIn>()
                {
                    new EventChekIn()
                    {
                        Event = eventsOne.Last(),
                        IsReservation = false,
                        Phone = new Phone()
                        {
                            CountryCode = 30,
                            PhoneNumber = "6974430529"
                        },
                        NumberOfguests = 2,
                    }
                };

                var checkInTwo = new List<EventChekIn>()
                {
                    new EventChekIn()
                    {
                        Event = eventsTwo.Last(),
                        IsReservation = true,
                        EventReservation = reservationTwo.First(),
                        Phone = new Phone()
                        {
                            CountryCode = 30,
                            PhoneNumber = "6976780590"
                        },
                        NumberOfguests = 6,
                    }
                };

                var roomCheckInOne = new List<RoomCheckIn>()
                {
                    new RoomCheckIn()
                    {
                        Room = roomsOne.First(),
                        Customer = customers.Last(),
                        NumberOfGuests = 2,
                        DateCreated = new DateTime(2022, 03, 21),
                        DateEnded =  new DateTime(2022, 08, 30),
                        IsPaid = false,
                    }
                };

                var roomCheckInTwo = new List<RoomCheckIn>()
                {
                    new RoomCheckIn()
                    {
                        Room = roomsTwo.First(),
                        Customer = customers.First(),
                        NumberOfGuests = 2,
                        DateCreated = new DateTime(2022, 03, 21),
                        DateEnded =  new DateTime(2022, 08, 30),
                        IsPaid = true,
                    }
                };

                facilitiesOne.First( ).Events = eventsOne;
                facilitiesTwo.Last(x =>  x.Name == "Gym" || x.Name == "Lounge" || x.Name == "Ballroom").Events = eventsTwo;

                //floors.First(x => x.Level == 1).Rooms = rooms.Where(x => x.Name.StartsWith("1")).ToList();
                //floors.First(x => x.Level == 2).Rooms = rooms.Where(x => x.Name.StartsWith("2")).ToList();//

                floorsOne.First(x => x.Level == 0).Facilities = facilitiesOne.Where(x => x.Name == "Main Pool" || x.Name == "Lounge" ).ToList();
                floorsOne.First(x => x.Level == 1).Facilities = facilitiesOne.Where(x => x.Name == "Restaurant").ToList();
                floorsOne.First(x => x.Level == 2).Facilities = facilitiesOne.Where(x => x.Name == "Gym").ToList();
                floorsOne.First(x => x.Level == 3).Facilities = facilitiesOne.Where(x => x.Name == "Ballroom").ToList();
                floorsOne.First(x => x.Level == 4).Facilities = facilitiesOne.Where(x => x.Name == "Conference Room").ToList();
                floorsOne.Last(x => x.Level == 5).Facilities = facilitiesOne.Where(x => x.Name == "Roof Garden").ToList();


                floorsTwo.Last(x => x.Level == 0).Facilities = facilitiesTwo.Where(x => x.Name == "Lounge").ToList();
                floorsTwo.Last(x => x.Level == 1).Facilities = facilitiesTwo.Where(x => x.Name == "Gym").ToList();
                floorsTwo.Last(x => x.Level == 2).Facilities = facilitiesTwo.Where(x => x.Name == "Restaurant").ToList();
                floorsTwo.Last(x => x.Level == 3).Facilities = facilitiesTwo.Where(x => x.Name == "Ballroom").ToList();
                floorsTwo.Last(x => x.Level == 4).Facilities = facilitiesTwo.Where(x => x.Name == "Ballroom").ToList();
                floorsTwo.Last(x => x.Level == 6).Facilities = facilitiesTwo.Where(x => x.Name == "Roof Garden" || x.Name == "Main Pool").ToList();

                floorsOne.ForEach(x => x.Hotel = hotels.First());
                floorsTwo.ForEach(x => x.Hotel = hotels.Last());

                hotels.First().Floors = floorsOne;                
                hotels.Last().Floors = floorsTwo;

                Data.Hotels = hotels;
                
                var events = new List<Event>();
                events.AddRange(eventsOne);
                events.AddRange(eventsTwo);
                Data.Events = events;

                Data.Staff = staff;

                var floors = new List<Floor>();
                floors.AddRange(floorsOne);
                floors.AddRange(floorsTwo);
                Data.Floors = floors;

                var rooms = new List<Room>();
                rooms.AddRange(roomsOne);
                rooms.AddRange(roomsTwo);
                Data.Rooms = rooms;

                var facilities = new List<Facility>();
                facilities.AddRange(facilitiesOne);
                facilities.AddRange(facilitiesTwo);
                Data.Facilities = facilities;

                GlobalData.Hotel = hotels.First();
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
