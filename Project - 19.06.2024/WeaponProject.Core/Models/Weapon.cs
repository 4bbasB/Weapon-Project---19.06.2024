namespace WeaponProject.Core.Models;

public class Weapon
{
    public string Name { get; set; }
    public int MagazineSize { get; set; }
    public int CurrentAmmo { get; set; }
    public bool FireMode { get; set; }


    public override string ToString()
    {
        return $"Name: {Name}, Magazine Size: {MagazineSize}, Current Ammo: {CurrentAmmo}, Fire Mode: {(FireMode == true ? "Auto" : "Single")}";
    }
}
