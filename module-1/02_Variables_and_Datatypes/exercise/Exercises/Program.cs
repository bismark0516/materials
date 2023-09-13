using System;

namespace VariableNaming
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            1. 4 birds are sitting on a branch. 1 flies away. How many birds are left on
            the branch?
            */

            // ### EXAMPLE:
            int initialNumberOfBirds = 4;
            int birdsThatFlewAway = 1;
            int remainingNumberOfBirds = initialNumberOfBirds - birdsThatFlewAway;

            /*
            2. There are 6 birds and 3 nests. How many more birds are there than
            nests?
            */

            // ### EXAMPLE:
            int numberOfBirds = 6;
            int numberOfNests = 3;
            int numberOfExtraBirds = numberOfBirds - numberOfNests;


            /*
            3. 3 raccoons are playing in the woods. 2 go home to eat dinner. How
            many raccoons are left in the woods?
            */
            int numberOfRacoons = 3;
            int numberThatGoHome = 2;
            int racoonsRemaining = numberOfRacoons - numberThatGoHome;

            /*
            4. There are 5 flowers and 3 bees. How many less bees than flowers?
            */
            int flowers = 5;
            int bees = 3;
            int beesVersusFlowers = flowers - bees;

            /*
            5. 1 lonely pigeon was eating breadcrumbs. Another pigeon came to eat
            breadcrumbs, too. How many pigeons are eating breadcrumbs now?
            */
            int initialPigeon = 1;
            int newPigeon = 1;
            int totalPigeon = initialPigeon + newPigeon;
            /*
            6. 3 owls were sitting on the fence. 2 more owls joined them. How many
            owls are on the fence now?
            */
            int initialOwls = 3;
            int newOwls = 2;
            int totalOwls = initialOwls + newOwls;

            /*
            7. 2 beavers were working on their home. 1 went for a swim. How many
            beavers are still working on their home?
            */
            int initialBeavers = 2;
            int remainingBeavers = 1;
            int totalBeavers = initialBeavers - remainingBeavers;
            /*
            8. 2 toucans are sitting on a tree limb. 1 more toucan joins them. How
            many toucans in all?
            */
            int initialToucans = 2;
            int newToucans = 1;
            int totalToucans = initialToucans + newToucans;
            /*
            9. There are 4 squirrels in a tree with 2 nuts. How many more squirrels
            are there than nuts?
            */
            int totalSquirrels = 4;
            int totalNuts = 2;
            int squirrelsVersusNuts = totalSquirrels - totalNuts;
            /*
            10. Mrs. Hilt found a quarter, 1 dime, and 2 nickels. How much money did
            she find?
            */
            double quarter = .25;
            double dime = .10;
            double nickel = .05;
            double totalAvailableFunds = quarter + dime + 2 * nickel;
            /*
            11. Mrs. Hilt's favorite first grade classes are baking muffins. Mrs. Brier's
            class bakes 18 muffins, Mrs. MacAdams's class bakes 20 muffins, and
            Mrs. Flannery's class bakes 17 muffins. How many muffins does first
            grade bake in all?
            */
            int brierFirstGradeMuffins = 18;
            int macadamsFirstGradeMuffins = 20;
            int flanneryFirstGradeMuffins = 17;
            int totalMuffinsBaked = brierFirstGradeMuffins + macadamsFirstGradeMuffins + flanneryFirstGradeMuffins;
            /*
            12. Mrs. Hilt bought a yoyo for 24 cents and a whistle for 14 cents. How
            much did she spend in all for the two toys?
            */
            double firstYoyo = .24;
            double firstWhistle = .14;
            double moneySpent = firstYoyo + firstWhistle;
            /*
            13. Mrs. Hilt made 5 Rice Krispies Treats. She used 8 large marshmallows
            and 10 mini marshmallows. How many marshmallows did she use
            altogether?
            */
            int largeMarshmallows = 8;
            int miniMarshmallows = 10;
            int totalMarshmallows = largeMarshmallows + miniMarshmallows;
            /*
            14. At Mrs. Hilt's house, there was 29 inches of snow, and Brecknock
            Elementary School received 17 inches of snow. How much more snow
            did Mrs. Hilt's house have?
            */
            int hiltHouse = 29;
            int brecknockElementary = 17;
            int snowDifferenceHilt = hiltHouse - brecknockElementary;
            /*
            15. Mrs. Hilt has $10. She spends $3 on a toy truck and $2.50 on a pencil
            case. How much money does she have left?
            */
            decimal initialDollarAmount = 10;
            decimal toyTruck = 3;
            decimal pencilCase = 2.5M;
            decimal remainingMoney = initialDollarAmount - toyTruck - pencilCase;

            /*
            16. Josh had 16 marbles in his collection. He lost 7 marbles. How many
            marbles does he have now?
            */
            int initialMarbles = 16;
            int lostMarbles = 7;
            int remainingMarbles = initialMarbles - lostMarbles;
            /*
            17. Megan has 19 seashells. How many more seashells does she need to
            find to have 25 seashells in her collection?
            */
            int meganSeashells = 19;
            int totalSeashells = 25;
            int remainingSeashells = totalSeashells - meganSeashells;
            /*
            18. Brad has 17 balloons. 8 balloons are red and the rest are green. How
            many green balloons does Brad have?
            */
            int totalBalloons = 17;
            int redBalloons = 8;
            int greenBalloons = totalBalloons - redBalloons;
            /*
            19. There are 38 books on the shelf. Marta put 10 more books on the shelf.
            How many books are on the shelf now?
            */
            int initialBookValue = 38;
            int additionalBooks = 10;
            int totalBooks = initialBookValue + additionalBooks;
            /*
            20. A bee has 6 legs. How many legs do 8 bees have?
            */
            int beeLegs = 6;
            int finalBeeLegs = beeLegs * 8;

            /*
            21. Mrs. Hilt bought an ice cream cone for 99 cents. How much would 2 ice
            cream cones cost?
            */
            decimal iceCreamCone = .99M;
            decimal twoIceCreamCone = iceCreamCone * 2;
            /*
            22. Mrs. Hilt wants to make a border around her garden. She needs 125
            rocks to complete the border. She has 64 rocks. How many more rocks
            does she need to complete the border?
            */
            int hiltRocks = 64;
            int hiltTotalRocks = 125;
            int neededRocks = hiltTotalRocks - hiltRocks;
            /*
            23. Mrs. Hilt had 38 marbles. She lost 15 of them. How many marbles does
            she have left?
            */
            int hiltMarbles = 38;
            int missingMarbles = 15;
            int totalMarbles = hiltMarbles - missingMarbles;

            /*
            24. Mrs. Hilt and her sister drove to a concert 78 miles away. They drove 32
            miles and then stopped for gas. How many miles did they have left to drive?
            */
            int concertTotalMiles = 78;
            int currentMileage = 32;
            int mileageLeft = concertTotalMiles - currentMileage;
            /*
            25. Mrs. Hilt spent 1 hour and 30 minutes shoveling snow on Saturday
            morning and 45 minutes shoveling snow on Saturday afternoon. How
            much total time (in minutes) did she spend shoveling snow?
            */
            int saturdayMorningSpentTime = 90;
            int saturdayAfternoonSpentTime = 45;
            int totalTimeSpent = saturdayMorningSpentTime + saturdayAfternoonSpentTime;

            /*
            26. Mrs. Hilt bought 6 hot dogs. Each hot dog cost 50 cents. How much
            money did she pay for all of the hot dogs?
            */
            decimal hotDogPrice = .50M;
            decimal costOfHiltDogs = hotDogPrice * 6;




            /*
            27. Mrs. Hilt has 50 cents. A pencil costs 7 cents. How many pencils can
            she buy with the money she has?
            */
            decimal hiltMoneyAmount = .50M;
            decimal pencialCost = .07M;
            int penciclPurchasingPower = (int) (hiltMoneyAmount / pencialCost);
            /*
            28. Mrs. Hilt saw 33 butterflies. Some of the butterflies were red and others
            were orange. If 20 of the butterflies were orange, how many of them
            were red?
            */
            int totalButterfly = 33;
            int orangeButterfly = 20;
            int redButterfly = totalButterfly - orangeButterfly;
            /*
            29. Kate gave the clerk $1.00. Her candy cost 54 cents. How much change
            should Kate get back?
            */
            decimal kateMoney = 1.00M;
            decimal candyCost = .54M;
            decimal finalChange = kateMoney - candyCost;

            /*
            30. Mark has 13 trees in his backyard. If he plants 12 more, how many trees
            will he have?
            */
            int initialTrees = 13;
            int addedTrees = 12;
            int totalTrees = initialTrees + addedTrees;

            /*
            31. Joy will see her grandma in two days. How many hours until she sees
            her?
            */
            int hoursInADay = 24;
            int joyGrandmaTime = 2;
            int totalWaitHours = joyGrandmaTime * hoursInADay;

            /*
            32. Kim has 4 cousins. She wants to give each one 5 pieces of gum. How
            much gum will she need?
            */
            int kimTotalCousins = 4;
            int pieceOfGum = 5;
            int totalGumGiven = kimTotalCousins * pieceOfGum;
            /*
            33. Dan has $3.00. He bought a candy bar for $1.00. How much money is
            left?
            */
            decimal totalDanDollars = 3.00M;
            decimal candyBarCost = 1.0M;
            decimal remainingDollars = totalDanDollars - candyBarCost;


            /*
            34. 5 boats are in the lake. Each boat has 3 people. How many people are
            on boats in the lake?
            */
            int boatsOnLake = 5;
            int peopleOnBoats = 3;
            int totalPeopleOnBoats = boatsOnLake * peopleOnBoats;
            /*
            35. Ellen had 380 legos, but she lost 57 of them. How many legos does she
            have now?
            */
            int totalLegos = 380;
            int lostLegos = 57;
            int remainingLegos = totalLegos - lostLegos;

            /*
            36. Arthur baked 35 muffins. How many more muffins does Arthur have to
            bake to have 83 muffins?
            */
            int totalMuffinsNeeded = 83;
            int currentMuffinAmount = 35;
            int muffinsNeeded = totalMuffinsNeeded - currentMuffinAmount;
            /*
            37. Willy has 1400 crayons. Lucy has 290 crayons. How many more
            crayons does Willy have then Lucy?
            */
            int willyCrayons = 1400;
            int lucyCrayons = 290;
            int willyCrayonsOverLucy = willyCrayons - lucyCrayons;
            /*
            38. There are 10 stickers on a page. If you have 22 pages of stickers, how
            many stickers do you have?
            */
            int stickersOnPage = 10;
            int pagesOfStickers = 22;
            int totalStickers = stickersOnPage * pagesOfStickers;
            /*
            39. There are 100 cupcakes for 8 children to share. How much will each
            person get if they share the cupcakes equally?
            */
            int totalCupcakes = 100;
            int totalChildren = 8;
            decimal cupcakePerChildren = (decimal) totalCupcakes / totalChildren;
            /*
            40. She made 47 gingerbread cookies which she will distribute equally in
            tiny glass jars. If each jar is to contain six cookies, how many
            cookies will not be placed in a jar?
            */
            int totalGingerbreadCookiesMade = 47;
            int totalCookiesPerJar = 6;
            int remainingCookies = totalGingerbreadCookiesMade % totalCookiesPerJar;
            /*
            41. She also prepared 59 croissants which she plans to give to her 8
            neighbors. If each neighbor received an equal number of croissants,
            how many will be left with Marian?
            */
            int totalCroissantsMade = 59;
            int totalNeighbors = 8;
            int remainingCroissants = totalCroissantsMade % totalNeighbors;
            /*
            42. Marian also baked oatmeal cookies for her classmates. If she can
            place 12 cookies on a tray at a time, how many trays will she need to
            prepare 276 oatmeal cookies at a time?
            */
            int totalCookiesNeeded = 276;
            int cookiesOnATray = 12;
            int traysNeeded = totalCookiesNeeded / cookiesOnATray;

            /*
            43. Marian’s friends were coming over that afternoon so she made 480
            bite-sized pretzels. If one serving is equal to 12 pretzels, how many
            servings of bite-sized pretzels was Marian able to prepare?
            */
            int totalPretzelsMade = 480;
            int pretzelServingSize = 12;
            int totalServingSize = totalPretzelsMade / pretzelServingSize;
            /*
            44. Lastly, she baked 53 lemon cupcakes for the children living in the city
            orphanage. If two lemon cupcakes were left at home, how many
            boxes with 3 lemon cupcakes each were given away?
            */
            int totalLemonCupcakesMade = 53;
            int leftAtHome = 2;
            int amountOfCupcakesPerBox = 3;
            int boxesGivenAway = (totalLemonCupcakesMade - leftAtHome) / amountOfCupcakesPerBox;

            /*
            45. Susie's mom prepared 74 carrot sticks for breakfast. If the carrots
            were served equally to 12 people, how many carrot sticks were left
            uneaten?
            */
            int totalCarrots = 74;
            int totalPeople = 12;
            int uneatenCarrots = totalCarrots % totalPeople;
            /*
            46. Susie and her sister gathered all 98 of their teddy bears and placed
            them on the shelves in their bedroom. If every shelf can carry a
            maximum of 7 teddy bears, how many shelves will be filled?
            */
            int totalTeddyBears = 98;
            int maxShelfLoad = 7;
            int shelvesFilled = totalTeddyBears / maxShelfLoad;

            /*
            47. Susie’s mother collected all family pictures and wanted to place all of
            them in an album. If an album can contain 20 pictures, how many
            albums will she need if there are 480 pictures?
            */
            int totalPictures = 480;
            int albumCapabilities = 20;
            int totalAlbumsNeeded = totalPictures / albumCapabilities;

            /*
            48. Joe, Susie’s brother, collected all 94 trading cards scattered in his
            room and placed them in boxes. If a full box can hold a maximum of 8
            cards, how many boxes were filled and how many cards are there in
            the unfilled box?
            */
            int totalCards = 94;
            int boxMaximum = 8;
            int boxesFilled = totalCards / boxMaximum;
            int remainingCards = totalCards % boxMaximum;
            /*
            49. Susie’s father repaired the bookshelves in the reading room. If he has
            210 books to be distributed equally on the 10 shelves he repaired,
            how many books will each shelf contain?
            */
            int totalSusieDadBooks = 210;
            int totalRepairedShelves = 10;
            int totalBooksOnShelves = totalSusieDadBooks / totalRepairedShelves;

            /*
            50. Cristina baked 17 croissants. If she planned to serve this equally to
            her seven guests, how many will each have?
            */
            decimal totalBakedCroissants = 17;
            decimal totalGuests = 7;
            decimal guestCroissantAmount = totalBakedCroissants / totalGuests;
            /*
            51. Bill and Jill are house painters. Bill can paint a standard room in 2.15 hours, while Jill averages
            1.90 hours. How long will it take the two painters working together to paint 5 standard rooms?
            Hint: Calculate the rate at which each painter can complete a room (rooms / hour), combine those rates,
            and then divide the total number of rooms to be painted by the combined rate.
            */
            double billPaintTime = 2.15;
            double jillPaintTime = 1.90;
            double roomsPerHourBill = 1 / billPaintTime;
            double roomsPerHourJill = 1 / jillPaintTime;
            int roomTotal = 5;
            double combineBillAndJill = roomsPerHourBill + roomsPerHourJill;
            double totalTimeNeeded = roomTotal / combineBillAndJill;


            /*
            52. Create and assign variables to hold a first name, last name, and middle initial. Using concatenation,
            build an additional variable to hold the full name in the order of last name, first name, middle initial. The
            last and first names should be separated by a comma followed by a space, and the middle initial must end
            with a period. Use "Grace", "Hopper, and "B" for the first name, last name, and middle initial.
            Example: "John", "Smith, "D" —> "Smith, John D."
            */
            string firstName = "Grace";
            string middleInitial = "B.";
            string lastName = "Hopper,";
            string fullName = lastName + " " + firstName + " " + middleInitial;
            /*
            53. The distance between New York and Chicago is 800 miles, and the train has already travelled 537 miles.
            What percentage of the trip as a whole number (integer) has been completed?
            */
            int totalDistance = 800;
            int traveledDistance = 537;
            double completedTripPercentage = (double)traveledDistance / totalDistance;
            int tripWholeNumber = (int)(completedTripPercentage * 100);
        }
    }
}
