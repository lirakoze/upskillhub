using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTreeMVCWebApplication.Entities;

namespace TechTreeMVCWebApplication.Data
{
    public class DbContextSeed
    {
        private static readonly Random _random = new Random();
        private static readonly string[] _swahiliNames = { "Aisha", "Ali", "Fatima", "Hassan", "Jamal", "Nadia", "Salim", "Sara" };
        private static readonly string[] _kirundiNames = { "Balthazar", "Jeanine", "Joseph", "Liliane", "Olivier", "Serge", "Thierry" };
        private static readonly string[] _kenyanNames = { "Wanjiku", "Mwangi", "Kamau", "Nyambura", "Mumbi", "Waweru", "Wachira" };
        private static readonly string[] _lastNames = { "Smith", "Johnson", "Brown", "Garcia", "Davis", "Miller", "Jones", "Wilson" };

        public static async Task SeedAsync(ApplicationDbContext context, ILogger<DbContextSeed> logger)
        {

            if (!context.MediaType.Any())
            {
                context.MediaType.AddRange(GetPreconfiguredMediaTypes());
                await context.SaveChangesAsync();
                logger.LogInformation("Seeded Media Types");
            }

            if (!context.Category.Any())
            {
                context.Category.AddRange(GetPreconfiguredCategories());
                await context.SaveChangesAsync();
                logger.LogInformation("Seeded Categories");
            }

            if (!context.CategoryItem.Any())
            {
                context.CategoryItem.AddRange(GetPreconfiguredCategoryItems());
                await context.SaveChangesAsync();
                logger.LogInformation("Seeded Category Items");


                var contents = await GetPreconfiguredContents(context);

                context.Content.AddRange(contents);
                await context.SaveChangesAsync();
                logger.LogInformation("Seeded Contents");
            }

            
        }

        private static IEnumerable<MediaType> GetPreconfiguredMediaTypes()
        {
            var mediaTypes = new List<MediaType>
            {
                new MediaType {Title = "Video", ThumbnailImagePath = "Images/video.png"},
                new MediaType {Title = "Text", ThumbnailImagePath = "Images/article.png"}
            };

            return mediaTypes;
        }
        private static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    Title = "Programming Fundamentals",
                    Description = "Learn the basics of programming with this introductory course",
                    ThumbnailImagePath = "Images/programming.jpg"
                },
                new Category
                {
                    Title = "Web Development",
                    Description = "Learn how to build web applications using popular frameworks like React and Angular",
                    ThumbnailImagePath = "Images/web.jpg"
                },
                new Category
                {
                    Title = "Mobile App Development",
                    Description = "Get started with mobile app development using popular tools like Android Studio and Xcode",
                    ThumbnailImagePath = "Images/appdev.jpg"
                },
                new Category
                {
                    Title = "Data Science",
                    Description = "Explore the world of data science and learn how to analyze and visualize data using Python and R",
                    ThumbnailImagePath = "Images/datascience.jpg"
                },
                new Category
                {
                    Title = "Cybersecurity",
                    Description = "Learn how to secure your systems and protect against cyber attacks with this comprehensive course",
                    ThumbnailImagePath = "Images/cybersecurity.jpg"
                },
                new Category
                {
                    Title = "Cloud Computing",
                    Description = "Get familiar with cloud computing concepts and learn how to deploy applications on popular cloud platforms like AWS and Azure",
                    ThumbnailImagePath = "Images/cloud.jpg"
                },
                new Category
                {
                    Title = "Database Management",
                    Description = "Master the art of database design and management with this course on SQL and NoSQL databases",
                    ThumbnailImagePath = "Images/database.png"
                },
                new Category
                {
                    Title = "Artificial Intelligence",
                    Description = "Explore the fascinating world of artificial intelligence and learn how to build intelligent systems with machine learning and deep learning techniques",
                    ThumbnailImagePath = "Images/ai.jpg"
                },
                new Category
                {
                    Title = "DevOps",
                    Description = "Learn how to streamline your software development process and improve collaboration between development and operations teams with DevOps practices",
                    ThumbnailImagePath = "Images/devops.jpg"
                },
                new Category
                {
                    Title = "Agile Development",
                    Description = "Discover the benefits of Agile software development and learn how to deliver high-quality software faster with Agile methodologies",
                    ThumbnailImagePath = "Images/agile.jpg"
                }
            };
    }
        private static IEnumerable<CategoryItem> GetPreconfiguredCategoryItems()
        {
            var categoryItems = new List<CategoryItem>()
    {
        new CategoryItem()
        {
            Title = "Introduction to Programming",
            Description = "Learn the fundamentals of programming with this introductory course",
            CategoryId = 1,
            MediaTypeId = 1,
            DateTimeItemReleased = DateTime.Parse("2022-01-01")
        },
        new CategoryItem()
        {
            Title = "Web Development with React",
            Description = "Build web applications with React",
            CategoryId = 2,
            MediaTypeId = 1,
            DateTimeItemReleased = DateTime.Parse("2022-02-01")
        },
        new CategoryItem()
        {
            Title = "Android App Development with Kotlin",
            Description = "Build Android apps with Kotlin",
            CategoryId = 3,
            MediaTypeId = 1,
            DateTimeItemReleased = DateTime.Parse("2023-03-01")
        },
        new CategoryItem()
        {
            Title = "Data Analysis with Python",
            Description = "Analyze data using Python",
            CategoryId = 4,
            MediaTypeId = 1,
            DateTimeItemReleased = DateTime.Parse("2023-04-01")
        },
        new CategoryItem()
        {
            Title = "Cybersecurity Essentials",
            Description = "Learn the basics of cybersecurity",
            CategoryId = 5,
            MediaTypeId = 1,
            DateTimeItemReleased = DateTime.Parse("2023-05-01")
        },
        new CategoryItem()
        {
            Title = "Cloud Deployment with AWS",
            Description = "Deploy applications on AWS",
            CategoryId = 6,
            MediaTypeId = 1,
            DateTimeItemReleased = DateTime.Parse("2023-06-01")
        },
        new CategoryItem()
        {
            Title = "SQL Database Design",
            Description = "Learn how to design SQL databases",
            CategoryId = 7,
            MediaTypeId = 1,
            DateTimeItemReleased = DateTime.Parse("2023-07-01")
        },
        new CategoryItem()
        {
            Title = "Deep Learning with TensorFlow",
            Description = "Build intelligent systems with TensorFlow",
            CategoryId = 8,
            MediaTypeId = 1,
            DateTimeItemReleased = DateTime.Parse("2023-08-01")
        },
        new CategoryItem()
        {
            Title = "DevOps Fundamentals",
            Description = "Learn the basics of DevOps",
            CategoryId = 9,
            MediaTypeId = 1,
            DateTimeItemReleased = DateTime.Parse("2022-09-01"),
        }
    };

            return categoryItems;
        }
        private async static Task<IEnumerable<Content>> GetPreconfiguredContents(ApplicationDbContext context)
        {
            return new List<Content>
            {
                new Content
                {
                    Title = "Introduction to Programming",
                    HTMLContent = "<p>This course will introduce you to the fundamentals of programming, including variables, data types, control structures, and functions. You will learn how to write code in a variety of programming languages, including C++, Java, and Python.</p>",
                    CatItemId= 1,
                    VideoLink = "https://www.youtube.com/embed/zOjov-2OZ0E?autoplay=1&mute=1",
                    CategoryItem= await context.CategoryItem.FindAsync(1),
        },
                new Content
                {
                    Title = "React Fundamentals",
                    HTMLContent = "<p>In this course, you will learn the fundamentals of React, a popular JavaScript library for building user interfaces. You will learn how to create React components, use JSX syntax, and manage state and props.</p>",
                    CatItemId = 2,
                    VideoLink = "https://www.youtube.com/embed/bMknfKXIFA8?autoplay=1&mute=1",
                     CategoryItem= await context.CategoryItem.FindAsync(2),
                },
                new Content
                {
                    Title = "Kotlin for Android Development",
                    HTMLContent = "<p>Kotlin is a modern programming language that is becoming increasingly popular for Android development. In this course, you will learn the basics of Kotlin and how to use it to build Android apps.</p>",
                    CatItemId = 3,
                    VideoLink = "https://www.youtube.com/embed/fis26HvvDII?autoplay=1&mute=1",
                    CategoryItem= await context.CategoryItem.FindAsync(3),
                },
                new Content
                {
                    Title = "Data Analysis with Python",
                    HTMLContent = "<p>Python is a popular programming language for data analysis and visualization. In this course, you will learn how to use Python and popular libraries like NumPy, Pandas, and Matplotlib to analyze and visualize data.</p>",
                    CatItemId = 4,
                    VideoLink = "https://www.youtube.com/embed/OOWAk2aLEfk?autoplay=1&mute=1",
                    CategoryItem= await context.CategoryItem.FindAsync(4),
                },
                new Content
                {
                    Title = "Cybersecurity Fundamentals",
                    HTMLContent = "<p>Cybersecurity is an increasingly important field as more and more of our lives move online. In this course, you will learn the fundamentals of cybersecurity, including encryption, network security, and risk management.</p>",
                    CatItemId = 5,
                    VideoLink = "https://www.youtube.com/embed/inWWhr5tnEA?autoplay=1&mute=1",
                    CategoryItem= await context.CategoryItem.FindAsync(5),
                },
                new Content
                {
                    Title = "Introduction to AWS",
                    HTMLContent = "<p>Amazon Web Services (AWS) is a popular cloud computing platform used by companies of all sizes. In this course, you will learn the basics of AWS, including how to set up virtual servers, databases, and storage.</p>",
                    CatItemId = 6,
                    VideoLink = "https://www.youtube.com/embed/r4YIdn2eTm4?autoplay=1&mute=1",
                    CategoryItem= await context.CategoryItem.FindAsync(6),
                },
                new Content
                {
                    Title = "SQL Fundamentals",
                    HTMLContent = "<p>SQL is a popular programming language used for managing data in relational databases. In this course, you will learn the basics of SQL, including how to create tables, insert data, and perform queries.</p>",
                    CatItemId = 7,
                    VideoLink = "https://www.youtube.com/embed/HXV3zeQKqGY?autoplay=1&mute=1",
                    CategoryItem= await context.CategoryItem.FindAsync(7),
                },
                new Content
                {
                    Title = "Machine Learning Fundamentals",
                    HTMLContent = "<p>Explore the fascinating world of artificial intelligence and learn how to build intelligent systems with machine learning techniques.</p>",
                    VideoLink = "https://www.youtube.com/embed/ukzFI9rgwfU?autoplay=1&mute=1",
                    CatItemId = 8,
                    CategoryItem= await context.CategoryItem.FindAsync(8),
                },
                new Content
                {
                    
                    Title = "Introduction to DevOps",
                    HTMLContent = "<p>Learn how to streamline your software development process and improve collaboration between development and operations teams with DevOps practices.</p>",
                    VideoLink = "https://www.youtube.com/embed/5KtRF4NuUWE?autoplay=1&mute=1",
                    CatItemId = 9,
                    CategoryItem= await context.CategoryItem.FindAsync(9),
                },
                new Content
                {
                    Title = "Agile Software Development",
                    HTMLContent = "<p>Discover the benefits of Agile software development and learn how to deliver high-quality software faster with Agile methodologies.</p>",
                    VideoLink = "https://www.youtube.com/embed/VFQtSqChlsk?autoplay=1&mute=1",
                    CatItemId = 10,
                    CategoryItem= await context.CategoryItem.FindAsync(9),
                }
            };
        }

        public static async Task SeedAdminAndUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Create the Admin role if it doesn't already exist
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Create the admin user if it doesn't already exist
            if (await userManager.FindByNameAsync("admin@olp.com") == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin@olp.com",
                    Email = "admin@olp.com",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "Pass@word_123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");

                    foreach (var user in GetUsers())
                    {
                        await userManager.CreateAsync(user, "Pass@word_123");
                    }
                }
                
            }


        }

        public static IEnumerable<ApplicationUser> GetUsers()
         {

            var users = new List<ApplicationUser>();

            for (int i = 0; i < 20; i++)
            {
                var firstName = GetRandomFirstName();
                var lastName = GetRandomLastName();
                var email = $"{firstName}.{lastName}@gmail.com".ToLower();
                var phoneNumber = $"07{GetRandomNumber(8)}";
                var userName = email;

                users.Add(new ApplicationUser
                {
                    UserName = userName,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    FirstName = firstName,
                    LastName = lastName
                });
            }
            return users;
            
        }
        private static string GetRandomLastName()
        {
            var randomIndex = _random.Next(0, 8);
            return _lastNames[randomIndex];
        }

        private static int GetRandomNumber(int digits)
        {
            var maxNumber = (int)Math.Pow(10, digits) - 1;
            return _random.Next(maxNumber);
        }
        private static string GetRandomFirstName()
        {
            var randomIndex = _random.Next(0, 3);
            switch (randomIndex)
            {
                case 0:
                    return _swahiliNames[_random.Next(0, _swahiliNames.Length)];
                case 1:
                    return _kirundiNames[_random.Next(0, _kirundiNames.Length)];
                case 2:
                    return _kenyanNames[_random.Next(0, _kenyanNames.Length)];
                default:
                    return "";
            }
        }
    }
}
