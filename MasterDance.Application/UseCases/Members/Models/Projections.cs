using System;
using System.Linq.Expressions;
using MasterDance.Domain.Entities;

namespace MasterDance.Application.UseCases.Members.Models
{
    public static class Projections
    {
        public static Expression<Func<Member, MemberModel>> ToMemberModel()
        {
            return m => new MemberModel()
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Image = m.Image,
                MemberGroupId = m.MemberGroupId,
            };
        }

        public static Expression<Func<Document, DocumentModel>> ToDocumentModel()
        {
            return d => new DocumentModel()
            {
                Id = d.Id,
                ExpirationDate = d.ExpirationDate,
                TypeName = d.Type != null ? d.Type.Name : null
            };
        }

        public static Expression<Func<Membership, MembershipModel>> ToModel()
        {
            return x => new MembershipModel()
            {
                Id = x.Id,
                Date = x.Date,
                Amount = x.Amount
                //TODO: calculate paid amount
            };
        }
    }
}