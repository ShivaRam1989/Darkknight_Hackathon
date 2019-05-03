using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePoll.Models
{
    public class BalletBox
    {
        private static Lazy<BalletBox> _instance = new Lazy<BalletBox>(() => new BalletBox(), true);
        private Dictionary<string,string> dcVoters;
        private Dictionary<string,string> marvelVoters;
        private Dictionary<string, string> allVoters;

        private BalletBox()
        {
            dcVoters = new Dictionary<string, string>();
            marvelVoters = new Dictionary<string, string>();
            allVoters = new Dictionary<string, string>();
        }

        public static BalletBox Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public int DcVotingPercent
        {
            get
            {
                return (dcVoters.Count * 100) / (dcVoters.Count + marvelVoters.Count);
            }
        }

        public int MarvelVotingPercent
        {
            get
            {
                return (marvelVoters.Count * 100) / (dcVoters.Count + marvelVoters.Count);
            }
        }

        public int DcVotingCount
        {
            get
            {
                return dcVoters.Count;
            }
        }

        public int MarvelVotingCount
        {
            get
            {
                return marvelVoters.Count;
            }
        }

        public bool CastVote(string user, string VotedTo)
        {
            bool isVoteCasted = false;
            if(allVoters.TryGetValue(user,out string val))
            {
                return false;
            }

            switch (VotedTo)
            {
                case "DC":
                    isVoteCasted = true;
                    dcVoters[user] = user;
                    break;
                case "Marvel":
                    isVoteCasted = true;
                    marvelVoters[user] = user;
                    break;
                default:
                    isVoteCasted = false;
                    break;

            }
            allVoters[user] = user;
            return isVoteCasted;
        }

    }

    public class Vote
    {

    }





}
