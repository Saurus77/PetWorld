using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetWorld.Domain.Entities;


namespace PetWorld.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void DbSeed(PetWorldDbContext context)
        {
            if (context.Products.Any())
                return;

            context.Products.AddRange(
                new Product(
                    "Royal Canin Adult Dog 15kg",
                    "Karma dla psów",
                    289,
                    "Premium karma dla dorosłych psów średnich ras"),
                new Product(
                   "Whiskas Adult Kurczak 7kg",
                   "Karma dla kotów",
                    129,
                    "Sucha karma dla dorosłych kotów z kurczakiem"),
                new Product(
                    "Tetra AquaSafe 500ml",
                    "Akwarystyka",
                    45,
                    "Uzdatniacz wody do akwarium, neutralizuje chlor"),
                new Product(
                    "Trixie Drapak XL 150cm",
                    "Akcesoria dla kotów",
                    399,
                    "Wysoki drapak z platformami i domkiem"),
                new Product(
                    "Kong Classic Large",
                    "Zabawki dla psów",
                    69,
                    "Wytrzymała zabawka do napełniania smakołykami"),
                new Product(
                    "Ferplast Klatka dla chomika",
                    "Gryzonie",
                    189,
                    "Klatka 60x40cm z wyposażeniem"),
                new Product(
                    "Flexi Smycz automatyczna 8m",
                    "Akcesoria dla psów",
                    119,
                    "Smycz zwijana dla psów do 50kg"),
                new Product(
                    "Brit Premium Kitten 8kg",
                    "Karma dla kotów",
                    159,
                    "Karma dla kociąt do 12 miesiąca życia"),
                new Product(
                    "JBL ProFlora CO2 Set",
                    "Akwarystyka",
                    549,
                    "Kompletny zestaw CO2 dla roślin akwariowych"),
                new Product(
                    "Vitapol Siano dla królików 1kg",
                    "Gryzonie",
                    25,
                    "Naturalne siano łąkowe, podstawa diety")
            );

            context.SaveChanges();
        }
    }
}
