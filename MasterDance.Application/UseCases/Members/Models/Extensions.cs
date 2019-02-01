using System;
using MasterDance.Domain.Entities;
using MasterDance.Domain.ValueObjects;

namespace MasterDance.Application.UseCases.Members.Models
{
    public static class Extensions
    {
        public static Member ToEntity(this MemberDetailsModel detailsModel)
        {
            return new Member
            {
                Id = detailsModel.Id,
                FirstName = detailsModel.FirstName,
                LastName = detailsModel.LastName,
                Gender = (Gender) detailsModel.Gender,
                DateOfBirth = detailsModel.DateOfBirth,
                JoinedDate = detailsModel.JoinedDate,
                Image = detailsModel.Image,
                Contact = Contact.From(detailsModel.ContactAddress, detailsModel.ContactPhone),
                Father =  Parent.For(detailsModel.FatherFirstName, detailsModel.FatherContactPhone),
                Mother = Parent.For(detailsModel.MotherFirstName, detailsModel.MotherContactPhone),
                MemberGroupId = detailsModel.MemberGroupId
            };
        }

        public static MemberDetailsModel ToModel(this Member member)
        {
            return new MemberDetailsModel()
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Gender = (int) member.Gender,
                DateOfBirth = member.DateOfBirth,
                JoinedDate = member.JoinedDate,
                Image = member.Image,
                ContactAddress = member.Contact.Address,
                ContactPhone = member.Contact.Phone,
                FatherFirstName = member.Father.Name,
                FatherContactPhone = member.Father.Name,
                MotherFirstName = member.Mother.Name,
                MotherContactPhone = member.Mother.Phone,
            };
        }
    }
}