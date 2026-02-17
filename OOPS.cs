namespace DSARoadmap.OOPSProblems
{
    public class OOPS
    {
        /// <summary>
        /// Initializes a new instance of the OOPS class and demonstrates basic usage of related types, including
        /// Parent, Child, and MethodOverloading.
        /// </summary>
        /// <remarks>The constructor creates instances of Parent, Child, and MethodOverloading, and
        /// invokes several methods to illustrate their behavior. This is typically used for demonstration or testing
        /// purposes, and may produce console output as a side effect.</remarks>
       public OOPS()
       {
            Console.WriteLine("OOPS Class Constructor");
            Parent parent = new Parent();
            parent.ShowMessage();
            Child child = new Child();
            parent.ShowMessage();
            child.ShowMessage();
            MethodOverloading methodOverloading = new MethodOverloading();
            methodOverloading.PrintData("Alice", "Wonderland");
            methodOverloading.PrintData("Bob", "Builderland", "Flight");
        }
    }

    #region Polymorphism
    #region Method Overloading - Compile Time Polymorphism
    /// <summary>
    /// Provides methods for printing travel information with support for multiple parameter sets.
    /// </summary>
    /// <remarks>Use the overloaded PrintData methods to display details about a traveler and their
    /// destination. Overloads allow specifying additional information, such as the travel mode, to suit different
    /// scenarios.</remarks>
    public class MethodOverloading
    {
        public void PrintData(string name, string destination)
        {
            Console.WriteLine("Name: " + name + ", Destination: " + destination);
        }

        public void PrintData(string name, string destination, string travelMode)
        {
            Console.WriteLine("Name: " + name + ", Destination: " + destination + ", Travel Mode: " + travelMode);
        }
    }
    #endregion

    #region Method Overriding - Run Time Polymorphism
    /// <summary>
    /// Represents a base class that provides a method for displaying a message.
    /// </summary>
    /// <remarks>Derived classes can override the ShowMessage method to customize the displayed
    /// message.</remarks>
    public class Parent
    {
        public void OverHiding()
        {
            Console.WriteLine("Parent Method - Overhiding");
        }

        public virtual void ShowMessage()
        {
            Console.WriteLine("Message from Parent class");
        }
    }

    /// <summary>
    /// Represents a specialized implementation of the Parent class that overrides message display behavior.
    /// </summary>
    /// <remarks>Use this class when a distinct message output is required, differing from the base Parent
    /// class. The ShowMessage method provides a customized message specific to Child instances.</remarks>
    public class Child : Parent
    {
        public override void ShowMessage()
        {
            Console.WriteLine("Message from Child class");
        }
    }
    #endregion

    #region Method Overhiding - Compile Time Polymorphism
    public class ChildOverHiding : Parent
    {
        public new void OverHiding()
        {
            Console.WriteLine("Child Method - Overhiding");
        }
    }
    #endregion
    #endregion
}
