using System;
using System.Collections.Generic;
using System.Linq;

namespace UsingLINQWithDataObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pet> pets = new List<Pet>();
            List<Owner> owners = new List<Owner>();
            pets.Add(new Pet
            {
                ID = 1,
                OwnerID = 100,
                Name = "Fido",
                AnimalType = "Dog",
                Breed = "Cockapoo",
                YearOfBirth = 2020,
            });
            pets.Add(new Pet
            {
                ID = 2,
                OwnerID = 101,
                Name = "Fifi",
                AnimalType = "Cat",
                Breed = "Tiger",
                YearOfBirth = 2019,
            });
            pets.Add(new Pet
            {
                ID = 3,
                OwnerID = 101,
                Name = "Bob",
                AnimalType = "Fish",
                Breed = "Goldfish",
                YearOfBirth = 2021,
            });
            pets.Add(new Pet
            {
                ID = 4,
                OwnerID = 102,
                Name = "Marmy",
                AnimalType = "Cat",
                Breed = "Marmalade",
                YearOfBirth = 2021,
            });
            pets.Add(new Pet
            {
                ID = 5,
                OwnerID = 101,
                Name = "Bobina",
                AnimalType = "Fish",
                Breed = "Trout",
                YearOfBirth = 2021,
            });
            pets.Add(new Pet
            {
                ID = 6,
                OwnerID = 103,
                Name = "Bobby",
                AnimalType = "Fish",
                Breed = "Goldfish",
                YearOfBirth = 2020,
            });
            pets.Add(new Pet
            {
                ID = 7,
                OwnerID = 110,
                Name = "Oops",
                AnimalType = "Dog",
                Breed = "Dogfish",
                YearOfBirth = 2020,
            });
            owners.Add(new Owner
            {
                ID = 100,
                Name = "Grace Hopper",
                Address = "1 the Street",
                PhoneNumber = "01234567890"
            });
            owners.Add(new Owner
            {
                ID = 101,
                Name = "Joan Clarke",
                Address = "3 the Avenue",
                PhoneNumber = "01357924680"
            });
            owners.Add(new Owner
            {
                ID = 102,
                Name = "Ada Lovelace",
                Address = "7 the Road",
                PhoneNumber = "01767676767"
            });
            owners.Add(new Owner
            {
                ID = 103,
                Name = "Danielle George",
                Address = "5 the North",
                PhoneNumber = "01292929292"
            });
            owners.Add(new Owner
            {
                ID = 104,
                Name = "Walter Messup",
                Address = "4 Western Road",
                PhoneNumber = "01343434343"
            });

            var petsAndOwnersAlt = pets
                  .Join(owners, p => p.OwnerID, o => o.ID, (p, o) =>
                     new
                     {
                         PetName = p.Name,
                         p.AnimalType,
                         p.Breed,
                         Age = DateTime.Now.Year - p.YearOfBirth + 1,
                         OwnerName = o.Name,
                         o.Address,
                         o.PhoneNumber
                     }).ToList();

            petsAndOwnersAlt.ForEach(po => Console.WriteLine(
                                                  $"Pet Name: {po.PetName}, "
                                                + $"Animal Type: {po.AnimalType}, "
                                                + $"Breed: {po.Breed}, "
                                                + $"Age: {po.Age}, "
                                                + $"Owner Name: {po.OwnerName}, "
                                                + $"Address: {po.Address}, "
                                                + $"Phone: {po.PhoneNumber}"));

            var ownersAndPets = (
                      from pet in pets
                      join owner in owners
                        on pet.OwnerID equals owner.ID
                      orderby pet.AnimalType, pet.Breed
                      group new { pet, owner } by new { owner.ID, owner.Name } into ownerPets
                      orderby ownerPets.Key.ID
                      select new
                      {
                          OwnerID = ownerPets.Key.ID,
                          OwnerName = ownerPets.Key.Name,
                          OwnerPets = ownerPets

                      }).ToList();

            Console.WriteLine("\nUsing foreach methods:");
            foreach (var ownerAndPets in ownersAndPets)
            {
                Console.WriteLine($"Owner ID: {ownerAndPets.OwnerID}, "
                                + $"Owner Name: {ownerAndPets.OwnerName}, "
                                + $"Count: {ownerAndPets.OwnerPets.Count()}");
                foreach (var po in ownerAndPets.OwnerPets)
                {
                    Console.WriteLine($"Animal Name: {po.pet.Name}, "
                                    + $"Breed: {po.pet.Breed}, "
                                    + $"Age: {DateTime.Now.Year - po.pet.YearOfBirth}");
                }
            }

            Console.WriteLine("\nUsing ForEach methods:");
            ownersAndPets.ForEach(po =>
            {
                Console.WriteLine($"OwnerID: {po.OwnerID}, "
                                + $"Owner Name: {po.OwnerName}, "
                                + $"Count: {po.OwnerPets.Count()}");
                po.OwnerPets.ToList().ForEach(
                    p => Console.WriteLine($"Animal Name: {p.pet.Name}, "
                                            + $"Breed: {p.pet.Breed}, "
                                            + $"Age: {DateTime.Now.Year - p.pet.YearOfBirth}"));
            });
        }
    }
}
