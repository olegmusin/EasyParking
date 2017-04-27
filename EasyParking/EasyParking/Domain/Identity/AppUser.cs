using System;
using System.ComponentModel.DataAnnotations.Schema;
using EasyParking.Domain.Abstract;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EasyParking.Domain.Entities;

namespace EasyParking.Domain.Identity
{
    public class AppUser : IdentityUser, IEntity<string>
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string Name { get; set; }
        object IEntity.Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public byte[] Version { get; set; }
    }
}
