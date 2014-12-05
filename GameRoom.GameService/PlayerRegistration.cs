using System;

namespace GameRoom.GameService
{
    public class PlayerRegistration
    {
        private readonly PlayerExternalProviderIdentity _ExternalProviderIdentity;
        private readonly string _Email;
        private readonly string _Name;

        public PlayerRegistration(PlayerExternalProviderIdentity externalProviderIdentity, string email, string name)
        {
            _ExternalProviderIdentity = externalProviderIdentity;
            _Email = email;
            _Name = name;
        }

        public string Email
        {
            get { return _Email; }
        }

        public string Name
        {
            get { return _Name; }
        }

        public PlayerExternalProviderIdentity ExternalProviderIdentity
        {
            get { return _ExternalProviderIdentity; }
        }
    }

    public class PlayerAdditionalExternalProviderRegistration
    {
        private readonly PlayerExternalProviderIdentity _ExternalProviderIdentity;
        private readonly int _Player;

        public PlayerAdditionalExternalProviderRegistration(int player, PlayerExternalProviderIdentity externalProviderIdentity)
        {
            _ExternalProviderIdentity = externalProviderIdentity;
            _Player = player;
        }

        public PlayerExternalProviderIdentity ExternalProviderIdentity
        {
            get { return _ExternalProviderIdentity; }
        }

        public int Player
        {
            get { return _Player; }
        }
    }

    public class PlayerExternalProviderIdentity
    {
        private readonly string _Provider;
        private readonly string _ProviderUserIdentifier;

        public PlayerExternalProviderIdentity(string provider, string providerUserIdentifier)
        {
            _Provider = provider;
            _ProviderUserIdentifier = providerUserIdentifier;
        }

        public string Provider
        {
            get { return _Provider; }
        }

        public string ProviderUserIdentifier
        {
            get { return _ProviderUserIdentifier; }
        }
    }

    public class Player
    {
        private readonly int _Id;
        private readonly string _Name;
        private readonly string _Email;

        public Player(int id, string name, string email)
        {
            _Id = id;
            _Name = name;
            _Email = email;
        }

        public int Id
        {
            get { return _Id; }
        }

        public string Name
        {
            get { return _Name; }
        }

        public string Email
        {
            get { return _Email; }
        }
    }

    public class AccessToken
    {
        private readonly string _Token;

        public AccessToken(string token)
        {
            _Token = token;
        }

        public string Token
        {
            get { return _Token; }
        }
    }

    public class PlayerAccessToken
    {
        private readonly AccessToken _AccessToken;
        private readonly String _Ticket;
        private readonly DateTime _IssuedAt;
        private readonly DateTime _ExpiresAt;

        public PlayerAccessToken(AccessToken accessToken, string ticket, DateTime issuedAt, DateTime expiresAt)
        {
            _AccessToken = accessToken;
            _Ticket = ticket;
            _IssuedAt = issuedAt;
            _ExpiresAt = expiresAt;
        }

        public AccessToken AccessToken
        {
            get { return _AccessToken; }
        }

        public DateTime IssuedAt
        {
            get { return _IssuedAt; }
        }

        public DateTime ExpiresAt
        {
            get { return _ExpiresAt; }
        }

        public string Ticket
        {
            get { return _Ticket; }
        }
    }

    public interface IPlayerRegistration
    {
        Player RegisterPlayer(PlayerRegistration playerRegistration);
        
        PlayerAccessToken GetAccessTokenForPlayer(Player player);

        Player GetPlayerForAccessToken(AccessToken accessToken);
    }
}