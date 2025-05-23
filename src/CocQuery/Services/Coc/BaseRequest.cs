﻿using System.Text.RegularExpressions;

namespace CocQuery.Services.Coc
{
    public class BaseRequest
    {
        public Guid CorrelationId { get; } = Guid.NewGuid();

        #region WAR_TAG
        private string? _warTag;

        public string? WarTag
        {
            get => _warTag;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("War tag must not be empty");

                if (value == Constants.InvalidWarTag)
                    throw new ArgumentException("War tag is not valid");

                _warTag = value;
            }
        }
        #endregion

        #region CLAN_TAG
        private string? _clanTag;

        public string? ClanTag
        {
            get => _clanTag;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Clan tag must not be empty");

                if (value?.StartsWith(Constants.TagStartChar) == false)
                    throw new ArgumentException($"Clan tags start with hash character '{Constants.TagStartChar}'");

                _clanTag = value;
            }
        }
        #endregion

        #region URI
        private string? _uri;

        public string Uri
        {
            get
            {
                if (_uri == null)
                    throw new InvalidOperationException("Uninitialized property: " + nameof(Uri));

                return _uri;
            }

            set
            {
                _uri = value.Replace("#", "%23");
            }
        }
        #endregion

        #region PLAYER_TAG
        private string? _playerTag;

        public string? PlayerTag
        {
            get => _playerTag;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Player tag must not be empty");

                if (value?.StartsWith(Constants.TagStartChar) == false)
                    throw new ArgumentException($"Player tags start with hash character '{Constants.TagStartChar}'");

                _playerTag = value;
            }
        }
        #endregion

        #region LEAGUE_ID
        private int? _leagueId;

        public int? LeagueId
        {
            get => _leagueId;

            set
            {
                if (!value.HasValue)
                    throw new ArgumentException("League identifier must not be empty");

                _leagueId = value;
            }
        }
        #endregion

        #region LOCATION_ID
        private int? _locationId;

        public int? LocationId
        {
            get => _locationId;

            set
            {
                if (!value.HasValue)
                    throw new ArgumentException("Location identifier must not be empty");

                _locationId = value;
            }
        }
        #endregion

        #region SEASON_ID
        private string? _seasonId;

        public string? SeasonId
        {
            get => _seasonId;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Season identifier must not be empty");

                _seasonId = value;
            }
        }
        #endregion

        #region QUERY
        private Query? _query;

        public Query? Query
        {
            get => _query;

            set
            {
                if (value?.After != null && value?.Before != null)
                    throw new ArgumentException("Only after or before can be specified for a query, not both");

                _query = value;
            }
        }
        #endregion

        #region QUERY_CLANS
        private static readonly Regex _labelIdsRegex = new Regex(@"^\d+(,\d+)*$");

        private QueryClans? _queryClans;
        public QueryClans? QueryClans
        {
            get => _queryClans;

            set
            {
                if (value == null)
                    throw new ArgumentException("At least one filtering parameter must exist");

                if (value.Name != null && value.Name.Length < Constants.MinQueryNameLength)
                    throw new ArgumentException($"Name needs to be at least {Constants.MinQueryNameLength} characters long");

                if (value.LabelIds != null && !_labelIdsRegex.IsMatch(value.LabelIds))
                    throw new ArgumentException($"Invalid format for parameter {nameof(QueryClans.LabelIds)}");

                _queryClans = value;
            }
        }
        #endregion

        /// <summary>
        /// The POST request content or NULL for GET requests.
        /// </summary>
        public object? Content { get; internal set; }
    }
}
