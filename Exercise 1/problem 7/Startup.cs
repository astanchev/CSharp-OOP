namespace FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        static void Main(string[] args)
        {
            List<string> nameBirthday = new List<string>();
            List<string> parentChild = new List<string>();
            string personBirthday = string.Empty;
            string personName = string.Empty;
            Person person = new Person();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                if (input.Contains("-"))
                {
                    parentChild.Add(input);
                }
                else
                {
                    nameBirthday.Add(input);
                }
            }

            if (nameBirthday[0].Contains('/'))
            {
                personBirthday = nameBirthday[0];
                personName = nameBirthday
                                    .FirstOrDefault(x => x.Contains(personBirthday) && x.Length > personBirthday.Length)
                                    .Replace(personBirthday, "")
                                    .Trim();
            }
            else
            {
                personName = nameBirthday[0];
                personBirthday = nameBirthday
                                        .FirstOrDefault(x => x.Contains(personName) && x.Contains("/"))
                                        .Replace(personName, "")
                                        .Trim();
            }

            person = new Person()
            {
                Name = personName,
                Birthday = personBirthday
            };

            foreach (var line in parentChild)
            {
                if (line.Contains(personName) || line.Contains(personBirthday))
                {
                    string[] currentLine = line.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                    string currentBirthday = string.Empty;
                    string currentName = string.Empty;

                    if (currentLine[0] == personBirthday || currentLine[0] == personName)
                    {
                        Child child = new Child();

                        if (currentLine[1].Contains("/"))
                        {
                            string childBirthday = currentLine[1];
                            string childName = nameBirthday
                                                     .FirstOrDefault(x => x.Contains(childBirthday))
                                                     .Replace(childBirthday, "")
                                                     .Trim();

                            child = new Child() { ChildBirthday = childBirthday, ChildName = childName };
                        }
                        else
                        {
                            string childName = currentLine[1];
                            string childBirthday = nameBirthday
                                .FirstOrDefault(x => x.Contains(childName))
                                .Replace(childName, "")
                                .Trim();

                            child = new Child() { ChildBirthday = childBirthday, ChildName = childName };
                        }

                        person.Children.Add(child);
                    }
                    else
                    {
                        Parent parent = new Parent();

                        if (currentLine[0].Contains("/"))
                        {
                            string parentBirthday = currentLine[0].Trim();
                            string ParentName = nameBirthday
                                                         .FirstOrDefault(x => x.Contains(parentBirthday))
                                                         .Replace(parentBirthday, "")
                                                         .Trim();

                            parent = new Parent() { ParentBirthDay = parentBirthday, ParentName = ParentName };
                        }
                        else
                        {
                            string parentName = currentLine[0].Trim();
                            string ParentBirthday = nameBirthday
                                                             .FirstOrDefault(x => x.Contains(parentName))
                                                             .Replace(parentName, "")
                                                             .Trim();

                            parent = new Parent() { ParentBirthDay = ParentBirthday, ParentName = parentName };
                        }

                        person.Parent.Add(parent);
                    }
                }
            }

            Console.WriteLine($"{person.Name} {person.Birthday}");
            Console.WriteLine("Parents:");

            foreach (var parent in person.Parent)
            {
                Console.WriteLine($"{parent.ParentName} {parent.ParentBirthDay}");
            }

            Console.WriteLine("Children:");

            foreach (var child in person.Children)
            {
                Console.WriteLine($"{child.ChildName} {child.ChildBirthday}");
            }
        }
    }
}
