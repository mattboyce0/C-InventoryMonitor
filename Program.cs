using System;

namespace SDAMAssignment
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Inventory Manager Application v1.0");
            

            UserInterface UsrInterface = new UserInterface();
            MainMenu();

            void MainMenu()
            {
                int menuchoice;
                //Console.Clear();

                Console.WriteLine("========================================= ");
                Console.WriteLine("               Main Menu                  ");
                Console.WriteLine("========================================= ");
                Console.WriteLine("     [1] Add an item of stock             ");
                Console.WriteLine("     [2] Take an item of stock            ");
                Console.WriteLine("     [3] View an inventory report         ");
                Console.WriteLine("     [4] View a financial report          ");
                Console.WriteLine("     [5] Display the transaction log      ");
                Console.WriteLine("     [6] Report personal usage for a user ");
                Console.WriteLine("==========================================");
                Console.WriteLine("     [7] Exit Application                 ");
                Console.WriteLine("==========================================");
                Console.WriteLine("                                          ");
                Console.WriteLine("Please enter your selection               ");
                
                try
                {
                    menuchoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Please enter a valid response.");
                    MainMenu();
                }
                catch (System.OverflowException)
                {
                    Console.WriteLine("Please enter a valid response.");
                    MainMenu();
                }
                if (menuchoice == 1)
                {
                    // Add an item of stock
                    // Get details and add item

                    //Item Detail Variable Declaration
                    int ItemID;
                    string ItemName;
                    int ItemQuantity;
                    double ItemPrice;
                    DateTime DateAdded;
                    
                    //Get item details
                    try
                    {
                        // Get item name
                        Console.WriteLine("[>] Please enter the Item Name");
                        ItemName = Console.ReadLine();

                        //Check to make sure string is valid length
                        if (ItemName.Length > 32)
                        {
                            Console.WriteLine("Please enter a string that is less than 32 characters.");
                            throw new System.FormatException("Item name must be less than 32 characters.");
                        }
                        ItemName = ItemName.ToUpper();
                        Console.WriteLine("");


                        Console.WriteLine("[>] Please enter the quantity of the item to add");
                        ItemQuantity = Convert.ToInt32(Console.ReadLine());
                        if (ItemQuantity <= 0)
                        {
                            Console.WriteLine("Please enter a positive value greater than 0.");
                            throw new System.FormatException("Item quantity must be a positive integer greater than 0.");
                        }
                        Console.WriteLine("");

                        Console.WriteLine("[>] Please enter the price of the item in the format ££.pp");
                        ItemPrice = Convert.ToDouble(Console.ReadLine());
                        if (ItemPrice > 9999.99)
                        {
                            Console.WriteLine("Please enter a price in the range £0 - £9999.99");
                            throw new System.FormatException("Item price must not exceed £9999.99");
                        }
                        Console.WriteLine("");

                        DateAdded = DateTime.Now;

                        Console.WriteLine("===========================");
                        Console.WriteLine("         Overview");
                        Console.WriteLine("===========================");
                        Console.WriteLine("\t Item Name:     {0}", ItemName);
                        Console.WriteLine("\t Item Quantity: {0}", ItemQuantity);
                        Console.WriteLine("\t Item Price:    {0}", ItemPrice);
                        Console.WriteLine("\t Date Added:    {0}", DateAdded);
                        Console.WriteLine("============================");
                        Console.WriteLine("");
                        Console.WriteLine("Is the above correct? (Y/N)");

                        if (Console.ReadLine() == "Y")
                        {
                            UsrInterface.AddToStock(ItemName, ItemQuantity, ItemPrice, DateAdded);
                            Console.WriteLine("[>] Item added");
                            
                        }
                        else
                        {
                            MainMenu();
                        }
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Please enter a valid response.");
                        MainMenu();

                    }

                }       // Add Item
                else if (menuchoice == 2)
                {
                    // Take an item of stock
                    // Take item details and remove/subtract item

                    //Item detail variables
                    int ItemID;
                    int QuantityTaken;
                    string UserName;
                    DateTime DateTaken;

                    try
                    {
                        Console.WriteLine("[>] Please enter the Item ID that you wish to take");
                        try
                        {
                            ItemID = Convert.ToInt32(Console.ReadLine());

                        }
                        catch (System.OverflowException)
                        {
                            Console.WriteLine("Please enter a valid item ID.");
                            MainMenu();
                        }
                        Console.WriteLine("");

                        Console.WriteLine("[>] Please enter the name of the user making this transaction.");
                        UserName = Console.ReadLine();
                        if (UserName.Length > 32)
                        {
                            Console.WriteLine("Please enter a string that is less than 32 characters in length.");
                            throw new System.FormatException("Name must be less than 32 characters.");
                        }
                        Console.WriteLine("");

                        Console.WriteLine("[>] Please enter the quantity you wish to take.");
                        QuantityTaken = Convert.ToInt32(Console.ReadLine());

                        DateTaken = DateTime.Now;

                        Console.WriteLine("===========================");
                        Console.WriteLine("         Overview");
                        Console.WriteLine("===========================");
                        Console.WriteLine("\t Item ID:       {0}", ItemID);
                        Console.WriteLine("\t User name:     {0}", UserName);
                        Console.WriteLine("\t Quantity:      {0}", QuantityTaken);
                        Console.WriteLine("\t Date Taken:    {0}", DateTaken);
                        Console.WriteLine("============================");
                        Console.WriteLine("");
                        Console.WriteLine("Is the above correct? (Y/N)");
                        if (Console.ReadLine() == "Y")
                        {
                            UsrInterface.TakeFromStock(ItemID, UserName, QuantityTaken, DateTaken);
                            Console.WriteLine("[>] Item ");
                        }
                        else
                        {
                            MainMenu();
                        }

                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Please enter a valid selection.");
                        MainMenu();
                    }

                }  // Take Item
                else if (menuchoice == 3)
                {
                    // View inventory report
                    // Generate and view an inventory report

                    UsrInterface.ViewInventoryReport();


                }  // View Inventory Report
                else if (menuchoice == 4)
                {
                    // View a financial report
                    // Generate and view a financial report

                    UsrInterface.ViewFinancialReport();
                }  // View Financial Report
                else if (menuchoice == 5)
                {
                    // Display trans log
                    // Generate and display a log of transactions

                    UsrInterface.DisplayTransactionLog();

                }  // Display transaction log
                else if (menuchoice == 6)
                {
                    // Report personal usage
                    // Take user name and generate a transaction report

                    string UserName;

                    try
                    {
                        Console.WriteLine("[>] Please enter the name of the user you wish to view");
                        UserName = Console.ReadLine();
                        UsrInterface.ReportPersonalUsage(UserName);
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Please enter a valid user.");
                        MainMenu();
                    }
                }  // Report personal usage
                else if (menuchoice == 7)
                {
                    // Exit application
                    // ...gracefully
                    Environment.Exit(0);
                }  // exit
                MainMenu();

            }

        }



    }
} 
