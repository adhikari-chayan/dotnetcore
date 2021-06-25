using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
   public interface IProposalRepo
    {
        ProposalModel Add(ProposalModel model);
        ProposalModel Approve(int proposalId);
        IEnumerable<ProposalModel> GetAllForConference(int conferenceId);
        ProposalModel GetById(int id);
    }
}
