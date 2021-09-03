namespace IdentityServer.Entities
{
    public interface IConcurrencyAware
    {
        string ConcurrencyStamp { get; set; }
    }
}
