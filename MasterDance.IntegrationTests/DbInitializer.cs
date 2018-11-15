﻿using MasterDance.Web.Data;
using MasterDance.Web.Data.Entities;

namespace MasterDance.IntegrationTests
{
    public static class DbInitializer
    {
        public static void InitializeDatabase(MasterDanceContext ctx)
        {
            ctx.Members.Add(new Member() { FirstName = "Jovana", LastName = "Bajsanski" });
            ctx.Members.Add(new Member() { FirstName = "Katarina", LastName = "Gucunski" });
            ctx.SaveChanges();

            ctx.DocumentTypes.Add(new DocumentType() {Name = "Izvod iz maticne knjige rodjenih"});
            ctx.DocumentTypes.Add(new DocumentType() {Name = "Lekarski pregled"});
            ctx.SaveChanges();
        }
    }
}