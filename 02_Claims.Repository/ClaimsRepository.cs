using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims.Repository
{
    public class ClaimsRepository
    {
        private readonly Queue<Claims> _claimsContext = new Queue<Claims>();
        private int _count;

        public Queue<Claims> SeeAllClaims()
        {
            return _claimsContext;
        }

        public Claims SeeWhoIsNextInQueue()
        {
            if (_claimsContext.Count > 0)
            {
                var claim = _claimsContext.Peek();
                return claim;
            }
            return null;
        }

        public bool AddNewClaim(Claims claim)
        {
            if (claim == null)
            {
                return false;
            }
            else
            {
                _count++;
                claim.ClaimID = _count;
                _claimsContext.Enqueue(claim);

                return true;
            }
        }

        public Claims DequeueClaim()
        {
            return _claimsContext.Dequeue();
        }
    }
}
