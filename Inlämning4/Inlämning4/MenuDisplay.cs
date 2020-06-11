using System;

namespace Inlämning4
{
    public class MenuDisplay
    {
        public MenuDisplay()
        {
        }
        public void Start()
        {
            //
            FileRepositoryStore storesRepository = new FileRepositoryStore();
            FileManufacturerRepository manufacturersRepository = new FileManufacturerRepository();
            FileProductRepository prodcutsRepository = new FileProductRepository();

            while (true)
            {
                "In the Data base we have stores whit products \t".ToUpper().Dump();
                "IN THE DATA BASE THERE IS THREE TABLES, ONE FOR STORES, ONE FOR PRODUCTS,ONE FOR MANUFACTURER.\n\n\tIN WICH ONE WOULD YOU LIKE TO MAKE CHANGES OR CHECK?".Dump("\t\n");
                Console.WriteLine("\n\tPress 1 for stores\n\tPress 2 for products\n\tPress 3 for Manufacturers\n\tPress Q to Exit".ToUpper());
                var Line = Console.ReadLine().ToUpper();
                if (Line == "Q")
                {
                    storesRepository.Dispose();
                    prodcutsRepository.Dispose();
                    manufacturersRepository.Dispose();
                    "\n\tChanges saved!".ToUpper().Dump();
                    break;
                }
                try
                {
                    var option = int.Parse(Line);
                    if (option == 1)
                    {
                        "\tYou Chose Stores.".ToUpper().Dump();
                        while (true)
                        {
                            "\n\tYou Have the following options for stores...".Dump();
                            "\t1.Add a store\n\t2.Delete a store\n\t3.Change a Store\n\t4.Delete a Product from a Store\n\t5.Search for a Product\n\t6.Search products per price\n\t7.Search wich store has a product\n\t8.Add a product to a store\n\t9. Print Stores Information and i´ts Prodducts  \n\t10.Print Stores iNformation\n\t11.Update a product in a store\n\tQ.To Quit\n".ToUpper().Dump();
                            var input = Console.ReadLine().ToUpper();
                            if (input == "Q")
                            {
                                storesRepository.Dispose();
                                "\n\tChanges saved!".ToUpper().Dump();
                                break;
                            }
                            try
                            {
                                var StoreOPtion = int.Parse(input);
                                if (StoreOPtion == 1)
                                {
                                    try
                                    {
                                        "\tEnter a Name for the new store\n".Dump();
                                        var name = Console.ReadLine();
                                        "\tEnter a Id for the new store. Must be a number\n".Dump();
                                        var Id = int.Parse(Console.ReadLine());
                                        storesRepository.CreateStore(name, Id);
                                    }
                                    catch (Exception msg)
                                    {

                                        msg.Dump();
                                    }
                                }
                                else if (StoreOPtion == 2)
                                {
                                    try
                                    {
                                        "\t#Enter the Id of the Store that you would like to Delete#\n".Dump();
                                        "\tYou have the available ID´s\n".Dump();
                                        System.Threading.Thread.Sleep(1000);
                                        storesRepository.PrintStoresInformation();
                                        var Id = int.Parse(Console.ReadLine());
                                        storesRepository.DeleteStore(Id);
                                    }
                                    catch (Exception msg)
                                    {

                                        msg.Message.Dump(); ;
                                    }
                                }
                                else if (StoreOPtion == 3)
                                {
                                    try
                                    {
                                        "\n\t#Enter the Id of the Store that you would like to Update#".Dump();
                                        "\n\tYou have the available ID´s".Dump();
                                        System.Threading.Thread.Sleep(1000);
                                        storesRepository.PrintStoresInformation();
                                        var IdToChange = int.Parse(Console.ReadLine());

                                        "\n\tEnter the New Name for the Store".Dump();
                                        var name = Console.ReadLine();
                                        "\tEnter the new Id If you want the id to be different, and the Id has to be different from the other id stores".ToUpper().Dump();
                                        var newId = int.Parse(Console.ReadLine());
                                        storesRepository.UpdateStore(IdToChange, name, newId);
                                    }
                                    catch (Exception msg)
                                    {

                                        msg.Message.Dump();
                                    }

                                }
                                else if (StoreOPtion == 4)
                                {
                                    try
                                    {
                                        "\n\tEnter the id of the store and id of the product that would you like to delete".ToUpper().Dump();
                                        System.Threading.Thread.Sleep(1000);
                                        storesRepository.PrintStoresInformationAndProducts();
                                        "\n\tEnter the id of the Store".Dump();
                                        var storeId = int.Parse(Console.ReadLine());
                                        "\n\tEnter the id of the Product".Dump();
                                        var ProductId = int.Parse(Console.ReadLine());
                                        storesRepository.DeleteProductFromStore(storeId, ProductId);
                                    }
                                    catch (Exception msg)
                                    {
                                        msg.Message.Dump();
                                    }

                                }
                                else if (StoreOPtion == 5)
                                {
                                    "\n\tEnter the Name fo the Product that you wanna search for\n".ToUpper().Dump();
                                    var Product = Console.ReadLine();
                                    Console.Clear();
                                    "\n".Dump();
                                    storesRepository.SearchProduct(Product);
                                }
                                else if (StoreOPtion == 6)
                                {
                                    try
                                    {
                                        "\n\tEnter the Price that you wanna filter with\n".ToUpper().Dump();
                                        var price = double.Parse(Console.ReadLine());
                                        storesRepository.SearchProductsPerPrice(price);
                                    }
                                    catch (Exception msg)
                                    {

                                        msg.Message.Dump();
                                    }

                                }
                                else if (StoreOPtion == 7)
                                {
                                    "\n\tEnter the name of the product that you wanna search for\n".ToUpper().Dump();
                                    var product = Console.ReadLine();
                                    var stringDistance = new JaroWinklerDistance();
                                    storesRepository.WichStoreHasTheProduct(stringDistance, product);
                                }
                                else if (StoreOPtion == 8)
                                {
                                    try
                                    {
                                        storesRepository.PrintStoresInformation();
                                        "\n\tEnter the id of the store to add the product to\n".Dump();
                                        var idStore = int.Parse(Console.ReadLine());
                                        prodcutsRepository.PrintProductsInformation();
                                        "\tEnter a id for the product\n".Dump();
                                        var idProduct = int.Parse(Console.ReadLine());
                                        var product = prodcutsRepository.GetProduct(idProduct);
                                        storesRepository.AddProductToAstore(idStore, product);
                                    }
                                    catch (Exception msg)
                                    {
                                        msg.Message.Dump();
                                    }
                                }
                                else if (StoreOPtion == 9)
                                {
                                    storesRepository.PrintStoresInformationAndProducts();
                                }
                                else if (StoreOPtion == 10)
                                {
                                    storesRepository.PrintStoresInformation();

                                }
                                else if (StoreOPtion == 11)
                                {
                                    try
                                    {
                                        storesRepository.PrintStoresInformationAndProducts();
                                        "\n\tEnter the id of the store\n".ToUpper().Dump();
                                        var storeId = int.Parse(Console.ReadLine());
                                        "\n\tEnter the id of the product\n".ToUpper().Dump();
                                        var productId = int.Parse(Console.ReadLine());
                                        "\n\tEnter the new Name for the product\n".ToUpper().Dump();
                                        var name = Console.ReadLine();
                                        "\n\tEnter the new Id for the product\n".ToUpper().Dump();
                                        var id = int.Parse(Console.ReadLine());
                                        "\n\tEnter the new price for the product\n".ToUpper().Dump();
                                        var price = int.Parse(Console.ReadLine());
                                        storesRepository.UpdateProductInStore(storeId, productId, price, id, name);
                                    }
                                    catch (Exception msg)
                                    {
                                        msg.Message.Dump();
                                    }
                                }
                                else
                                {
                                    "\n\tThe option is not Available\n".Dump();
                                }
                            }
                            catch (Exception msg)
                            {

                                msg.Dump();
                            }
                        }

                    }
                    else if (option == 2)
                    {
                        "\n\tYou Chose Products!\n".ToUpper().Dump();
                        while (true)
                        {
                            "\n\tYou Have the following options for Products...".Dump();
                            "\n\t1.Create a Product\n\t2.Delete a Product\n\t3.Update a Product\n\t4.Search for a Product\n\t5.Show Products Information\n\t6.Show The amount of each Product we have in Products Stock\n\tQ. To Quit".Dump();
                            var input = Console.ReadLine().ToUpper();
                            if (input == "Q")
                            {
                                prodcutsRepository.Dispose();
                                "\n\tChanges saved!\n".ToUpper().Dump();
                                break;
                            }
                            try
                            {
                                var ProductOption = int.Parse(input);
                                if (ProductOption == 1)
                                {
                                    try
                                    {
                                        "\n\tEnter a name for the product\n".Dump();
                                        var name = Console.ReadLine();
                                        "\n\tEnter a id as number\n".Dump();
                                        var id = int.Parse(Console.ReadLine());
                                        "\n\tEnter a price for the Poduct as number\n".Dump();
                                        var price = double.Parse(Console.ReadLine());
                                        "\n\tEnter the id of the manufacturer. Id´s are Following\n".Dump();
                                        manufacturersRepository.PrintManufacturersInformation();
                                        var ManufacturerId = int.Parse(Console.ReadLine());
                                        var manufacturer = manufacturersRepository.GetManufacturer(ManufacturerId);
                                        prodcutsRepository.CreateProduct(name, price, id, manufacturer);
                                    }
                                    catch (Exception msg)
                                    {

                                        msg.Message.Dump();
                                    }

                                }
                                else if (ProductOption == 2)
                                {
                                    try
                                    {
                                        System.Threading.Thread.Sleep(1000);
                                        prodcutsRepository.PrintProductsInformation();
                                        "\n\tEnter the id of the Product that want to delete\n\tYou have the Following information about Products\n".Dump();
                                        var Id = int.Parse(Console.ReadLine());
                                        prodcutsRepository.DeleteProduct(Id);
                                    }
                                    catch (Exception msg)
                                    {

                                        msg.Message.Dump();
                                    }
                                }
                                else if (ProductOption == 3)
                                {
                                    try
                                    {
                                        "\n\tEnter the Id of the product that you wanna update\n\t You have the following information\n".Dump();
                                        "\n\tEnter the Id of the product that you wanna update as number\n".Dump();
                                        var Productid = int.Parse(Console.ReadLine());
                                        "\n\tEnter the New name of the Product\n".Dump();
                                        var name = Console.ReadLine();
                                        "\n\tEnter the new Price as a number\n".Dump();
                                        var price = double.Parse(Console.ReadLine());
                                        "\n\t Enter the new ID as a number\n".Dump();
                                        var id = int.Parse(Console.ReadLine());
                                        "\n\t Enter the the new Name of the manufacturer\n".Dump();
                                        var ManufacturerName = Console.ReadLine();
                                        prodcutsRepository.UpdateProduct(Productid, name, ManufacturerName, id, price);
                                    }
                                    catch (Exception msg)
                                    {

                                        msg.Message.Dump();
                                    }
                                }
                                else if (ProductOption == 4)
                                {
                                    "\n\t Enter the name of the product that you wanna search for\n".Dump();
                                    var product = Console.ReadLine();
                                    var StringDistance = new JaroWinklerDistance();
                                    prodcutsRepository.FindAproduct(StringDistance, product);
                                }
                                else if (ProductOption == 5)
                                {
                                    prodcutsRepository.PrintProductsInformation();
                                }
                                else if (ProductOption == 6)
                                {
                                    prodcutsRepository.StockOfProducts();
                                }
                                else
                                {
                                    "Option not Available".Dump();
                                }
                            }
                            catch (Exception msg)
                            {

                                msg.Dump();
                            }
                        }
                    }
                    else if (option == 3)
                    {
                        "\tYou Chose Manufacturers.".ToUpper().Dump();
                        while (true)
                        {
                            "\n\tYou Have the following options for Manufacturers...".Dump();
                            "\t1.Show Manufacturers Information\n\t2.Show Manufacturer and their products\n\t3.Show Manufacturer and the Amount of each Product\n\tQ. To Quit".ToUpper().Dump();
                            var input = Console.ReadLine().ToUpper();
                            if (input == "Q")
                            {
                                manufacturersRepository.Dispose();
                                "\n\tChanges saved!".ToUpper().Dump();
                                break;
                            }
                            try
                            {
                                var ManufacturersOption = int.Parse(input);
                                if (ManufacturersOption == 1)
                                {
                                    manufacturersRepository.PrintManufacturersInformation();
                                }
                                else if (ManufacturersOption == 2)
                                {

                                    manufacturersRepository.PrintManufacurersProducts();
                                }
                                else if (ManufacturersOption == 3)
                                {
                                    prodcutsRepository.StockOfProducts();
                                }
                                else
                                {
                                    "Option not Available".Dump();
                                }
                            }
                            catch (Exception msg)
                            {

                                msg.Dump();
                            }
                        }
                    }
                    else
                    {
                        "\n\tThere no option Available for the input".ToUpper().Dump();
                    }
                }
                catch (Exception msg)
                {
                    msg.Message.Dump();
                }
            }
        }
    }
}
