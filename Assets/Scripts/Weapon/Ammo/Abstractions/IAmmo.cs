public interface IAmmo
{
    bool HasAmmo();
    void UseAmmo();
    int CurrentAmmo { get; }
}
