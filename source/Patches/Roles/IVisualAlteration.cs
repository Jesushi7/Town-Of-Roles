namespace TownOfSushi.Roles
{
    public interface IVisualAlteration
    {
        bool TryGetModifiedAppearance(out VisualAppearance appearance);
    }
}