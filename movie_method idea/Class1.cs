﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace movieLibrary
{
    //most recent copy, keeps rented movies removed
    public class MovieRental
    {
        private string customer;
        private string movie;
        private string phone;
        private string email;
        private string day;
        private string bringBack;

        public string Customer
        {
            get { return this.customer; }
            set { this.customer = value; }
        }

        public string Movie
        {
            get { return this.movie; }
            set { this.movie = value; }
        }

        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Day
        {
            get { return this.day; }
            set { this.day = value; }
        }
        public string Bringback
        {
            get { return this.bringBack; }
            set { this.bringBack = value; }
        }

        public MovieRental()
        {
            this.movie = "Spy";
        }

        public MovieRental(string movie)
        {
            this.movie = movie;
        }

        public void MovieInput()
        {
            StreamWriter writing = new StreamWriter("..\\..\\Inventory.txt", true);//so we know what movies are out at what time
            using (writing)
            {

                //list of movies and prices here

                Dictionary<string, string> movies = new Dictionary<string, string>();

                movies.Add("1", "Spy_14.99");
                movies.Add("2", "Avengers: Age of Ultron_19.99 ");
                movies.Add("3", "Entourage_9.99");
                movies.Add("4", "Pitch Perfect 2_9.99 ");
                movies.Add("5", "Cinderella (2015)_9.99");
                movies.Add("6", "Furious 7 (Extended Edition)_9.99");
                movies.Add("7", "The Age of Adaline_19.99");
                movies.Add("8", "Froning_9.99");
                movies.Add("9", "Mad Max: Fury Road_9.99 ");
                movies.Add("10", "Aloha_9.99");

                Console.WriteLine("How many customer rentals are you going to be entering?");
                int customerInputs = Convert.ToInt32(Console.ReadLine());

                for (int i = 1; i <= customerInputs; i++)
                {
                    foreach (KeyValuePair<string, string> option in movies)
                    {
                        Console.WriteLine(option);
                    }

                    Console.WriteLine();
                    Console.WriteLine("What movie is being taken out? Type the number that corresponds with the movie.");
                    var movie = Console.ReadLine();

                    movies.Remove(movie);

                    Console.WriteLine("Input Customer Name");
                    string customer = Console.ReadLine();
                    if (customer.Contains(" "))
                    {
                        Console.WriteLine("Name is valid.");
                    }

                    else
                    {
                        Console.WriteLine("Name is invalid. Type in the name again.");
                        customer = Console.ReadLine();
                    }

                    Console.WriteLine("Contact Info 1 (Phone, including area code with no spaces or special characters): ");
                    string phone = Console.ReadLine();
                    string correctPhone = phone.Replace("-", "");

                    if (correctPhone.Length != 10 || correctPhone.Contains("(") || correctPhone.Contains(")") || correctPhone.Contains("/") || correctPhone.Contains(" "))
                    {
                        Console.WriteLine("This number is not valid. Please enter number again.");
                        phone = Console.ReadLine();
                    }

                    else
                    {
                        Console.WriteLine("Phone number is valid.");
                    }

                    Console.WriteLine("Contact Info 2: Email");
                    string email = Console.ReadLine();

                    if (email.Contains("@") && email.Contains("."))
                    {
                        Console.WriteLine("Email is valid.");
                    }
                    else
                    {
                        Console.WriteLine("Email is invalid. Please Enter again.");
                        email = Console.ReadLine();
                    }

                    DateTime day = DateTime.Now;
                    DateTime bringBack = DateTime.Now.AddDays(7);

                    Dictionary<string, string> inventory1 = new Dictionary<string, string>();

                    inventory1.Add("", "");
                    inventory1.Add("Customer", customer);
                    inventory1.Add("Movie", movie.ToString());
                    inventory1.Add("Phone", phone);
                    inventory1.Add("Email", email);
                    inventory1.Add("Take Out Date", day.ToShortDateString());
                    inventory1.Add("Return by: ", bringBack.ToShortDateString());
                    inventory1.Add(" ", " ");

                    foreach (KeyValuePair<string, string> item in inventory1)
                    {
                        writing.WriteLine(item.ToString());
                    }
                }
            }
        }
        public void ReturnedMovies()
        {
            StreamReader reader = new StreamReader("..\\..\\Inventory.txt");
            StreamWriter writer = new StreamWriter("..\\..\\LateFile.txt");

            using (reader)
            {
                Console.WriteLine("What customer returned a movie?");
                string returningCustomer = Console.ReadLine();

                foreach (string line in File.ReadLines("..\\..\\Inventory.txt"))
                {
                    Console.WriteLine(line);

                    if (line.Contains(returningCustomer))
                    {
                        Console.WriteLine("User was found in our system.");
                    }
                }
            }

            using (writer)
            {
                Console.WriteLine("Retype Customer's name:");
                string returningCustomer = Console.ReadLine();

                Console.WriteLine("What day was this movie supposed to be returned?");
                string day = Console.ReadLine();

                Console.WriteLine("How many days after " + day + " was the movie returned ?");
                int bringback = Convert.ToInt32(Console.ReadLine());

                if (bringback > 0)
                {
                    Console.WriteLine("Re-enter movie:");
                    string movie = Console.ReadLine();

                    Console.WriteLine("Re-enter email:");
                    string email = Console.ReadLine();
                    if (email.Contains("@") && email.Contains("."))
                    {
                        Console.WriteLine("Email is valid.");
                    }
                    else
                    {
                        Console.WriteLine("Email is invalid. Please Enter again.");
                        email = Console.ReadLine();
                    }

                    Console.WriteLine("Re-enter phone:");
                    string phone = Console.ReadLine();
                    string correctPhone = phone.Replace("-", "");
                    if (phone.Length != 10 || phone.Contains("(") || phone.Contains(")") || phone.Contains("/") || phone.Contains(" "))
                    {
                        Console.WriteLine("This number is not valid. Please enter number again.");
                        phone = Console.ReadLine();
                    }

                    else
                    {
                        Console.WriteLine("Phone number is valid.");
                    }

                    string bringback2 = bringback.ToString();

                    Dictionary<string, string> lateFee = new Dictionary<string, string>();

                    lateFee.Add("", "");
                    lateFee.Add("Customer", returningCustomer);
                    lateFee.Add("Movie", movie);
                    lateFee.Add("Phone", phone);
                    lateFee.Add("Email", email);
                    lateFee.Add("Late Fee", bringback2);
                    lateFee.Add(" ", " ");

                    foreach (KeyValuePair<string, string> set in lateFee)
                    {
                        writer.WriteLine(set.ToString());
                    }
                }
            }
        }
    }
}