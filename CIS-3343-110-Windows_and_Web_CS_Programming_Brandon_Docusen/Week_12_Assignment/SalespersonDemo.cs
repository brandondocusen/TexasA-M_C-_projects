using System;

public abstract class Salesperson
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    protected Salesperson(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string GetFullName()
    {
        return FirstName + " " + LastName;
    }
}

public interface ISellable
{
    void SalesSpeech();
    void MakeSale(int value);
}

public class RealEstateSalesperson : Salesperson, ISellable
{
    public double TotalValueSold { get; private set; }
    public double TotalCommissionEarned { get; private set; }
    private double CommissionRate { get; set; }

    public RealEstateSalesperson(string firstName, string lastName, double commissionRate)
        : base(firstName, lastName)
    {
        CommissionRate = commissionRate;
    }

    public void SalesSpeech()
    {
        Console.WriteLine("Buy it now or regret it forever.");
    }

    public void MakeSale(int value)
    {
        TotalValueSold += value;
        TotalCommissionEarned += (value * CommissionRate / 100);
    }
}

public class GirlScout : Salesperson, ISellable
{
    public int BoxesSold { get; private set; }

    public GirlScout(string firstName, string lastName)
        : base(firstName, lastName)
    {
    }

    public void SalesSpeech()
    {
        Console.WriteLine("Would you like to buy some cookies? They are delicious and they help us go to camp.");
    }

    public void MakeSale(int boxes)
    {
        BoxesSold += boxes;
    }
}

public class SalespersonDemo
{
    public static void Main()
    {
        RealEstateSalesperson realEstateSalesperson = new RealEstateSalesperson("Diane", "Kendall", 6.0);
        GirlScout girlScout = new GirlScout("Mandy", "Hernandez");

        InteractWithRealEstateSalesperson(realEstateSalesperson);
        InteractWithGirlScout(girlScout);

        DisplayResults(realEstateSalesperson, girlScout);

        Console.WriteLine("Press any key to close this window...");
        Console.ReadKey();
    }

    private static void InteractWithRealEstateSalesperson(RealEstateSalesperson salesperson)
    {
        salesperson.SalesSpeech();
        Console.WriteLine("Enter the value of the house sold (0 to finish):");
        int houseValue;
        while (int.TryParse(Console.ReadLine(), out houseValue) && houseValue != 0)
        {
            salesperson.MakeSale(houseValue);
            Console.WriteLine("Enter the value of another house sold (0 to finish):");
        }
    }

    private static void InteractWithGirlScout(GirlScout scout)
    {
        scout.SalesSpeech();
        Console.WriteLine("Enter the number of boxes of cookies sold (0 to finish):");
        int boxesSold;
        while (int.TryParse(Console.ReadLine(), out boxesSold) && boxesSold != 0)
        {
            scout.MakeSale(boxesSold);
            Console.WriteLine("Enter the number of additional boxes of cookies sold (0 to finish):");
        }
    }

    private static void DisplayResults(RealEstateSalesperson realEstateSalesperson, GirlScout girlScout)
    {
        Console.WriteLine(String.Format("{0} sold {1:C} worth of real estate. At 6%, the total commission earned is {2:C}.",
            realEstateSalesperson.GetFullName(), realEstateSalesperson.TotalValueSold, realEstateSalesperson.TotalCommissionEarned));
        Console.WriteLine(String.Format("{0} sold {1} boxes of cookies.",
            girlScout.GetFullName(), girlScout.BoxesSold));
    }
}