public interface IAmmo
{
    bool HasAmmo();
    void UseAmmo();
    void AddAmmo(int amount, int maxAmmo);
    int CurrentAmmo { get; }
}
