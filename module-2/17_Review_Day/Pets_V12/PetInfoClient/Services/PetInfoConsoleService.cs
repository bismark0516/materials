﻿using System;
using System.Collections.Generic;
using PetInfoClient.Models;

namespace PetInfoClient.Services
{
    public class PetInfoConsoleService : ConsoleService
    {
        /************************************************************
            Print methods
        ************************************************************/
        public void PrintLoginMenu()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Welcome to PetInfo!");
            Console.WriteLine("1: Login");
            Console.WriteLine("2: Register");
            Console.WriteLine("0: Exit");
            Console.WriteLine("---------");
        }

        public void PrintMainMenu(string username)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine($"Hello, {username}!");
<<<<<<< HEAD
            Console.WriteLine("1: List Pets");
=======
            Console.WriteLine("1: ");
>>>>>>> 8ce8cdd58186e5c10dff668566049df1796620b6
            Console.WriteLine("2: ");
            Console.WriteLine("3: ");
            Console.WriteLine("4: ");
            Console.WriteLine("5: ");
            Console.WriteLine("6: Log out");
            Console.WriteLine("0: Exit");
            Console.WriteLine("---------");
        }
        public LoginUser PromptForLogin()
        {
            string username = PromptForString("User name");
            if (String.IsNullOrWhiteSpace(username))
            {
                return null;
            }
            string password = PromptForHiddenString("Password");

            LoginUser loginUser = new LoginUser
            {
                Username = username,
                Password = password
            };
            return loginUser;
        }

        // Add application-specific UI methods here...


    }
}
