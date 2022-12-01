using System;
using System.Collections.Generic;
using System.Linq;

namespace _05UsingLINQWithDataObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pet> pets = new List<Pet>();
            pets.Add(new Pet
            {
                ID = 1,
                Name = "Fido",
                AnimalType = "Dog",
                Breed = "Cockapoo",
                YearOfBirth = 2020,
                OwnerName = "Grace Hopper",
                OwnerAddress = "1 the High Street",
                OwnerPhoneNumber = "01234567890"
            });
            pets.Add(new Pet
            {
                ID = 2,
                Name = "Fifi",
                AnimalType = "Cat",
                Breed = "Tiger",
                YearOfBirth = 2019,
                OwnerName = "Joan Clarke",
                OwnerAddress = "3 the Wash",
                OwnerPhoneNumber = "01357924680"
            });
            pets.Add(new Pet
            {
                ID = 3,
                Name = "Bob",
                AnimalType = "Fish",
                Breed = "Goldfish",
                YearOfBirth = 2021,
                OwnerName = "Steve Shirley",
                OwnerAddress = "5 North Street",
                OwnerPhoneNumber = "01123581321"
            });
            pets.Add(new Pet
            {
                ID = 4,
                Name = "Marmy",
                AnimalType = "Cat",
                Breed = "Marmalade",
                YearOfBirth = 2021,
                OwnerName = "Ada Lovelace",
                OwnerAddress = "7 Avenue Road",
                OwnerPhoneNumber = "01767676767"
            });
            pets.Add(new Pet
            {
                ID = 5,
                Name = "Bobina",
                AnimalType = "Fish",
                Breed = "Trout",
                YearOfBirth = 2021,
                OwnerName = "Michelle Simmons",
                OwnerAddress = "5 the North",
                OwnerPhoneNumber = "0123232323"
            });
            pets.Add(new Pet
            {
                ID = 6,
                Name = "Bobby",
                AnimalType = "Fish",
                Breed = "Goldfish",
                YearOfBirth = 2020,
                OwnerName = "Danielle George",
                OwnerAddress = "5 the North",
                OwnerPhoneNumber = "01292929292"
            });

            //Create Owner objects from Pet objects
            List<Owner> owners = new List<Owner>();

            //owners = (from pet in pets
            //          select new Owner { 
            //              Name = pet.OwnerName, 
            //              Address = pet.OwnerAddress, 
            //              PhoneNumber = pet.OwnerPhoneNumber 
            //          }).ToList();

            //Alternative using lambda notation
            owners = pets.Select(p => new Owner { 
                        Name = p.OwnerName, 
                        Address = p.OwnerAddress, 
                        PhoneNumber = p.OwnerPhoneNumber }).ToList();

            owners.ForEach(o => Console.WriteLine($"Name: {o.Name}, "
                                                + $"Address: {o.Address}, "
                                                + $"Phone: {o.PhoneNumber}"));

            //Create PetAge objects from Pet objects
            List<PetAge> petAges = new List<PetAge>();
            petAges = (from pet in pets
                       select new PetAge { 
                           ID = pet.ID, 
                           Name = pet.Name, 
                           Age = DateTime.Now.Year - pet.YearOfBirth //Note depending on when in the year a pet's birthday is, the age may be 1 year too high
                       }).ToList(); 

            petAges.ForEach(o => Console.WriteLine($"ID: {o.ID}, "
                                                 + $"Name: {o.Name}, "
                                                 + $"Age: {o.Age}"));

            Console.ReadLine();


             //Create an anonymous type
            var anonymousType = new { ID = 99, Name = "Rover", Genus = "Canis" };
            Console.WriteLine($"Details of the anonymous type: "
                            + $"{anonymousType.ID} "
                            + $"{anonymousType.Name}, "
                            + $"{anonymousType.Genus}");

            //Create a collection of anonymous types
            var petTypes = (from pet in pets
                            select new
                            {
                                ID = pet.ID,
                                Name = pet.Name,
                                PetType = pet.AnimalType,
                                Breed = pet.Breed,
                                Age = DateTime.Now.Year - pet.YearOfBirth //Note depending on when in the year a pet's birthday is, the age may be 1 year too high
                            }).ToList();

            //var petTypes = pets.Select(pet => new
            //               {
            //                    ID = pet.ID,
            //                    Name = pet.Name,
            //                    PetType = pet.AnimalType,
            //                    Breed = pet.Breed,
            //                    Age = DateTime.Now.Year - pet.YearOfBirth
            //               }).ToList(); 

            petTypes.ForEach(
                pt => Console.WriteLine(
                    $"ID: {pt.ID}, "
                  + $"Name: {pt.Name}, "
                  + $"Type: {pt.PetType}, "
                  + $"Breed: {pt.Breed}, "
                  + $"Age: {pt.Age}"
                ));

            foreach (var pt in petTypes) {
                Console.WriteLine(
                    $"ID: {pt.ID}, "
                  + $"Name: {pt.Name}, "
                  + $"Type: {pt.PetType}, "
                  + $"Breed: {pt.Breed}, "
                  + $"Age: {pt.Age}"
                );
            }

            //LINQ Grouping
            var petsByType = (from pet in pets
                              orderby pet.Breed
                              group pet by pet.AnimalType into animalTypes
                              orderby animalTypes.Key
                              select new { AnimalType = animalTypes.Key, 
                                           Animals = animalTypes 
                                         }
                              ).ToList();

            foreach (var petType in petsByType)
            {
                Console.WriteLine($"Animal Type: {petType.AnimalType}, "
                                + $"Count: {petType.Animals.Count()}");
                foreach (var pet in petType.Animals)
                {
                    Console.WriteLine($"Animal Name: {pet.Name}, "
                                    + $"Breed: {pet.Breed}");
                }
            }

            var petsByTypeAlt = pets.OrderBy(p => p.Breed)
                                    .GroupBy(p => p.AnimalType)
                                    .OrderBy(at => at.Key) 
                                    .Select( at => new
                                        { AnimalType = at.Key,
                                          Animals = at
                                        }
                                    ).ToList();

            Console.WriteLine("\nUsing ForEach methods:");
            petsByTypeAlt.ForEach(pbat => { 
                Console.WriteLine($"Animal Type: {pbat.AnimalType}: "
                                + $"Count: {pbat.Animals.Count()}");
                pbat.Animals.ToList().ForEach(
                    p => Console.WriteLine($"Animal Name: {p.Name}, "
                                         + $"Breed: {p.Breed}"));
            });

            Console.WriteLine("\nUsing nested foreach loops:");
            foreach (var petType in petsByTypeAlt)
            {
                Console.WriteLine($"Animal Type: {petType.AnimalType}: Count: {petType.Animals.Count()}");
                foreach (var pet in petType.Animals)
                {
                    Console.WriteLine($"Animal Name: {pet.Name}, Breed: {pet.Breed}");
                }
            }
        }
    }
}
