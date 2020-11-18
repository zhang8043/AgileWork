namespace Agile.Abp.IdentityServer.Clients
{
    public class SecretCreateOrUpdateDto : SecretBaseDto
    {
        public HashType HashType { get; set; }
    }
}
