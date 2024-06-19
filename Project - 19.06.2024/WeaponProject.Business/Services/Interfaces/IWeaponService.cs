using WeaponProject.Core.Models;

namespace WeaponProject.Business.Services.Interfaces;

public interface IWeaponService
{
    void Shoot(Weapon weapon);
    void Fire(Weapon weapon);
    int GetRemainBulletCount(Weapon weapon);
    void Reload(Weapon weapon);
    void ChangeFireMode(Weapon weapon);
}
