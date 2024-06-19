using WeaponProject.Core.Models;

namespace WeaponProject.Business.Controller;

public class Controller
{
    public static void Creator(Weapon weapon)
    {
        Console.Write("Enter Weapon: ");
        while (true)
        {
            var temp = Console.ReadLine();
            if (!string.IsNullOrEmpty(temp))
            {
                weapon.Name = temp;
                break;
            }
            else
            {
                Console.WriteLine("Name can't be null or empty!");
                Console.WriteLine("Please enter a valid name:");
            }
        }
        Console.Write("Enter Weapon's magazine size: ");
        weapon.MagazineSize = ValidInt();
        Console.Write("Enter Weapon's ammo: ");
        while (weapon != null)
        {
            weapon.CurrentAmmo = ValidInt();
            if (!(weapon.CurrentAmmo >= 0 && weapon.CurrentAmmo <= weapon.MagazineSize))
            {
                Console.WriteLine("It can not be negative or bigger than Magazine size.");
                Console.Write("Please enter again: ");
            }
            else
                break;
        }
        Console.WriteLine("Fire modes:");
        Console.WriteLine("1.Auto");
        Console.WriteLine("2.Single");
        Console.Write("Enter Fire mode: ");
        var fireMod = ValidInt();
        while (true)
        {
            if (fireMod == 1)
            {
                weapon.FireMode = true;
                break;
            }
            else if (fireMod == 2)
            {
                weapon.FireMode = false;
                break;
            }
            else
            {
                fireMod = ValidInt();
            }
        }

    }


    public static int ValidInt()
    {
        int number;
        bool isValidInput = false;

        do
        {
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out number))
            {
                isValidInput = true;
                return number;
            }
            else
            {
                Console.WriteLine("That's not a valid integer. Please try again.");
            }
        } while (!isValidInput);
        return number;
    }
}
