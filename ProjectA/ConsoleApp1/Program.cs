using FlowerShopDomain;

public class Program
{
    // Собственный делегат для обработки заказов
    public delegate void OrderHandler(Order order);

    // Событие для добавления нового цветка
    public static event Action<Flower> OnFlowerAdded;

    // Событие для изменения статуса заказа
    public static event Action<Order, OrderStatus> OnOrderStatusChanged;

    private static void Main(string[] args)
    {
        var flowers = new List<Flower>();
        var customers = new List<Customer>();
        var categories = new List<Category>();

        OnFlowerAdded += flower =>
        {
            Console.WriteLine($"New flower added: {flower.Name}, Price: {flower.Price}");
        };

        OnOrderStatusChanged += (order, newStatus) =>
        {
            Console.WriteLine($"Order for flower '{order.Flower.Name}' changed to status: {newStatus}");
        };

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Show all flowers");
            Console.WriteLine("2. Add a flower");
            Console.WriteLine("3. Remove a flower or category");
            Console.WriteLine("4. Update flower price");
            Console.WriteLine("5. Show all categories");
            Console.WriteLine("6. Add a category");
            Console.WriteLine("7. Create an order");
            Console.WriteLine("8. Change order status");
            Console.WriteLine("9. Show all customer orders");
            Console.WriteLine("0. Exit");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ShowFlowers(flowers, flower => flower.Price > 0);
                    break;
                case "2":
                    AddFlower(flowers, categories);
                    break;
                case "3":
                    RemoveFlowerOrCategory(flowers, categories);
                    break;
                case "4":
                    UpdateFlowerPrice(flowers);
                    break;
                case "5":
                    ShowCategories(categories);
                    break;
                case "6":
                    AddCategory(categories);
                    break;
                case "7":
                    CreateOrder(customers, flowers);
                    break;
                case "8":
                    ChangeOrderStatus(customers);
                    break;
                case "9":
                    ShowCustomerOrders(customers);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private static void ShowFlowers(List<Flower> flowers, Predicate<Flower> filter)
    {
        var filteredFlowers = flowers.Where(f => filter(f)).ToList();
        foreach (var flower in filteredFlowers)
        {
            Console.WriteLine($"Flower: {flower.Name}, Price: {flower.Price}, Category: {flower.Category?.Name ?? "No category"}");
        }
    }

    private static void AddFlower(List<Flower> flowers, List<Category> categories)
    {
        Console.Write("Enter flower name: ");
        var flowerName = Console.ReadLine();
        Console.Write("Enter flower price: ");
        if (decimal.TryParse(Console.ReadLine(), out var price))
        {
            var newFlower = new Flower { Name = flowerName, Price = price };

            if (categories.Count == 0)
            {
                Console.WriteLine("No categories available. Please add a category first.");
                return;
            }

            Console.WriteLine("Choose a category for the flower:");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i].Name}");
            }

            if (int.TryParse(Console.ReadLine(), out var categoryIndex) && categoryIndex > 0 && categoryIndex <= categories.Count)
            {
                var selectedCategory = categories[categoryIndex - 1];
                selectedCategory.AddFlower(newFlower);
                flowers.Add(newFlower);

                // Вызываем событие
                OnFlowerAdded?.Invoke(newFlower);
            }
            else
            {
                Console.WriteLine("Invalid category selection.");
            }
        }
        else
        {
            Console.WriteLine("Invalid price.");
        }
    }

    private static void RemoveFlowerOrCategory(List<Flower> flowers, List<Category> categories)
    {
        Console.WriteLine("1. Remove a specific flower");
        Console.WriteLine("2. Remove an entire category");
        var removeChoice = Console.ReadLine();
        if (removeChoice == "1")
        {
            Console.Write("Enter flower name to remove: ");
            var flowerName = Console.ReadLine();
            var flowerToRemove = flowers.FirstOrDefault(f => f.Name == flowerName);
            if (flowerToRemove != null)
            {
                flowerToRemove.Category?.RemoveFlower(flowerToRemove);
                flowers.Remove(flowerToRemove);
                Console.WriteLine("Flower removed.");
            }
            else
            {
                Console.WriteLine("Flower not found.");
            }
        }
        else if (removeChoice == "2")
        {
            Console.Write("Enter category name to remove: ");
            var categoryName = Console.ReadLine();
            var categoryToRemove = categories.FirstOrDefault(c => c.Name == categoryName);
            if (categoryToRemove != null)
            {
                foreach (var flower in categoryToRemove.Flowers.ToList())
                {
                    flowers.Remove(flower);
                }
                categories.Remove(categoryToRemove);
                Console.WriteLine("Category removed.");
            }
            else
            {
                Console.WriteLine("Category not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    private static void UpdateFlowerPrice(List<Flower> flowers)
    {
        Console.Write("Enter flower name to update: ");
        var flowerName = Console.ReadLine();
        var flowerToUpdate = flowers.FirstOrDefault(f => f.Name == flowerName);
        if (flowerToUpdate != null)
        {
            Console.Write("Enter new price: ");
            if (decimal.TryParse(Console.ReadLine(), out var price))
            {
                flowerToUpdate.Price = price;
                Console.WriteLine("Price updated.");
            }
            else
            {
                Console.WriteLine("Invalid price.");
            }
        }
        else
        {
            Console.WriteLine("Flower not found.");
        }
    }

    private static void ShowCategories(List<Category> categories)
    {
        foreach (var category in categories)
        {
            Console.WriteLine($"Category: {category.Name}, Description: {category.Description}, Number of flowers: {category.Flowers.Count}");
        }
    }

    private static void AddCategory(List<Category> categories)
    {
        Console.Write("Enter category name: ");
        var categoryName = Console.ReadLine();
        Console.Write("Enter category description: ");
        var description = Console.ReadLine();

        var newCategory = new Category
        {
            Name = categoryName,
            Description = description
        };

        categories.Add(newCategory);
        Console.WriteLine($"Category '{categoryName}' added successfully.");
    }

    private static void CreateOrder(List<Customer> customers, List<Flower> flowers)
    {
        Console.Write("Enter customer's name: ");
        var customerName = Console.ReadLine();
        var customer = customers.FirstOrDefault(c => c.FullName == customerName);
        if (customer == null)
        {
            customer = new Customer { FullName = customerName };
            customers.Add(customer);
        }

        Console.Write("Enter flower name: ");
        var flowerName = Console.ReadLine();
        var selectedFlower = flowers.FirstOrDefault(f => f.Name == flowerName);
        if (selectedFlower != null)
        {
            var order = customer.CreateOrder(selectedFlower);
            Console.WriteLine("Order created with status 'Pending'.");

            // Используем делегат для обработки заказов
            OrderHandler processOrder = o => Console.WriteLine($"Processing order for flower '{o.Flower.Name}'");
            processOrder(order);
        }
        else
        {
            Console.WriteLine("Flower not found.");
        }
    }

    private static void ChangeOrderStatus(List<Customer> customers)
    {
        Console.Write("Enter customer's name: ");
        var customerName = Console.ReadLine();
        var customer = customers.FirstOrDefault(c => c.FullName == customerName);
        if (customer != null)
        {
            foreach (var order in customer.Orders)
            {
                Console.WriteLine($"Order: {order.Flower.Name}, Status: {order.Status}");
            }

            Console.Write("Enter flower name to change status: ");
            var flowerName = Console.ReadLine();
            var orderToUpdate = customer.Orders.FirstOrDefault(o => o.Flower.Name == flowerName);
            if (orderToUpdate != null)
            {
                Console.WriteLine("1. Approve order");
                Console.WriteLine("2. Cancel order");
                var statusChoice = Console.ReadLine();
                if (statusChoice == "1")
                {
                    orderToUpdate.ApproveOrder();
                    OnOrderStatusChanged?.Invoke(orderToUpdate, OrderStatus.Completed);
                }
                else if (statusChoice == "2")
                {
                    orderToUpdate.CancelOrder();
                    OnOrderStatusChanged?.Invoke(orderToUpdate, OrderStatus.Canceled);
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
            else
            {
                Console.WriteLine("Order not found.");
            }
        }
        else
        {
            Console.WriteLine("Customer not found.");
        }
    }

    private static void ShowCustomerOrders(List<Customer> customers)
    {
        Console.Write("Enter customer's name: ");
        var customerName = Console.ReadLine();
        var customer = customers.FirstOrDefault(c => c.FullName == customerName);
        if (customer != null)
        {
            foreach (var order in customer.Orders)
            {
                Console.WriteLine($"Order: {order.Flower.Name}, Status: {order.Status}");
            }
        }
        else
        {
            Console.WriteLine("Customer not found.");
        }
    }
}