public class Ammo : IAmmo
{
    private int _currentAmmo;

    public int CurrentAmmo => _currentAmmo;

    public Ammo(int initialAmmo)
    {
        _currentAmmo = initialAmmo;
    }

    public bool HasAmmo()
    {
        return _currentAmmo > 0;
    }

    public void UseAmmo()
    {
        if(_currentAmmo > 0)
            _currentAmmo--;
    }
}
