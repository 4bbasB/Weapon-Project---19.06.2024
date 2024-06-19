using WeaponProject.Business.Controller;
using WeaponProject.Business.Services.Implementations;
using WeaponProject.Business.Services.Interfaces;
using WeaponProject.Core.Models;

namespace WeaponProject.CA
{
    public class Program
    {
        static void Main(string[] args)
        {
            IWeaponService weaponService = new WeaponService();
            Weapon weapon = new Weapon();
            Controller.Creator(weapon);
            WeaponMenu(weaponService, weapon);
        }

        static void EditMenu(IWeaponService weaponService, Weapon weapon)
        {
            Console.Clear();
            Console.WriteLine("#############   Edit menu   #############");

            while (true)
            {
                Console.WriteLine("""
                    1.Change Magazine size
                    2.Change Ammo count
                    3.Weapon Menu
                    """);
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        int temp;
                        while (true)
                        {
                            Console.WriteLine("Enter new magazine size:");
                            temp = Controller.ValidInt();
                            if (temp < weapon.CurrentAmmo)
                            {
                                Console.WriteLine("Your ammo count is too much for this magazine!");
                                break;
                            }
                            else
                            {
                                weapon.MagazineSize = temp;
                                Console.WriteLine("Magazine size changed successfully!");
                                break;
                            }
                        }
                        Console.WriteLine("Press any key to return to edit menu...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        int tempAmmo;
                        while (true)
                        {
                            Console.WriteLine("Please change the ammo count:");
                            tempAmmo = Controller.ValidInt();
                            if (tempAmmo > weapon.MagazineSize)
                            {
                                Console.WriteLine("Ammo count can not be more than magazine size!");
                                break;
                            }
                            else
                            {
                                weapon.CurrentAmmo = tempAmmo;
                                Console.WriteLine("Ammo count changed successfully!");
                                break;
                            }
                        }
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid choice, try again!");
                        break;
                }
            }
        }

        static void WeaponMenu(IWeaponService weaponService, Weapon weapon)
        {
            Console.Clear();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("#############   Weapon Menu   #############");
                Console.WriteLine(
                    """
                0 - Info
                1 - Shoot 
                2 - Spray
                3 - Get Ammo
                4 - Reload
                5 - Change Fire Mode
                6 - Exit
                7 - Edit Weapon Features
                """
                    );
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        Console.Clear();
                        Console.WriteLine(weapon.ToString());
                        Console.ReadKey();
                        break;
                    case "1":
                        Console.Clear();
                        weaponService.Shoot(weapon);
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        weaponService.Fire(weapon);
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine($"You have {weaponService.GetRemainBulletCount(weapon)} ammo left!");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        weaponService.Reload(weapon);
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        weaponService.ChangeFireMode(weapon);
                        Console.ReadKey();
                        break;
                    case "6":
                        Console.WriteLine("Exited successfully!");
                        exit = true;
                        break;
                    case "7":
                        EditMenu(weaponService, weapon);
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again!");
                        break;
                }
            }
        }
    }
}
