namespace Warehouse_system;

internal class Program
{

    static void Main(string[] args)
    {
        List<Product> allProducts = new List<Product>();
        allProducts.Add(new Product("Sofa", Product.Status.InStock, 20));
        allProducts.Add(new Product("Table", Product.Status.InStock, 10));
        allProducts.Add(new Product("Chair", Product.Status.RefillNeeded, 9));
        allProducts.Add(new Product("Lamp", Product.Status.OutOfStock, 0));


        //MENU
        bool exit = false;
        do
        {
            Console.WriteLine("Press 1 - Register products");
            Console.WriteLine("Press 2 - Check the product available");
            Console.WriteLine("Press 3 - Place an order");
            Console.WriteLine("Press 4 - Show all products and amounts");
            Console.WriteLine("Press anything else - Exit");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.WriteLine("Option 1 Selected");
                    RegisterProduct(allProducts);
                    break;

                case "2":
                    Console.WriteLine("Option 2 Selected");
                    Console.WriteLine("Please type in the name of the product you want to check");
                    string name = Console.ReadLine();
                    CheckAvailability(allProducts, name);
                    break;

                case "3":
                    Console.WriteLine("Option 3 Selected");
                    Console.WriteLine("What product do you want to order?");
                    string orderName = Console.ReadLine();
                    PlaceOrder(allProducts, orderName);
                    break;

                case "4":
                    Console.WriteLine("Option 4 Selected");
                    foreach (Product product in allProducts)
                    {
                        Console.WriteLine($"Product: {product.Name}, Amount: {product.Quantity}\n");
                    }

                    break;

                default:
                    Console.WriteLine("Invalid key, please try again");
                    break;
            }

            Console.WriteLine("Press any key to return to the Menu");
            Console.ReadLine();
        } while (!exit);

        //register new product
        static void RegisterProduct(List<Product> allProducts)
        {

            bool RegisterNewProduct = true;
            Console.WriteLine("Register new product");
            do
            {

                Console.WriteLine("Type in the name of the product");
                string name = Console.ReadLine();
                Console.WriteLine("Type in the amount of the product");
                int amount = Convert.ToInt32(Console.ReadLine());
                Product.Status pStatus = Product.ChangeStatus(amount);

                Product addedProduct = new Product(name, pStatus, amount);
                allProducts.Add(addedProduct);

                Console.WriteLine("Do you wanna register a new product? Yes / No");
                string answer = Console.ReadLine();
                if (answer == "No")
                {
                    RegisterNewProduct = false;
                    break;
                }

                if (answer == "Yes")
                {
                    Console.WriteLine($"The product is registered:\nProduct name:{name}\n" +
                                      $"Product amount: {amount}\nProduct status: {pStatus}");
                    break;
                }
                //Console.WriteLine("Press any key to return to the Menu");
                //Console.ReadLine();
            } while (RegisterNewProduct);


        }

        //CHECK AVAILABILITY

        void CheckAvailability(List<Product> allProducts, string name)
        {
            foreach (var product in allProducts)
            {
                if (product.Name.ToLower() == name.ToLower())
                {
                    Console.WriteLine($"{product.Name} is {product.PStatus}");
                    return;
                }
            }
            Console.WriteLine("This product does not exist");
        }



        //  PLACE ORDER

        void PlaceOrder(List<Product> allProducts, string orderName)
        {
            foreach (var product in allProducts)
            {
                if (product.Name.ToLower() == orderName.ToLower())
                {
                    Console.WriteLine("What amount of product do you want to order?");
                    int orderAmount = Convert.ToInt32(Console.ReadLine());
                    
                    if (orderAmount <= product.Quantity)
                    {
                        int productRemainder = product.Quantity - orderAmount;
                        Console.WriteLine($"You have ordered {orderAmount} of {orderName}");
                        Console.WriteLine($"There are {productRemainder} more {orderName} in stock");
                        product.PStatus= Product.ChangeStatus(orderAmount);
                        product.Quantity = productRemainder;
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"The amount of {orderName} in stock is less than you want to order");
                        Console.WriteLine($"There are {product.Quantity} of {orderName} in stock");
                        return;
                    }
                }
                
            }
            Console.WriteLine("This product does not exist");
        }

        // CHANGE PRODUCT AMOUNT IF ORDER HAPPENS

        //FUNCTION RO FILL UP THE PRODUCT AND TO CHANGE STATUS TO "REFILL NEEDED"


    }

}

