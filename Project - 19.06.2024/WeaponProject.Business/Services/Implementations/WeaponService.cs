using WeaponProject.Business.Services.Interfaces;
using WeaponProject.Core.Models;

namespace WeaponProject.Business.Services.Implementations;

public class WeaponService : IWeaponService
{
    public void Shoot(Weapon weapon)
    {
        if (weapon.CurrentAmmo > 0)
        {
            weapon.CurrentAmmo -= 1;
            Console.WriteLine("dışş!");
        }
        else
        {
            Console.WriteLine("Not enough ammo! Please reload");
        }
    }

    public void Fire(Weapon weapon)
    {
        if (!weapon.FireMode)
        {
            Console.WriteLine("You cant spray with single mode!");
            return;
        }
        if (weapon.CurrentAmmo > 0)
        {
            weapon.CurrentAmmo = 0;
            Console.WriteLine("Dış dış dış dıdışşş!");
        }
        else
        {
            Console.WriteLine("Not enough ammo! Please reload");
        }
    }

    public void ChangeFireMode(Weapon weapon)
    {
        if (weapon.FireMode)
        {
            weapon.FireMode = false;
            Console.WriteLine("Weapon fire mode changed to single");
        }
        else
        {
            weapon.FireMode = true;
            Console.WriteLine("Weapon fire mode changed to auto");
        }

    }

    public int GetRemainBulletCount(Weapon weapon)
    {
        return weapon.CurrentAmmo;
    }

    public void Reload(Weapon weapon)
    {
        if (weapon.CurrentAmmo < weapon.MagazineSize)
        {
            weapon.CurrentAmmo = weapon.MagazineSize;
            Console.WriteLine("Weapon reloaded!");
        }
        else
        {
            Console.WriteLine("Weapon ammo is already full!");
            return;
        }
    }
}
