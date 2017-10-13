using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Helpers;
using ORM.Entities;

namespace ORM
{
    /// <summary>
    /// Service class for database initializing
    /// </summary>
    public class DropCreateDbInitializer: CreateDatabaseIfNotExists<SocialNetworkContext>
    {
        /// <summary>
        /// Method which creates all Roles, Administrator and test users.
        /// </summary>
        /// <param name="context">Context name.</param>
        protected override void Seed(SocialNetworkContext context)
        {
            #region Roles

            new List<Role>
            {
                new Role {Name = "Admin"},
                new Role {Name = "ActiveUser"},
                new Role {Name = "Moderator" },
                new Role {Name = "BannedUser" }
            }.ForEach(r => context.Roles.Add(r));

            #endregion

            #region Users and Profiles

            var admin = new User
            {
                UserName = "admin",
                Password = Crypto.HashPassword("root"),
                Email = "admin@gmail.com",
                RoleId = 1,
                Profile = new Profile
                {
                    UserName = "admin",
                    FirstName = "Artiom",
                    LastName = "Regino",
                    AboutMe = "Spending time programming.",
                    Gender = true,
                    BirthDate = new DateTime(1996, 11, 4),
                    City = "Minsk",
                    ContactPhone = "+375293996898",
                    PhotoId = 1,
                    Photos = new List<Photo>
                    {
                        new Photo
                        {
                            IsAvatar = true,
                            ProfileId = 1
                        }
                    }
                }
            };
            var user1 = new User
            {
                UserName = "hayley",
                Password = Crypto.HashPassword("paramore"),
                Email = "hayley@gmail.com",
                RoleId = 2,
                Profile = new Profile
                {
                    UserName = "hayley",
                    FirstName = "Hayley",
                    LastName = "Williams",
                    AboutMe = "New album soon.",
                    BirthDate = new DateTime(1988, 12, 27),
                    City = "Meridian",
                    Gender = false,
                    ContactPhone = "+563846104873",
                    PhotoId = 2,
                    Photos = new List<Photo>
                    {
                        new Photo
                        {
                            IsAvatar = true,
                            ProfileId = 2
                        }
                    }
                }
            };

            var user2 = new User
            {
                UserName = "jaredl",
                Password = Crypto.HashPassword("30stm"),
                Email = "jaredl@gmail.com",
                RoleId = 2,
                Profile = new Profile
                {
                    UserName = "jaredl",
                    FirstName = "Jared",
                    LastName = "Leto",
                    AboutMe = "Like music",
                    BirthDate = new DateTime(1984, 10, 25),
                    City = "Bossier City",
                    Gender = true,
                    ContactPhone = "+746231965438",
                    PhotoId = 3,
                    Photos = new List<Photo>
                    {
                        new Photo
                        {
                            IsAvatar = true,
                            ProfileId = 3
                        }
                    }
                }
            };

            var user3 = new User
            {
                UserName = "emmy",
                Password = Crypto.HashPassword("emmy1986"),
                Email = "emmy.rossum@gmail.com",
                RoleId = 2,
                Profile = new Profile
                {
                    UserName = "emmy",
                    FirstName = "Emmy",
                    LastName = "Rossum",
                    AboutMe = "Just married!",
                    BirthDate = new DateTime(1986, 9, 12),
                    City = "New York",
                    Gender = false,
                    ContactPhone = "+362514293834",
                    PhotoId = 4,
                    Photos = new List<Photo>
                    {
                        new Photo
                        {
                            IsAvatar = true,
                            ProfileId = 4
                        }
                    }
                }
            };

            var user4 = new User
            {
                UserName = "guberman",
                Password = Crypto.HashPassword("guberman1936"),
                Email = "igor.guberman@gmail.com",
                RoleId = 2,
                Profile = new Profile
                {
                    UserName = "guberman",
                    FirstName = "Igor",
                    LastName = "Guberman",
                    AboutMe = "Will be in Jerusalem today.",
                    BirthDate = new DateTime(1936, 7, 7),
                    City = "Jerusalem",
                    Gender = true,
                    ContactPhone = "+362530598437",
                    PhotoId = 5,
                    Photos = new List<Photo>
                    {
                        new Photo
                        {
                            IsAvatar = true,
                            ProfileId = 5
                        }
                    }
                }
            };

            var user5 = new User
            {
                UserName = "william",
                Password = Crypto.HashPassword("macy1950"),
                Email = "william.macy@gmail.com",
                RoleId = 2,
                Profile = new Profile
                {
                    UserName = "william",
                    FirstName = "William",
                    LastName = "Macy",
                    AboutMe = "How about some beer?",
                    BirthDate = new DateTime(1950, 3, 13),
                    City = "Miami",
                    Gender = true,
                    ContactPhone = "+394827364598",
                    PhotoId = 6,
                    Photos = new List<Photo>
                    {
                        new Photo
                        {
                            IsAvatar = true,
                            ProfileId = 6
                        }
                    }
                }
            };

            var user6 = new User
            {
                UserName = "cameron",
                Password = Crypto.HashPassword("monaghan1993"),
                Email = "cameron.monaghan@gmail.com",
                RoleId = 2,
                Profile = new Profile
                {
                    UserName = "cameron",
                    FirstName = "Cameron",
                    LastName = "Monaghan",
                    AboutMe = "Enjoy dancing:)",
                    BirthDate = new DateTime(1993, 8, 16),
                    City = "Santa Monica",
                    Gender = true,
                    ContactPhone = "+827364519234",
                    PhotoId = 7,
                    Photos = new List<Photo>
                    {
                        new Photo
                        {
                            IsAvatar = true,
                            ProfileId = 7
                        }
                    }
                }
            };

            var user7 = new User
            {
                UserName = "JeremyWhite",
                Password = Crypto.HashPassword("Jeremy1991"),
                Email = "jeremy.white@gmail.com",
                RoleId = 3,
                Profile = new Profile
                {
                    UserName = "JeremyWhite",
                    FirstName = "Jeremy",
                    LastName = "White",
                    AboutMe = "Just read Allen Carr. Incredible thing!!",
                    BirthDate = new DateTime(1991, 2, 18),
                    City = "New York",
                    Gender = true,
                    ContactPhone = "+382736459823",
                    PhotoId = 8,
                    Photos = new List<Photo>
                    {
                        new Photo
                        {
                            IsAvatar = true,
                            ProfileId = 8
                        }
                    }
                }
            };

            var user8 = new User
            {
                UserName = "watson",
                Password = Crypto.HashPassword("watson1990"),
                Email = "emma.watson@gmail.com",
                RoleId = 2,
                Profile = new Profile
                {
                    UserName = "watson",
                    FirstName = "Emma",
                    LastName = "Watson",
                    AboutMe = "Have fun in New York.",
                    BirthDate = new DateTime(1990, 5, 15),
                    City = "Paris",
                    Gender = false,
                    ContactPhone = "+375643294856",
                    PhotoId = 9,
                    Photos = new List<Photo>
                    {
                        new Photo
                        {
                            IsAvatar = true,
                            ProfileId = 9
                        }
                    }
                }
            };

            var user9 = new User
            {
                UserName = "duchovny",
                Password = Crypto.HashPassword("duchovny1960"),
                Email = "david.duchovny@gmail.com",
                RoleId = 2,
                Profile = new Profile
                {
                    UserName = "duchovny",
                    FirstName = "David",
                    LastName = "Duchovny",
                    AboutMe = "Californication started.",
                    BirthDate = new DateTime(1960, 8, 7),
                    City = "New York",
                    Gender = true,
                    ContactPhone = "+934756832945",
                    PhotoId = 10,
                    Photos = new List<Photo>
                    {
                        new Photo
                        {
                            IsAvatar = true,
                            ProfileId = 10
                        }
                    }
                }
            };

            var user10 = new User
            {
                UserName = "poperechnyy",
                Password = Crypto.HashPassword("poperechnyy1994"),
                Email = "poperechnyy@gmail.com",
                RoleId = 2,
                Profile = new Profile
                {
                    UserName = "poperechnyy",
                    FirstName = "Danila",
                    LastName = "Poperechnyy",
                    AboutMe = "Now in USA.",
                    BirthDate = new DateTime(1994, 3, 10),
                    City = "Voronezh",
                    Gender = false,
                    ContactPhone = "+435647586912",
                    PhotoId = 11,
                    Photos = new List<Photo>
                    {
                        new Photo
                        {
                            IsAvatar = true,
                            ProfileId = 11
                        }
                    }
                }
            };

            var user11 = new User
            {
                UserName = "dudy",
                Password = Crypto.HashPassword("simplepassword"),
                Email = "yury.yury@gmail.com",
                RoleId = 4,
                Profile = new Profile
                {
                    UserName = "dudy",
                    FirstName = "Yury",
                    LastName = "Dudy",
                    AboutMe = "Subscride to my channel.",
                    BirthDate = new DateTime(1986, 10, 11),
                    City = "Potsdam",
                    Gender = true,
                    ContactPhone = "+394857623645",
                    PhotoId = 12,
                    Photos = new List<Photo>
                    {
                        new Photo
                        {
                            IsAvatar = true,
                            ProfileId = 12
                        }
                    }
                }
            };

            #endregion

            #region Friendships

            var frienship1 = new Friendship
            {
                UserFromId = 1,
                UserToId = 2,
                RequestDate = DateTime.Now,
                IsConfirmed = true
            };
            var frienship2 = new Friendship
            {
                UserFromId = 4,
                UserToId = 2,
                RequestDate = DateTime.Now,
                IsConfirmed = true
            };
            var frienship3 = new Friendship
            {
                UserFromId = 2,
                UserToId = 3,
                RequestDate = DateTime.Now,
                IsConfirmed = true
            };
            var frienship4 = new Friendship
            {
                UserFromId = 3,
                UserToId = 1,
                RequestDate = DateTime.Now,
                IsConfirmed = true
            };
            var frienship5 = new Friendship
            {
                UserFromId = 1,
                UserToId = 4,
                RequestDate = DateTime.Now,
                IsConfirmed = true
            };
            var frienship6 = new Friendship
            {
                UserFromId = 1,
                UserToId = 5,
                RequestDate = DateTime.Now,
                IsConfirmed = true
            };
            var frienship7 = new Friendship
            {
                UserFromId = 2,
                UserToId = 5,
                RequestDate = DateTime.Now,
                IsConfirmed = true
            };
            var frienship8 = new Friendship
            {
                UserFromId = 10,
                UserToId = 6,
                RequestDate = DateTime.Now,
                IsConfirmed = true
            };
            var frienship9 = new Friendship
            {
                UserFromId = 1,
                UserToId = 8,
                RequestDate = DateTime.Now,
                IsConfirmed = true
            };

            var frienship10 = new Friendship
            {
                UserFromId = 4,
                UserToId = 9,
                RequestDate = DateTime.Now,
                IsConfirmed = true
            };

            var frienship11 = new Friendship
            {
                UserFromId = 4,
                UserToId = 3,
                RequestDate = DateTime.Now,
                IsConfirmed = true
            };

            var frienship12 = new Friendship
            {
                UserFromId = 10,
                UserToId = 1,
                RequestDate = DateTime.Now,
                IsConfirmed = false
            };

            var frienship13 = new Friendship
            {
                UserFromId = 11,
                UserToId = 1,
                RequestDate = DateTime.Now,
                IsConfirmed = false
            };

            var frienship14 = new Friendship
            {
                UserFromId = 12,
                UserToId = 1,
                RequestDate = DateTime.Now,
                IsConfirmed = false
            };
            var frienship15 = new Friendship
            {
                UserFromId = 9,
                UserToId = 1,
                RequestDate = DateTime.Now,
                IsConfirmed = false
            };

            var frienship16 = new Friendship
            {
                UserFromId = 6,
                UserToId = 7,
                RequestDate = DateTime.Now,
                IsConfirmed = true
            };
            var frienship17 = new Friendship
            {
                UserFromId = 10,
                UserToId = 11,
                RequestDate = DateTime.Now,
                IsConfirmed = false
            };

            #endregion

            context.Users.Add(admin);
            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Users.Add(user4);
            context.Users.Add(user5);
            context.Users.Add(user6);
            context.Users.Add(user7);
            context.Users.Add(user8);
            context.Users.Add(user9);
            context.Users.Add(user10);
            context.Users.Add(user11);

            context.SaveChanges();

            context.Friendships.Add(frienship1);
            context.Friendships.Add(frienship2);
            context.Friendships.Add(frienship3);
            context.Friendships.Add(frienship4);
            context.Friendships.Add(frienship5);
            context.Friendships.Add(frienship6);
            context.Friendships.Add(frienship7);
            context.Friendships.Add(frienship8);
            context.Friendships.Add(frienship9);
            context.Friendships.Add(frienship10);
            context.Friendships.Add(frienship11);
            context.Friendships.Add(frienship12);
            context.Friendships.Add(frienship13);
            context.Friendships.Add(frienship14);
            context.Friendships.Add(frienship15);
            context.Friendships.Add(frienship16);
            context.Friendships.Add(frienship17);

            context.SaveChanges();
        }
    
    }
}
