using DSARoadmap.Common.CommonServices;
using DSARoadmap.Models;

namespace DSARoadmap.SolvingByLINQ
{
    public class SolvingByLINQ
    {
        #region Variables
        private readonly CommonServices _commonServices;
        #endregion

        #region Constructor
        public SolvingByLINQ(CommonServices commonServices)
        {
            _commonServices = commonServices;
            Console.WriteLine("SolvingByLINQ Class Constructor");
            LINQMethodSyntaxForOperators linqMethodSyntaxForOperators = new LINQMethodSyntaxForOperators();
            _commonServices.WriteArray(linqMethodSyntaxForOperators.GetEvenNumbers(new int[] { 1, 2, 5, 3, 4, 4, 5, 1 }));
            _commonServices.WriteArray(linqMethodSyntaxForOperators.RemoveDuplicatesFromArray(new int[] { 1, 2, 5, 3, 4, 4, 5, 1 }));
            _commonServices.WriteArray(linqMethodSyntaxForOperators.GetCharacterCounts("hello world"));
            Console.WriteLine(linqMethodSyntaxForOperators.RemoveVowels("Hello World"));
            _commonServices.WriteArray(linqMethodSyntaxForOperators.FindDuplicatesAndOrderByDescending(new int[] { 1, 2, 5, 3, 4, 4, 5, 1 }));
            _commonServices.WriteArray(linqMethodSyntaxForOperators.RemoveDuplicateAndTakeNValues(new int[] { 1, 2, 5, 3, 4, 4, 5, 1 }, 1));
            
            List<User> users = new List<User>
            {
                new User { Id = 1, Name = "Alice", Age = 30, IsActive = true, RoleId = 1 },
                new User { Id = 2, Name = "Bob", Age = 22, IsActive = false, RoleId = 2 },
                new User { Id = 3, Name = "Charlie", Age = 28, IsActive = true, RoleId = 1 },
                new User { Id = 4, Name = "Diana", Age = 35, IsActive = true, RoleId = 3 },
                new User { Id = 5, Name = "Eve", Age = 24, IsActive = false, RoleId = 2 },
            };
            
            List<Role> roles = new List<Role>
            {
                new Role { Id = 1, RoleName = "Admin" },
                new Role { Id = 2, RoleName = "User" },
                new Role { Id = 3, RoleName = "Manager" },
            }; 

            List<Order> orders = new List<Order>
            {
                new Order { Id = 1, UserId = 1, Amount = 150.00m, Status = "Completed", CreatedOn = DateTime.Now.AddDays(-10) },
                new Order { Id = 2, UserId = 2, Amount = 250.00m, Status = "Pending", CreatedOn = DateTime.Now.AddDays(-5) },
                new Order { Id = 3, UserId = 3, Amount = 350.00m, Status = "Completed", CreatedOn = DateTime.Now.AddDays(-2) },
                new Order { Id = 4, UserId = 4, Amount = 450.00m, Status = "Pending", CreatedOn = DateTime.Now.AddDays(-1) },
            };

            List<OrderItem> orderItems = new List<OrderItem>
            {
                new OrderItem { Id = 1, OrderId = 1, ProductName = "Product A", Quantity = 2 },
                new OrderItem { Id = 2, OrderId = 1, ProductName = "Product B", Quantity = 1 },
                new OrderItem { Id = 3, OrderId = 2, ProductName = "Product C", Quantity = 5 },
            };

            List<User> adultUsers = linqMethodSyntaxForOperators.GetActiveAdultUsers(users);
            _commonServices.PrintKeyValue(adultUsers, "Active Adult Users: ");
            List<object> userSummary = linqMethodSyntaxForOperators.GetUserSummary(users);
            _commonServices.PrintKeyValue(userSummary, "User Summary: ");
            List<OrderItem> allOrderItemsList = linqMethodSyntaxForOperators.GetAllOrderItems(orders, orderItems);
            _commonServices.PrintKeyValue(allOrderItemsList, "All Order Items: ");
            List<User> sortedUsers = linqMethodSyntaxForOperators.SortUsers(users);
            _commonServices.PrintKeyValue(sortedUsers, "Sorted Users: ");
            List<User> pagedUsers = linqMethodSyntaxForOperators.GetPagedUsers(users, 1, 2);
            _commonServices.PrintKeyValue(pagedUsers, "Paged Users (Page 1, Page Size 2): ");
            var hasPendingOrders = linqMethodSyntaxForOperators.HasPendingOrders(orders);
            Console.WriteLine("Has Pending Orders: ", hasPendingOrders);
            var areAllUsersActive = linqMethodSyntaxForOperators.AreAllUsersActive(users);
            Console.WriteLine("Are All Users Active:  ", areAllUsersActive);
            List<object> totalRevenue = linqMethodSyntaxForOperators.GetTotalRevenue(orders);
            _commonServices.PrintKeyValue(totalRevenue, "Total Revenue: ");
            List<object> orderSummaryByStatus = linqMethodSyntaxForOperators.GetOrderSummaryByStatus(orders);
            _commonServices.PrintKeyValue(orderSummaryByStatus, "Order Summary By Status: ");
            List<object> usersWithRoles = linqMethodSyntaxForOperators.GetUsersWithRoles(users, roles);
            _commonServices.PrintKeyValue(usersWithRoles, "Users With Roles: ");
            List<object> usersWithOptionalRoles = LINQMethodSyntaxForOperators.GetUsersWithOptionalRoles(users, roles);
            _commonServices.PrintKeyValue(usersWithOptionalRoles, "Users With Optional Roles: ");
            User userById = linqMethodSyntaxForOperators.GetUserById(users, 3);
            _commonServices.PrintKeyValue(userById, "User By Id (3): ");
            List<string> uniqueStatuses = linqMethodSyntaxForOperators.GetUniqueStatuses(orders);
            _commonServices.PrintKeyValue(uniqueStatuses, "Unique Statuses: ");
            List<Order> ordersUntilThreshold = linqMethodSyntaxForOperators.GetOrdersUntilThreshold(orders);
            _commonServices.PrintKeyValue(ordersUntilThreshold, "Orders Until Threshold: ");
            string userNamesCsvResult = linqMethodSyntaxForOperators.GetUserNamesCsv(users);
            Console.WriteLine("User Names CSV: " + userNamesCsvResult);
            IEnumerable<User> activeUsersQuery = linqMethodSyntaxForOperators.GetActiveUsersQuery(users);  
            _commonServices.PrintKeyValue(activeUsersQuery.ToList(), "Active Users Query: ");
        }
        #endregion
    }

    public class LINQMethodSyntaxForOperators
    {
        /// <summary>
        /// Returns a collection of even numbers from the specified array, sorted in ascending order.
        /// </summary>
        /// <param name="nums">The array of integers to search for even numbers. Cannot be null.</param>
        /// <returns>An enumerable collection of even integers from the input array, sorted in ascending order. Returns an empty
        /// collection if no even numbers are found.</returns>
        public IEnumerable<int> GetEvenNumbers(int[] nums)
        {
            return nums.Where(x => x % 2 == 0).OrderBy(x => x);
        }

        /// <summary>
        /// Returns a collection of unique integers from the specified array, sorted in ascending order.
        /// </summary>
        /// <param name="nums">An array of integers from which duplicates will be removed. Cannot be null.</param>
        /// <returns>An IEnumerable<int> containing the distinct integers from the input array, ordered from smallest to largest.
        /// If the input array is empty, returns an empty collection.</returns>
        public IEnumerable<int> RemoveDuplicatesFromArray(int[] nums)
        {
            return nums.Distinct().OrderBy(x => x);
        }

        /// <summary>
        /// Counts the occurrences of each character in the specified string.
        /// </summary>
        /// <param name="input">The string to analyze. Can be null or empty.</param>
        /// <returns>A dictionary containing each unique character from the input string as a key, and the number of times that
        /// character appears as the value. Returns an empty dictionary if the input is null or empty.</returns>
        public Dictionary<char, int> GetCharacterCounts(string input)
        {
            return input.GroupBy(c => c)    
                        .ToDictionary(g => g.Key, g => g.Count());
        }

        /// <summary>
        /// Returns a new string in which all vowel characters are removed from the specified input string.
        /// </summary>
        /// <param name="input">The string from which vowels will be removed. Cannot be null.</param>
        /// <returns>A string that consists of the input string with all uppercase and lowercase vowels removed. If the input
        /// string contains no vowels, the original string is returned unchanged.</returns>
        public string RemoveVowels(string input)
        {
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u',
                                             'A', 'E', 'I', 'O', 'U' };

            return new string(input.Where(c => !vowels.Contains(c)).ToArray());
        }

        /// <summary>
        /// Finds all duplicate integers in the specified array and returns them in descending order.
        /// </summary>
        /// <param name="numbers">An array of integers to search for duplicate values. Cannot be null.</param>
        /// <returns>An enumerable collection of integers that appear more than once in the input array, ordered from largest to
        /// smallest. If no duplicates are found, the collection is empty.</returns>
        public IEnumerable<int> FindDuplicatesAndOrderByDescending(int[] numbers)
        {
            return numbers.GroupBy(x => x)
                       .Where(g => g.Count() > 1)
                       .Select(g => g.Key)
                       .OrderByDescending(x => x);
        }

        /// <summary>
        /// Returns a sequence of distinct integers from the input array, limited to the specified number of elements.
        /// </summary>
        /// <param name="numbers">The array of integers from which to remove duplicates and select values. Cannot be null.</param>
        /// <param name="n">The maximum number of distinct values to return. Must be greater than or equal to 0.</param>
        /// <returns>An enumerable collection containing up to the specified number of unique integers from the input array, in
        /// the order they first appear.</returns>
        public IEnumerable<int> RemoveDuplicateAndTakeNValues(int[] numbers, int n)
        {
            return numbers.Distinct()
                          .Take(n);
        }

        /// <summary>
        /// Returns a list of users who are active and older than 25 years.
        /// </summary>
        /// <notes>
        /// Where (Filtering)
        /// Real use: User management / access control
        /// </notes>
        /// <param name="users">The collection of users to filter. Cannot be null.</param>
        /// <returns>A list of users who are active and whose age is greater than 25. The list will be empty if no users match
        /// the criteria.</returns>
        public List<User> GetActiveAdultUsers(List<User> users)
        {
            return users
                .Where(u => u.IsActive && u.Age > 25)
                .ToList();
        }

        /// <summary>
        /// Creates a summary list containing the ID and name of each user in the specified collection.
        /// </summary>
        /// <notes>
        /// SELECT (Projection)
        /// Convert UserModel → UserDTO
        /// Used in: API responses
        /// </notes>
        /// <remarks>Each object in the returned list is an anonymous type with 'Id' and 'Name'
        /// properties. The method does not perform any validation on the user data.</remarks>
        /// <param name="users">The list of users to summarize. Cannot be null.</param>
        /// <returns>A list of objects, each containing the ID and name of a user from the input list. The list is empty if no
        /// users are provided.</returns>
        public List<object> GetUserSummary(List<User> users)
        {
            return users
                .Select(u => new
                {
                    u.Id,
                    u.Name
                })
                .ToList<object>();
        }

        /// <summary>
        /// Retrieves all order items that are associated with the specified orders.
        /// </summary>
        /// <notes>
        /// SELECTMANY (Flattening)
        /// Real use: Orders → Order Items view
        /// </notes>
        /// <param name="orders">A list of orders for which to retrieve associated order items. Cannot be null.</param>
        /// <param name="items">A list of order items to search for associations with the specified orders. Cannot be null.</param>
        /// <returns>A list of order items that are linked to the provided orders. The list is empty if no matching items are
        /// found.</returns>
        public List<OrderItem> GetAllOrderItems(List<Order> orders, List<OrderItem> items)
        {
            return orders
                .SelectMany(o => items.Where(i => i.OrderId == o.Id))
                .ToList();
        }

        /// <summary>
        /// Sorts a list of users by age in ascending order, then by name in descending order for users with the same
        /// age.
        /// </summary>
        /// <notes>
        /// ORDERBY / THENBY
        /// </notes>
        /// <param name="users">The list of users to sort. Cannot be null.</param>
        /// <returns>A new list containing the sorted users. The original list is not modified.</returns>
        public List<User> SortUsers(List<User> users)
        {
            return users
                .OrderBy(u => u.Age)
                .ThenByDescending(u => u.Name)
                .ToList();
        }

        /// <summary>
        /// Retrieves a subset of users corresponding to the specified page and page size.
        /// </summary>
        /// <notes>
        /// SKIP / TAKE (Pagination)
        /// Used in: Grid APIs
        /// </notes>
        /// <param name="users">The list of users to paginate. Cannot be null.</param>
        /// <param name="page">The 1-based page number to retrieve. Must be greater than or equal to 1.</param>
        /// <param name="pageSize">The number of users to include in each page. Must be greater than 0.</param>
        /// <returns>A list of users for the specified page. Returns an empty list if the page exceeds the number of available
        /// users.</returns>
        public List<User> GetPagedUsers(List<User> users, int page, int pageSize)
        {
            return users
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        /// <summary>
        /// Determines whether the specified collection of orders contains any orders with a status of "Pending."
        /// </summary>
        /// <notes>
        /// ANY (Validation Logic)
        /// </notes>
        /// <param name="orders">The list of orders to examine. Cannot be null.</param>
        /// <returns>true if at least one order in the collection has a status of "Pending"; otherwise, false.</returns>
        public bool HasPendingOrders(List<Order> orders)
        {
            return orders.Any(o => o.Status == "Pending");
        }

        /// <summary>
        /// Determines whether all users in the specified collection are active.
        /// </summary>
        /// <notes>
        /// ALL (Validation Logic)
        /// </notes>
        /// <param name="users">A list of users to evaluate. Cannot be null.</param>
        /// <returns>true if every user in the collection is active or if the collection is empty; otherwise, false.</returns>
        public bool AreAllUsersActive(List<User> users)
        {
            return users.All(u => u.IsActive);
        }

        /// <summary>
        /// Calculates summary revenue statistics for a collection of orders.
        /// </summary>
        /// <notes>
        /// COUNT / SUM / AVERAGE
        /// </notes>
        /// <remarks>The returned list always contains exactly one object with the calculated statistics.
        /// The method does not modify the input list.</remarks>
        /// <param name="orders">The list of orders to analyze. Cannot be null.</param>
        /// <returns>A list containing a single anonymous object with the following properties: Total (the sum of the Amount
        /// values), Count (the number of orders), and Average (the average Amount value, or 0 if the list is empty).</returns>
        public List<object> GetTotalRevenue(List<Order> orders)
        {
            return new List<object>
            {
                new
                {
                    Total = orders.Sum(x => x.Amount),
                    orders.Count,
                    Average = orders.Count > 0 ? orders.Average(x => x.Amount) : 0,                    
                }
            };
        }

        /// <summary>
        /// Groups the orders by their status and provides a summary for each status.
        /// </summary>
        /// <notes>
        /// GROUPBY (Reporting)
        /// Real use: Dashboard metrics
        /// </notes>
        /// <param name="orders">The list of orders to group and summarize. Cannot be null.</param>
        /// <returns>A list of objects, each representing a status of orders. Each object contains the status, the count of
        /// orders with that status, and the total amount of those orders. If the orders list is empty, an empty list is
        /// returned.</returns>
        public List<object> GetOrderSummaryByStatus(List<Order> orders)
        {
            return orders
                .GroupBy(o => o.Status)
                .Select(g => new
                {
                    Status = g.Key,
                    Count = g.Count(),
                    TotalAmount = g.Sum(x => x.Amount)
                })
                .ToList<object>();
        }

        /// <summary>
        /// Creates a list of objects that associate each user with their corresponding role name.
        /// </summary>
        /// <notes>
        /// JOIN (User ↔ Role)
        /// </notes>
        /// <remarks>Each object in the returned list is an anonymous type with two properties: Name (from
        /// the user) and RoleName (from the role). The method performs an inner join; only users with a matching role
        /// are included in the result.</remarks>
        /// <param name="users">The collection of users to be matched with roles. Each user must have a valid RoleId that corresponds to a
        /// role in the <paramref name="roles"/> list.</param>
        /// <param name="roles">The collection of roles to match against users. Each role must have a unique Id that can be referenced by
        /// users.</param>
        /// <returns>A list of objects, each containing the user's name and the associated role name. The list is empty if there
        /// are no matching users and roles.</returns>
        public List<object> GetUsersWithRoles(List<User> users, List<Role> roles)
        {
            return users
                .Join(
                    roles,
                    u => u.RoleId,
                    r => r.Id,
                    (u, r) => new
                    {
                        u.Name,
                        r.RoleName
                    })
                .ToList<object>();
        }

        /// <summary>
        /// Creates a list of user and role pairs, including users without assigned roles.
        /// </summary>
        /// <remarks>The returned list contains one entry for each user in the input list. Users without a
        /// matching role in the roles list are included with the role name set to "No Role". The result is a list of
        /// anonymous objects with properties for the user's name and role name.</remarks>
        /// <param name="users">The list of users to include in the result. Each user may or may not have an associated role.</param>
        /// <param name="roles">The list of roles to match with users. Roles are matched to users based on the user's RoleId and the role's
        /// Id.</param>
        /// <returns>A list of objects, each containing a user's name and the name of their associated role. If a user does not
        /// have an assigned role, the role name is set to "No Role".</returns>
        public static List<object> GetUsersWithOptionalRoles(List<User> users, List<Role> roles)
        {
            return users
                .GroupJoin(
                    roles,
                    u => u.RoleId,   // outer key
                    r => r.Id,       // inner key
                    (u, ur) => new { u, ur }
                )
                .SelectMany(
                    x => x.ur.DefaultIfEmpty(),
                    (x, r) => new
                    {
                        x.u.Name,
                        Role = r?.RoleName ?? "No Role"
                    }
                )
                .ToList<object>();
        }

        /// <summary>
        /// Retrieves the first user from the specified list whose identifier matches the given value.
        /// </summary>
        /// <notes>
        /// FIRST / FIRSTORDEFAULT / SINGLE
        /// Single() when exactly one record must exist
        /// </notes>
        /// <param name="users">The list of users to search. Cannot be null.</param>
        /// <param name="id">The unique identifier of the user to locate.</param>
        /// <returns>The user whose Id matches the specified value, or null if no such user is found.</returns>
        public User GetUserById(List<User> users, int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Returns a list of unique status values from the specified collection of orders.
        /// </summary>
        /// <notes>
        /// DISTINCT
        /// </notes>
        /// <param name="orders">The list of orders from which to extract status values. Cannot be null.</param>
        /// <returns>A list of unique status strings found in the orders. The list is empty if no orders are provided.</returns>
        public List<string> GetUniqueStatuses(List<Order> orders)
        {
            return orders
                .Select(o => o.Status)
                .Distinct()
                .ToList();
        }

        /// <summary>
        /// Returns a list of orders from the input collection, ordered by creation date, up to but not including the
        /// first order with an amount greater than 10,000.
        /// </summary>
        /// <notes>
        /// TAKEWHILE / SKIPWHILE
        /// </notes>
        /// <remarks>The method stops including orders once it encounters the first order with an amount
        /// greater than 10,000, even if subsequent orders would otherwise qualify. The input list is not
        /// modified.</remarks>
        /// <param name="orders">The collection of orders to evaluate. Cannot be null.</param>
        /// <returns>A list of orders in ascending order by creation date, containing all orders with an amount less than or
        /// equal to 10,000 that appear before the first order exceeding this threshold. If all orders are below or
        /// equal to the threshold, all are returned. Returns an empty list if no orders meet the criteria.</returns>
        public List<Order> GetOrdersUntilThreshold(List<Order> orders)
        {
            return orders
                .OrderBy(o => o.CreatedOn)
                .TakeWhile(o => o.Amount <= 10000)
                .ToList();
        }

        /// <summary>
        /// Creates a comma-separated string containing the names of all users in the specified list.
        /// </summary>
        /// <notes>
        /// AGGREGATE (Advanced)
        /// </notes>
        /// <remarks>The order of names in the resulting string matches the order of users in the input
        /// list. If the list contains only one user, the result will be that user's name without any commas.</remarks>
        /// <param name="users">The list of users whose names will be included in the resulting CSV string. Cannot be null or empty.</param>
        /// <returns>A comma-separated string of user names from the list.</returns>
        public string GetUserNamesCsv(List<User> users)
        {
            return users
                .Select(u => u.Name)
                .Aggregate((a, b) => $"{a}, {b}");
        }

        /// <summary>
        /// Returns a sequence of users who are currently marked as active.
        /// </summary>
        /// <notes>
        /// DEFERRED EXECUTION DEMO
        /// Execution happens only when: .ToList(), .Count(), foreach
        /// </notes>
        /// <param name="users">The list of users to filter. Cannot be null.</param>
        /// <returns>An enumerable collection of users where each user is active. If no users are active, the collection is
        /// empty.</returns>
        public IEnumerable<User> GetActiveUsersQuery(List<User> users)
        {
            return users.Where(u => u.IsActive);
        }
    }
}
