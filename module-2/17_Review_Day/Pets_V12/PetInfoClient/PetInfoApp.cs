﻿using System;
using System.Collections.Generic;
using PetInfoClient.Models;
using PetInfoClient.Services;

namespace PetInfoClient
{
    public class PetInfoApp

    {
        private readonly AuthenticatedApiService authenticatedApiService;
<<<<<<< HEAD
        private readonly PetApiService petApiService;
=======
>>>>>>> 8ce8cdd58186e5c10dff668566049df1796620b6
        private readonly ConsoleService console = new ConsoleService();
        private readonly PetInfoConsoleService petInfoConsole = new PetInfoConsoleService();

        public PetInfoApp(string apiUrl)
        {
            authenticatedApiService = new AuthenticatedApiService(apiUrl);
<<<<<<< HEAD
            petApiService = new PetApiService(apiUrl);
=======
>>>>>>> 8ce8cdd58186e5c10dff668566049df1796620b6
        }

        public void Run()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                // The menu changes depending on whether the user is logged in or not
                if (authenticatedApiService.IsLoggedIn)
                {
                    keepGoing = RunAuthenticated();
                }
                else // User is not yet logged in
                {
                    keepGoing = RunUnauthenticated();
                }
            }
        }

        private bool RunUnauthenticated()
        {
            petInfoConsole.PrintLoginMenu();
            int menuSelection = console.PromptForInteger("Please choose an option", 0, 2, 1);
            while (true)
            {
                if (menuSelection == 0)
                {
                    return false;   // Exit the main menu loop
                }

                if (menuSelection == 1)
                {
                    // Log in
                    Login();
                    return true;    // Keep the main menu loop going
                }

                if (menuSelection == 2)
                {
                    // Register a new user
                    Register();
                    return true;    // Keep the main menu loop going
                }
                console.PrintError("Invalid selection. Please choose an option.");
                console.Pause();
            }
        }

        private bool RunAuthenticated()
        {
            petInfoConsole.PrintMainMenu(authenticatedApiService.Username);
            int menuSelection = console.PromptForInteger("Please choose an option", 0, 6);
            if (menuSelection == 0)
            {
                // Exit the loop
                return false;
            }

            if (menuSelection == 1)
            {
<<<<<<< HEAD
                // list Pets
                ListPets();
=======
                // View your current balance
>>>>>>> 8ce8cdd58186e5c10dff668566049df1796620b6
            }

            if (menuSelection == 2)
            {
                // View your past transfers
            }

            if (menuSelection == 3)
            {
                // View your pending requests
            }

            if (menuSelection == 4)
            {
                // Send TE bucks
            }

            if (menuSelection == 5)
            {
                // Request TE bucks
            }

            if (menuSelection == 6)
            {
                // Log out
                authenticatedApiService.Logout();
                console.PrintSuccess("You are now logged out");
            }

            return true;    // Keep the main menu loop going
        }

<<<<<<< HEAD
        private void ListPets()
        {
            List<Pet> pets = petApiService.GetPets();
            foreach (Pet pet in pets)
            {
                Console.WriteLine(pet);
            }
            Console.WriteLine();
            console.Pause();
        }

=======
>>>>>>> 8ce8cdd58186e5c10dff668566049df1796620b6
        private void Login()
        {
            LoginUser loginUser = petInfoConsole.PromptForLogin();
            if (loginUser == null)
            {
                return;
            }

            try
            {
                ApiUser user = authenticatedApiService.Login(loginUser);
                if (user == null)
                {
                    console.PrintError("Login failed.");
                }
                else
                {
                    console.PrintSuccess("You are now logged in");
                }
            }
            catch (Exception)
            {
                console.PrintError("Login failed.");
            }
            console.Pause();
        }

        private void Register()
        {
            LoginUser registerUser = petInfoConsole.PromptForLogin();
            if (registerUser == null)
            {
                return;
            }
            try
            {
                bool isRegistered = authenticatedApiService.Register(registerUser);
                if (isRegistered)
                {
                    console.PrintSuccess("Registration was successful. Please log in.");
                }
                else
                {
                    console.PrintError("Registration was unsuccessful.");
                }
            }
            catch (Exception)
            {
                console.PrintError("Registration was unsuccessful.");
            }
            console.Pause();
        }



    }
}
